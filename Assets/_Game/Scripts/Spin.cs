using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public Gacha gacha;
    private void OnMouseUp() {
        gacha.ButtonRotateNow();
    }
}
