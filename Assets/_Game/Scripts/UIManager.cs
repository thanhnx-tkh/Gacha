using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject panelUI;
    public TextMeshProUGUI textGift;
    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void ActiveUI(string text){
        textGift.text = text;
        panelUI.SetActive(true); 
    }
    public void DisActiveUI(){
        panelUI.SetActive(false); 
    }
}
