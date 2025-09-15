using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartHandler : MonoBehaviour
{
    private void OnEnable()
    {
        InputHandler.OnStart += StartGame;
    }

    private void OnDisable()
    {
        InputHandler.OnStart -= StartGame;
    }

    void StartGame(int id)
    {
        if (PlayerSelectScript.arePlayersReady && PlayerSelectScript.isInPlayerSelectScreen)
        {
            SceneManager.LoadScene("GAME_Classic");
        }
    }
}
