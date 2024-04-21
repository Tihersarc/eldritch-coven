using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public void LoadScene(int sceneIndex)
    {
        Debug.Log("hola");
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenuBeta");
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
