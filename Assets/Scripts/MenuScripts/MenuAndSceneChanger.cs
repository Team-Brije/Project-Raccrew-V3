using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuAndSceneChanger : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject SettingsPanel;
    public EventSystem eventSystem;
    private int resx = 1920, resy = 1080;
    private FullScreenMode mode = FullScreenMode.ExclusiveFullScreen;
    public static string gamemode;

    public GameObject PlayButton;
    public GameObject SettingsButton;

    VolumeSliderManager volumeSliderManager;

    public Selectable[] allOptions;

    private void Awake()
    {
        SetDefaultValues();
    }

    public void ChangeScene(string sceneName)
    {
        //Debug.Log("Scene");
        SceneManager.LoadScene(sceneName);
    }
    
    public void GamemodeScene(string scene)
    {
        gamemode = scene;
        PlayButton.SetActive(false);
        SettingsButton.SetActive(true);
        //SceneManager.LoadScene("Loading");
    }

    public void GamemodeSceneLoad()
    {
        SceneManager.LoadScene("Loading");
    }


    public void SetDefaultValues()
    {
        for (int i = 0; i < allOptions.Length; i++)
        {
            switch (i)
            {
                case 0:  //Resolution
                    ChangeResolution(allOptions[i].GetComponent<TMP_Dropdown>().value);
                    break;
                case 1:  //Fullscreen
                    ChangeFullscreenBehaviour(allOptions[i].GetComponent<TMP_Dropdown>().value);
                    break;
                case 2:  //Framerate
                    SetFPSCap(allOptions[i].GetComponent<TMP_Dropdown>().value);
                    break;
                case 3:  //Vsync
                    EnableVsync(allOptions[i].GetComponent<Toggle>().isOn);
                    break;
                case 4:  //MusicVolume
                    volumeSliderManager = allOptions[i].GetComponent<VolumeSliderManager>();
                    volumeSliderManager.ChangeVolume();
                    break;
                case 5:  //SFXVolume 
                    volumeSliderManager = allOptions[i].GetComponent<VolumeSliderManager>();
                    volumeSliderManager.ChangeVolume();
                    break;
                case 6:  //VoiceVolume UNUSED
                    volumeSliderManager = allOptions[i].GetComponent<VolumeSliderManager>();
                    volumeSliderManager.ChangeVolume();
                    break;
                case 7:  //RoundDuration
                    ChangeRoundTime(allOptions[i].GetComponent<TMP_Dropdown>().value);
                    break;
                case 8:  //PWUpFrequency
                    ChangeSpawnRate(allOptions[i].GetComponent<TMP_Dropdown>().value);
                    break;
                case 9:  //PowerUps
                    EnablePowerUps(allOptions[i].GetComponent<Toggle>().isOn);
                    break;
                case 10: //ControlVibration
                    EnableRumble(allOptions[i].GetComponent<Toggle>().isOn);
                    break;
            }
        }
    }

    public void SwitchPanel()
    {
        if (MainMenuPanel.activeSelf == true)
        {
            MainMenuPanel.SetActive(false);
            SettingsPanel.SetActive(true);            
            eventSystem.SetSelectedGameObject(SettingsButton.gameObject);
        }
        else
        {
            MainMenuPanel.SetActive(true);
            SettingsPanel.SetActive(false);
            eventSystem.SetSelectedGameObject(PlayButton.gameObject);
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

    public void EnableRumble(bool enabled)
    {
        GameManager.CanRumble = enabled;
        Debug.Log(enabled);
    }

    public void EnablePowerUps(bool enabled)
    {
        GameManager.CanSpawnPowerUps = enabled;
        Debug.Log(enabled);
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

    public void ChangeRoundTime(int val)
    {
        if (val == 0)
        {
            GameManager.GameTimer = 15;
        }
        if (val == 1)
        {
            GameManager.GameTimer = 30;
        }
        if (val == 2)
        {
            GameManager.GameTimer = 45;
        }
        if (val == 3)
        {
            GameManager.GameTimer = 60;
        }
    }

    public void ChangeSpawnRate(int val)
    {
        if (val == 0)
        {
            GameManager.SpawnFrequency = 10;
        }
        if (val == 1)
        {
            GameManager.SpawnFrequency = 5;
        }
        if (val == 2)
        {
            GameManager.SpawnFrequency = 3;
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
