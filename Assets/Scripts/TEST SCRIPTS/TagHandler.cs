using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TagHandler : MonoBehaviour
{
    PlayerInput playerInput;
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        gameObject.tag = "Default";
        Debug.Log(playerInput.user);
        if(playerInput.user.id == 0)
        {
            gameObject.tag = "PlayerHandler1";
        }
        gameObject.tag = "PlayerHandler" + playerInput.user.id;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
