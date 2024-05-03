using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    [SerializeField] private bool isMainMenu;
    public bool IsPaused { get; set; }

    private static PauseBehaviour instance;
    public static PauseBehaviour Instance {  get { return instance; } }

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

        if (isMainMenu)
        {
            Time.timeScale = 1;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            IsPaused = false;
            TogglePause(IsPaused);
        }
        
    }

    public bool TogglePause()
    {
        if (IsPaused)
        {
            IsPaused = false;
            Time.timeScale = 1;
            if (pauseMenu != null)
                pauseMenu.SetActive(IsPaused);

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            IsPaused = true;
            Time.timeScale = 0;
            if (pauseMenu != null)
                pauseMenu.SetActive(IsPaused);

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        
        return IsPaused;
    }

    public bool TogglePause(bool pauseState)
    {
        if (!pauseState)
        {
            IsPaused = false;
            Time.timeScale = 1;
            if (pauseMenu != null)
                pauseMenu.SetActive(IsPaused);

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            IsPaused = true;
            Time.timeScale = 0;
            if (pauseMenu != null)
                pauseMenu.SetActive(IsPaused);

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        return IsPaused;
    }
}
