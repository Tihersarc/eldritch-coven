using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField]
    private float panelXPositionWhenOpen = 100;
    [SerializeField]
    private float panelXPositionWhenClosed = -100;
    private float panelXPosition;
    [SerializeField]
    private float panelVelocity = 4;

    [SerializeField]
    private RectTransform panelPosition;

    private bool inventoryOpened = false;
    private bool movePanel;

    private void Start()
    {
        panelPosition.anchoredPosition = new Vector2(panelXPositionWhenClosed, 0);
        panelXPosition = panelXPositionWhenClosed;
    }

    private void Update()
    {
        if (movePanel)
        {
            if (inventoryOpened)
            {
                panelXPosition += panelVelocity;
                if (panelXPosition > panelXPositionWhenOpen)
                {
                    panelXPosition = panelXPositionWhenOpen;
                    movePanel = false;
                }
            }
            else
            {
                panelXPosition -= panelVelocity;
                if (panelXPosition < panelXPositionWhenClosed)
                {
                    panelXPosition = panelXPositionWhenClosed;
                    movePanel = false;
                }
            }
            panelPosition.anchoredPosition = new Vector2(panelXPosition, 0);
        }
    }

    private void OnOpenInventory(InputValue input)
    {
        if (inventoryOpened)
        {
            inventoryOpened = false;
            movePanel = true;
        }
        else
        {
            inventoryOpened = true;
            movePanel = true;
        }
    }
}
