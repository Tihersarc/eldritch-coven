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
        gameObject.layer = layerToHide;
    }

    private void ShowHiddenObject()
    {
        gameObject.layer = layerToShow;
    }

    private void HideObject()
    {
        gameObject.layer = layerToHide;
    }
}
