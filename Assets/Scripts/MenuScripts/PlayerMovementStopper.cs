using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementStopper : MonoBehaviour
{
    public MovementHandler player1, player2, player3, player4;
    // Start is called before the first frame update
    void Start()
    {
        player1.canMove = false;
        player2.canMove = false;
        player3.canMove = false;
        player4.canMove = false;
    }
}
