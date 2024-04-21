using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Layouts;

public class GameController : MonoBehaviour
{
    public GameObject loseCanvas;
    public GameObject winCanvas;
    public bool end = false;

    private void Start()
    {
        KillBehaviour.onKill += ShowLoseCanvas;
        ButtonManager.onWin += ShowWinCnavas;
        loseCanvas.SetActive(false);
        winCanvas.SetActive(false);
    }

    public void ShowWinCnavas()
    {
        winCanvas.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ShowLoseCanvas()
    {
        loseCanvas.SetActive(true);
        Debug.Log("UwU");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
