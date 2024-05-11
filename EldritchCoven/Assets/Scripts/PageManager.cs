using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PageManager : MonoBehaviour
{
    [SerializeField] private GameObject ui;
    [SerializeField] private TextMeshProUGUI pageText;
    [SerializeField] private TextMeshProUGUI uiText;

    private static PageManager instance;
    public static PageManager Instance { get { return instance; } }

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void UpdateText(string text)
    {
        pageText.text = text;
        uiText.text = text;
    }

    public void EnableUi()
    {
        ui.SetActive(true);
    }

    public void DisableUi()
    {
        ui.SetActive(false);
    }
}
