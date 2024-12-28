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
    }

    private void OnEnable()
    {
        
    }
}
