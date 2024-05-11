using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Page : MonoBehaviour
{
    private string text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>().text;
    }

    public void Interact()
    {
        PageManager.Instance.UpdateText(text);
        PageManager.Instance.EnableUi();
    }
}
