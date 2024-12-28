using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerSelect : MonoBehaviour
{
    public PlayerSkin playerSkin;
    private Image image;
    public Canvas canvas;
    public int playerNumber;
    private PlayerInput playerInput;
    public string playerHandlerTag;

    private void Start()
    {
        image = GetComponent<Image>();
        image.color = playerSkin.targetMaterial.color;
    }

    private void OnEnable()
    {
        playerInput = GameObject.FindGameObjectWithTag(playerHandlerTag).GetComponent<PlayerInput>();
    }

    public void ApplyMaterial()
    {
        GameObject player;
        GameObject playerUI;

        playerInput.notificationBehavior = PlayerNotifications.InvokeUnityEvents;
        playerInput.SwitchCurrentActionMap("Movement");

        switch (playerNumber)
        {
            case 0:
                break;
            case 1:
                player = GameObject.FindGameObjectWithTag("Player1Cap");
                player.GetComponent<MeshRenderer>().material = playerSkin.targetMaterial;
                //playerUI = GameObject.FindGameObjectWithTag("PlayerUI1");
                //playerUI.SetActive(false);
                break;
            case 2:
                player = GameObject.FindGameObjectWithTag("Player2Cap");
                player.GetComponent<MeshRenderer>().material = playerSkin.targetMaterial;
                //playerUI = GameObject.FindGameObjectWithTag("PlayerUI2");
                PlayerSelectScript.arePlayersReady = true;
                //playerUI.SetActive(false);
                break;
            case 3:
                player = GameObject.FindGameObjectWithTag("Player3Cap");
                player.GetComponent<MeshRenderer>().material = playerSkin.targetMaterial;
                //playerUI = GameObject.FindGameObjectWithTag("PlayerUI3");
                PlayerSelectScript.arePlayersReady = true;
                //playerUI.SetActive(false);
                break;
            case 4:
                player = GameObject.FindGameObjectWithTag("Player4Cap");
                player.GetComponent<MeshRenderer>().material = playerSkin.targetMaterial;
                //playerUI = GameObject.FindGameObjectWithTag("PlayerUI4");
                PlayerSelectScript.arePlayersReady = true;
                //playerUI.SetActive(false);
                break;
        }
        canvas.gameObject.SetActive(false);

    }
}
