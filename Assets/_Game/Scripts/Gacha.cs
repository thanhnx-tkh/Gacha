using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class Gacha : MonoBehaviour
{
    public int numberOfGift = 8;
    // thời gian chạy
    private float timeRotate;
    // số vòng quay rồi dừng lại 
    public float numberCircleRotate;
    private const float CIRCLE = 360f;
    // góc của 1 gift
    private float angleOfOneGift;

    public Transform parrent;
    private float currentTime;

    public AnimationCurve curve;
    public bool isSpin = false;

    private void Start() {
        angleOfOneGift = CIRCLE /  numberOfGift;
        //SetPostionData();
        timeRotate = Random.Range(4f, 6f);
    }

    private IEnumerator RotateWheel(){
        isSpin = true;
        float startAngele = transform.eulerAngles.z;
        currentTime = 0; 
        // random gift
        int indexGiftRandom = Random.Range(1, numberOfGift);
        UIManager.Instance.ShowRandomNumber(indexGiftRandom);
        Debug.Log(indexGiftRandom);
        // góc quay 
        float angleWant = (numberCircleRotate * CIRCLE) + angleOfOneGift * indexGiftRandom - startAngele;

        while(true){
            yield return new WaitForEndOfFrame();
            currentTime += Time.deltaTime;
            float angleCurrent = angleWant * curve.Evaluate(currentTime/timeRotate);
            this.transform.eulerAngles = new Vector3(0,0, angleCurrent + startAngele);
            if(angleCurrent == angleWant) 
            {
                isSpin = false;
                UIManager.Instance.ShowPanelSocer(indexGiftRandom);
                break;
                
            }
        }
    }
    public void ButtonRotateNow(){
        if(isSpin) return;
        StartCoroutine(RotateWheel());
    }
    public void SetPostionData(){
        for (int i = 0; i < parrent.childCount; i++)
        {
            parrent.GetChild(i).eulerAngles = new Vector3(0, 0,-CIRCLE / numberOfGift * i);
            parrent.GetChild(i).GetChild(0).GetComponent<TextMeshPro>().text = (i+1).ToString();
        }
    }

}
