using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] float fadeDuration = 1.0f;
    public RawImage fadePanel;

    public void LoadScene(int sceneIndex)
    {
        //SceneManager.LoadScene(sceneIndex);
        StartCoroutine(LoadSceneAsync(sceneIndex));
    }

    IEnumerator LoadSceneAsync(int sceneIndex)
    {
        float timer = 0;
        Color startColor = fadePanel.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 1);
        while (fadePanel.color.a < 1)
        {
            Debug.Log(startColor.a);
            fadePanel.color = Color.Lerp(startColor, targetColor, timer / fadeDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneIndex);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        
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
