using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniddenObjects : MonoBehaviour
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
        gameObject.layer = layerToHide;
    }

    public void HideObject()
    {
        gameObject.layer = layerToShow;
    }
}
