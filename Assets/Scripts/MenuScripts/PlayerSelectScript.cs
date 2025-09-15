using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerSelectScript : MonoBehaviour
{
    public static int NumOfPlayers;
    public PlayerInputManager InputManager;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    //public GameObject[] UIElements;
    public int id = 0;
    public GameObject SpawnPlatform;
    public GameObject[] PlayerUI;
    public static bool arePlayersReady = false;
    public GameObject ReadyText;

    public static bool isInPlayerSelectScreen = false;  
    // Call this method when you want to join a player manually

    private void Start()
    {
        arePlayersReady = false;
        isInPlayerSelectScreen = true;
        NumOfPlayers = 0;
        InputManager.playerPrefab.tag = "PlayerHandler1";
    }
    public void EnableUI()
    {
        //UIElements[id].SetActive(true);
        id++;
        if (id == 1)
        {
            InputManager.playerPrefab.tag = "PlayerHandler2";
            PlayerUI[0].SetActive(false);
            NumOfPlayers++;
        }
        if (id == 2)
        {
            arePlayersReady = false;
            InputManager.playerPrefab.tag = "PlayerHandler3";
            PlayerUI[1].SetActive(false);
            NumOfPlayers++;
        }
        if (id == 3)
        {
            arePlayersReady = false;
            PlayerUI[2].SetActive(false);
            InputManager.playerPrefab.tag = "PlayerHandler4";
            NumOfPlayers++;
        }
        if (id == 4)
        {
            arePlayersReady = false;
            PlayerUI[3].SetActive(false);
            //InputManager.playerPrefab = player4;
            NumOfPlayers++;
        }


        //InputManager.playerPrefab.gameObject.transform = SpawnPlatform.transform;
    }

    public void Update()
    {
        ReadyText.SetActive(arePlayersReady);
        /*
        if (arePlayersReady)
        {
            ReadyText.SetActive(true);
        }
        else
        {
            ReadyText.SetActive(false);
        }
        */
    }
}
