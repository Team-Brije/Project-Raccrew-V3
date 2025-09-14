using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            //Debug.Log("Skill Issue");
            isOut = true;
            mapacheDead?.Invoke();
            movement.enabled = false;
        }
        if (other.tag == "GoldBullet")
        {
            //Debug.Log("Skill Issue");
            isOut = true;
            mapacheDead?.Invoke();
            movement.enabled = false;
            Instantiate(confetti, playerpos.position, confetti.transform.rotation);
            this.gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        movement = GetComponent<MovementHandler>();
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
