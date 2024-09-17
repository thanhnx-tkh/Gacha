using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textScore;
    [SerializeField]
    private TextMeshProUGUI textRandom;
    public GameObject panelScore;
    public GameObject panelRandom;
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
    private void Start()
    {
        panelScore.SetActive(false);
        panelRandom.SetActive(false);
    }
    public void ShowPanelSocer(int scoreInput)
    {
        panelScore.SetActive(true);
        textScore.text = "Score: " + scoreInput.ToString();
    }
    public void ShowRandomNumber(int numberInput)
    {
        panelRandom.SetActive(true);
        textRandom.text = "Random: " + numberInput.ToString();
    }
}
