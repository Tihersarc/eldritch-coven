using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Page : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI uiText;
    private string text;

    void Start()
    {
        text = uiText.text;
    }

    public void Interact()
    {
        PageManager.Instance.UpdateText(text);
        PageManager.Instance.EnableUi();
    }
}
