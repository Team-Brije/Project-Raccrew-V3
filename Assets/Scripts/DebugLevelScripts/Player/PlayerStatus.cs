using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [HideInInspector] public bool isOut = false;
    public PlayerMovement movement;
    public string PlayerName;
    public Color MapacheColor;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Boundary")
        {
            //Debug.Log("Skill Issue");
            isOut = true;
            movement.enabled = false;
        }
    }
}
