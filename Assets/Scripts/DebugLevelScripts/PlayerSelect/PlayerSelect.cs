using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelect : MonoBehaviour
{
    public PlayerSkin playerSkin;
    private Image image;
    public Canvas canvas;
    public int playerNumber;
    private void Start()
    {
        image = GetComponent<Image>();
        image.color = playerSkin.targetMaterial.color;
    }

    public void ApplyMaterial()
    {
        GameObject player;
        GameObject playerUI;
        switch (playerNumber)
        {
            case 0:
                break;
            case 1:
                player = GameObject.FindGameObjectWithTag("Player1");
                player.GetComponent<MeshRenderer>().material = playerSkin.targetMaterial;
                playerUI = GameObject.FindGameObjectWithTag("PlayerUI1");
                playerUI.SetActive(false);
                break;
            case 2:
                player = GameObject.FindGameObjectWithTag("Player2");
                player.GetComponent<MeshRenderer>().material = playerSkin.targetMaterial;
                playerUI = GameObject.FindGameObjectWithTag("PlayerUI2");
                playerUI.SetActive(false);
                break;
            case 3:
                player = GameObject.FindGameObjectWithTag("Player3");
                player.GetComponent<MeshRenderer>().material = playerSkin.targetMaterial;
                playerUI = GameObject.FindGameObjectWithTag("PlayerUI3");
                playerUI.SetActive(false);
                break;
            case 4:
                player = GameObject.FindGameObjectWithTag("Player4");
                player.GetComponent<MeshRenderer>().material = playerSkin.targetMaterial;
                playerUI = GameObject.FindGameObjectWithTag("PlayerUI4");
                playerUI.SetActive(false);
                break;
        }
        canvas.enabled = false;

    }
}
