using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GachaRandom : MonoBehaviour
{
    public Button spinButton;
    public int rotations = 10;
    private bool isSpinning = false;
    private float currentAngle = 0f;

    private void Start()
    {
        spinButton.onClick.AddListener(StartSpin);
        currentAngle = transform.eulerAngles.z;
    }
    void StartSpin()
    {
        if (!isSpinning)
        {
            float spinDuration = 10f;
            StartCoroutine(SpinWheel(spinDuration));
        }
    }

    IEnumerator SpinWheel(float spinDuration)
    {
        isSpinning = true;
        float elapsedTime = 0f;

        float totalRotations = rotations;
        float targetAngle = totalRotations * 360f + Random.Range(0, 360);

        while (elapsedTime < spinDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / spinDuration;

            float easedT = EaseOutQuint(t);

            currentAngle = Mathf.Lerp(0f, targetAngle, easedT) % 360f;
            transform.eulerAngles = new Vector3(0, 0, currentAngle);

            yield return null;
        }

        int result = GetResultFromAngle(currentAngle);

        StartCoroutine(CoActiveUI(result));
        isSpinning = false;
    }
    private IEnumerator CoActiveUI(int indexGiftRandom)
    {
        yield return new WaitForSeconds(1f);
        UIManager.Instance.ActiveUI(GetGiftByNumber(indexGiftRandom));
    }

    float EaseOutQuint(float t)
    {
        return 1 - Mathf.Pow(1 - t, 5);
    }

    int GetResultFromAngle(float angle)
    {
        int numberOfSections = 11;
        float sectionAngle = 360f / numberOfSections;
        float adjustedAngle = angle % 360;
        int result = Mathf.FloorToInt(adjustedAngle / sectionAngle) + 1;
        if (result > numberOfSections)
        {
            result = numberOfSections;
        }

        return result;
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
