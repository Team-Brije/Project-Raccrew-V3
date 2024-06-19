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

    // Call this method when you want to join a player manually
 
    public void EnableUI()
    {
        Debug.Log("Gaming");
        UIElements[id].SetActive(true);
        id++;
        if (id == 2)
        {
            InputManager.playerPrefab = player2;
        }
        if (id == 4)
        {
            InputManager.playerPrefab = player3;
        }
        if (id == 6)
        {
            InputManager.playerPrefab = player4;
        }
        
        //InputManager.playerPrefab.gameObject.transform = SpawnPlatform.transform;
    }


}
