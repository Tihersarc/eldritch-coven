using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    public bool IsPaused { get; private set; }

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

        IsPaused = false;
    }

    public void TogglePause()
    {
        if (IsPaused)
        {
            IsPaused = false;
            Time.timeScale = 1;
            pauseMenu.SetActive(IsPaused);

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            Debug.Log("Game is NOT paused");
        }
        else
        {
            IsPaused = true;
            Time.timeScale = 0;
            pauseMenu.SetActive(IsPaused);

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            Debug.Log("Game is paused");
        }
    }

    
}
