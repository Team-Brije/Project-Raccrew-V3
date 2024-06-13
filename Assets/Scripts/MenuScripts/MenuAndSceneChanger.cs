using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuAndSceneChanger : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject SettingsPanel;
    private int resx = 1920, resy = 1080;
    private FullScreenMode mode = FullScreenMode.ExclusiveFullScreen;
    public static string gamemode;
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void GamemodeScene(string scene)
    {
        gamemode = scene;
        SceneManager.LoadScene("Loading");
    }

    public void SwitchPanel()
    {
        if (MainMenuPanel.activeSelf == true)
        {
            MainMenuPanel.SetActive(false);
            SettingsPanel.SetActive(true);
        }
        else
        {
            MainMenuPanel.SetActive(true);
            SettingsPanel.SetActive(false);
        }
    }

    public void ChangeFullscreenBehaviour(int val)
    {
        if (val == 0)
        {
            mode = FullScreenMode.ExclusiveFullScreen;
            ResChange();
        }
        if (val == 1)
        {
            mode = FullScreenMode.FullScreenWindow;
            ResChange();
        }
        if (val == 2)
        {
            mode = FullScreenMode.Windowed;
            ResChange();
        }
    }

    public void ChangeResolution(int val)
    {
        if (val == 0)
        {
            resx = 4096;
            resy = 2160;
            ResChange();
        }
        if (val == 1)
        {
            resx = 2560;
            resy = 1440;
            ResChange();
        }
        if(val == 2)
        {
            resx = 1440;
            resy = 900;
            ResChange();
        }
        if (val == 3)
        {
            resx = 1920;
            resy = 1080;
            ResChange();
        }
        if (val == 4)
        {
            resx = 1366;
            resy = 768;
            ResChange();
        }
        if (val == 5)
        {
            resx = 1280;
            resy = 1024;
            ResChange();
        }
        if (val == 6)
        {
            resx = 1024;
            resy = 768;
            ResChange();
        }
    }

    public void EnableVsync(bool enabled)
    {
        if (enabled)
        {
            Debug.Log("Enabled");
            QualitySettings.vSyncCount = 1;
        }
        if (!enabled)
        {
            Debug.Log("Disabled");
            QualitySettings.vSyncCount = 0;
        }
    }

    public void SetFPSCap(int val)
    {
        if (val == 0)
        {
            Application.targetFrameRate = -1;
        }
        if (val == 1)
        {
            Application.targetFrameRate = 240;
        }
        if (val == 2)
        {
            Application.targetFrameRate = 120;
        }
        if (val == 3)
        {
            Application.targetFrameRate = 60;
        }
        if (val == 4)
        {
            Application.targetFrameRate = 30;
        }
    }

    public void ResChange()
    {
        Screen.SetResolution(resx, resy, mode);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
