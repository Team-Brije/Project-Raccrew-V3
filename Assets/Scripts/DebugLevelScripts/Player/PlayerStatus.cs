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
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Boundary")
        {
            Debug.Log("Skill Issue");
            isOut = true;
            movement.enabled = false;
        }
    }

    private void Start()
    {
        movement = GetComponent<MovementHandler>();
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
