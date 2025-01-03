using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class UIInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    public string UITAG;
    private InputSystemUIInputModule inputModule;

    private InputAction Move, Accept, Cancel, Click;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        inputModule = GameObject.FindGameObjectWithTag(UITAG).GetComponent<InputSystemUIInputModule>();
        xd();
    }

    public void xd()
    {
        var actionMap = playerInput.actions.FindActionMap("UI");

        Move = actionMap.FindAction("Navigate");
        Accept = actionMap.FindAction("Submit");
        Cancel = actionMap.FindAction("Cancel");
        Click = actionMap.FindAction("Click");
        Move = inputModule.move;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
