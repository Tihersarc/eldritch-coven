using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Layouts;

public class GameController : MonoBehaviour
{
    public GameObject loseCanvas;
    public bool end = false;

    private void Start()
    {
        KillBehaviour.onKill += ShowLoseCanvas;
        loseCanvas.SetActive(false);
    }

    public void ShowLoseCanvas()
    {
        Debug.Log("hola");
        loseCanvas.SetActive(true);
    }
}
