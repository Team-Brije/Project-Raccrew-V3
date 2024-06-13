using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameMode : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(MenuAndSceneChanger.gamemode);
    }
}
