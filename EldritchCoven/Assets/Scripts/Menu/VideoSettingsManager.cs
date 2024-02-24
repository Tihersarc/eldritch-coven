using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VideoSettingsManager : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private TMP_Dropdown refreshDropdown;
    [SerializeField] private Toggle fullscreenToggle;

    private List<string> dropdownOptions;
    private Resolution[] resolutionList;
    private List<Vector2> uniqueResolutionList;
    private int resolutionIndex;

    void Start()
    {
        dropdownOptions = new();
        resolutionList = Screen.resolutions;
        uniqueResolutionList = new();

        resolutionDropdown.ClearOptions();

        for (int i = 0; i < resolutionList.Length; i++)
        {
            Vector2 resolution = new Vector2(resolutionList[i].width, resolutionList[i].height);
            if (!uniqueResolutionList.Contains(resolution))
            {
                uniqueResolutionList.Add(resolution);
                dropdownOptions.Add(resolutionList[i].width + "x" + resolutionList[i].height);
            }

            if (resolutionList[i].width == Screen.currentResolution.width && resolutionList[i].height == Screen.currentResolution.height)
            {
                resolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(dropdownOptions);
        resolutionDropdown.value = resolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resIndex)
    {
        Resolution res = resolutionList[resIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

    public void SetRefreshRate(int hz) // Works incorrectly
    {
        Application.targetFrameRate = hz;
    }

    public void SetVerticalSync(bool isVSync)
    {
        if (isVSync)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
        
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
