using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private bool isPaused;

    void Start()
    {
        isPaused = false;
    }

    private void TogglePause()
    {
        if (isPaused)
        {
            isPaused = false;
            Time.timeScale = 1;
            pauseMenu.SetActive(isPaused);
            GetComponentInChildren<Camera>().enabled = isPaused;
        }
        else
        {
            isPaused = true;
            Time.timeScale = 0;
            pauseMenu.SetActive(isPaused);
            GetComponentInChildren<Camera>().enabled = isPaused;
        }
    }

    void OnPause(InputValue input)
    {
        TogglePause();
        
    }
}
