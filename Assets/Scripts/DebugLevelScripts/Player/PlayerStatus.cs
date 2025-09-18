using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    [HideInInspector] public bool isOut = false;
    public MovementHandler movement;
    public string PlayerName;
    public Color MapacheColor;
    public GameManager gameManager;
    int id;
    public Transform playerpos;
    public GameObject confetti;
    public static event Action mapacheDead;
    public GameObject racc;
    public Sprite raccImgStun;
    public Image RaccImg;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            //Debug.Log("Skill Issue");
            RaccImg.sprite = raccImgStun;
            isOut = true;
            mapacheDead?.Invoke();
            movement.enabled = false;
        }
        if (other.tag == "GoldBullet")
        {
            //Debug.Log("Skill Issue");
            RaccImg.sprite = raccImgStun;
            Instantiate(confetti, playerpos.position, confetti.transform.rotation);
            Debug.Log(this.gameObject.name);
            isOut = true;
            movement.enabled = false;
            this.gameObject.SetActive(false);
            mapacheDead?.Invoke();
        }
    }

    private void Start()
    {
        movement = GetComponent<MovementHandler>();
        RaccImg = movement.faceImage;
        raccImgStun = movement.stunFace;
        if(gameManager != null)
        gameManager.playerList.Add(this);
        id = movement.playerId;
        switch (id)
        {
            case 0:
                MapacheColor = ColorManagerSingleton.Instance.colorP1;
                break;
            case 1:
                MapacheColor = ColorManagerSingleton.Instance.colorP2;
                break;
            case 2:
                MapacheColor = ColorManagerSingleton.Instance.colorP3;
                break;
            case 3:
                MapacheColor = ColorManagerSingleton.Instance.colorP4;
                break;
        }
    }

    private void OnEnable()
    {
        
    }
}
