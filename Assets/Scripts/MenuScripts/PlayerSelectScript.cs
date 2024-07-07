using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerSelectScript : MonoBehaviour
{
    public PlayerInputManager InputManager;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public GameObject[] UIElements;
    public int id = 0;
    public GameObject SpawnPlatform;
    public GameObject[] PlayerUI;
    public static bool arePlayersReady = false;
    public GameObject ReadyText;
    // Call this method when you want to join a player manually

    private void Start()
    {
        arePlayersReady = false;
    }
    public void EnableUI()
    {
        Debug.Log("Gaming");
        UIElements[id].SetActive(true);
        id++;
        if (id == 2)
        {
            InputManager.playerPrefab = player2;
            PlayerUI[0].SetActive(false);
        }
        if (id == 4)
        {
            arePlayersReady = false;
            InputManager.playerPrefab = player3;
            PlayerUI[1].SetActive(false);
        }
        if (id == 6)
        {
            arePlayersReady = false;
            PlayerUI[2].SetActive(false);
            InputManager.playerPrefab = player4;
        }
        if (id == 8)
        {
            arePlayersReady = false;
            PlayerUI[3].SetActive(false);
            InputManager.playerPrefab = player4;
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
