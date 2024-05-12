using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class TypeWriter : MonoBehaviour
{
    [SerializeField] float delay = 0.1f;
    string fullText;
    string currentText;
    
    void Start()
    {
        fullText = this.GetComponent<TextMeshProUGUI>().text;
        this.GetComponent<TextMeshProUGUI>().text = string.Empty;
        Invoke("StartTypeWriteing", 3f);
    }

    [ContextMenu("StartTypeWriteing")]
    public void StartTypeWriteing()
    {
        StartCoroutine(ShowText());
    }
    
    IEnumerator ShowText()
    {
        for(int i = 0; i < fullText.Length; i++) 
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<TextMeshProUGUI>().text = currentText;
            if (fullText[i] == '\n' || fullText[i] == '.')
            {
                yield return new WaitForSeconds(2f * delay);
            }
            else
            {
                yield return new WaitForSeconds(delay);
            }
        }
    }

}
