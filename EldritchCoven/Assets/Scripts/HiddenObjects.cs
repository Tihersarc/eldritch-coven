using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenObjects : MonoBehaviour
{
    int layerToHide = 3;
    int layerToShow = 0;

    private void Awake()
    {
        PlayerController.showHiddenObjects += ShowHiddenObject;
        PlayerController.hideObjects += HideObject;
    }

    private void Start()
    {
        HideObject();
    }

    public void ShowHiddenObject()
    {
        gameObject.layer = layerToShow;

        foreach (Transform child in transform)
        {
            child.gameObject.layer = layerToShow;
        }
    }

    public void HideObject()
    {
        gameObject.layer = layerToHide;

        foreach(Transform child in transform)
        {
            child.gameObject.layer = layerToHide;
        }
    }
}
