using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PageManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject pageUi;
    [SerializeField] private TextMeshProUGUI pageText;
    [SerializeField] private TextMeshProUGUI uiText;

    [Header("Objects to disable")]
    [SerializeField] private List<GameObject> objects;

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
        pageUi.SetActive(true);
        playerController.DisablePlayerActionMap();
        objects.ForEach(o => o.SetActive(false));

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void DisableUi()
    {
        pageUi.SetActive(false);
        objects.ForEach(o => o.SetActive(true));
        playerController.EnablePlayerActionMap();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
