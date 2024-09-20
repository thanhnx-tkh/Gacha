using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GachaRandomNumber : MonoBehaviour
{
    public int numberOfGift = 11;
    public float numberCircleRotate;
    private const float CIRCLE = 360f;
    private float angleOfOneGift;
    public Button spinButton;
    public float spinDuration = 6f;
    private bool isSpin = false;

    private void Start()
    {
        angleOfOneGift = CIRCLE / numberOfGift;
        spinButton.onClick.AddListener(StartSpin);
    }

    private IEnumerator RotateWheel()
    {
        isSpin = true;
        float startAngle = transform.eulerAngles.z;
        float timeElapsed = 0f;
        float totalRotation = numberCircleRotate * CIRCLE;

        int indexGiftRandom = Random.Range(1, numberOfGift);
        Debug.Log("Gift index: " + GetGiftByNumber(indexGiftRandom));

        float targetAngle = angleOfOneGift * indexGiftRandom;
        float finalAngle = totalRotation + targetAngle - angleOfOneGift / 2;

        while (timeElapsed < spinDuration)
        {
            yield return new WaitForEndOfFrame();

            timeElapsed += Time.deltaTime;
            float t = timeElapsed / spinDuration;

            float easedT = EaseOutQuint(t);
            float currentAngle = Mathf.Lerp(0, finalAngle, easedT);

            this.transform.eulerAngles = new Vector3(0, 0, startAngle + currentAngle);
        }

        this.transform.eulerAngles = new Vector3(0, 0, startAngle + finalAngle);
        isSpin = false;
        StartCoroutine(CoActiveUI(indexGiftRandom));
    }

    private float EaseOutQuint(float t)
    {
        return 1 - Mathf.Pow(1 - t, 5);
    }

    private IEnumerator CoActiveUI(int indexGiftRandom)
    {
        yield return new WaitForSeconds(1f);
        UIManager.Instance.ActiveUI(GetGiftByNumber(indexGiftRandom));
        transform.eulerAngles = Vector3.zero;

    }
    [ContextMenu("quay")]
    public void StartSpin()
    {
        if (isSpin) return;
        StartCoroutine(RotateWheel());
    }

    public string GetGiftByNumber(int number)
    {
        switch (number)
        {
            case 1:
                return "5k";
            case 2:
                return "10k";
            case 3:
                return "20k";
            case 4:
                return "Quay Lại";
            case 5:
                return "50k";
            case 6:
                return "30k";
            case 7:
                return "100k";
            case 8:
                return "Nhân đôi";
            case 9:
                return "200k";
            case 10:
                return "Chia đôi";
            case 11:
                return "500k";
            default:
                return "null";
        }
    }
}
