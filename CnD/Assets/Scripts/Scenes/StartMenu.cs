using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Dropdown screenResolutionDD;
    Resolution[] resolutionList;

    public void Start()
    {
        resolutionList = Screen.resolutions;

        screenResolutionDD.ClearOptions();

        List<string> resolutionOptions = new List<string>();
        int currentResolutionIndex = 0;
        for(int i = 0; i < resolutionList.Length; i++)
        {
            string option = resolutionList[i].width + "x" + resolutionList[i].height;
            resolutionOptions.Add(option);

            if (resolutionList[i].width == Screen.currentResolution.width && resolutionList[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        screenResolutionDD.AddOptions(resolutionOptions);
        screenResolutionDD.value = currentResolutionIndex;
        screenResolutionDD.RefreshShownValue();
    }

    public void setResolution(int resolutionIndex)
    {
        Resolution resolution = resolutionList[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void setScreenQuality(int screenQualityIndex)
    {
        QualitySettings.SetQualityLevel(screenQualityIndex);
    }

    public void setFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    public void Play()
    {
        SceneManager.LoadScene("Floor1");
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void startMenuQuit()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
