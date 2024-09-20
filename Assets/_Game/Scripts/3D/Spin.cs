using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public Gacha3D gacha3D;
    private void OnMouseUp() {
        gacha3D.StartSpin();
    }
}
