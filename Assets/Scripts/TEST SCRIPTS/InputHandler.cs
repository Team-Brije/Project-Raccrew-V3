using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public static event Action<int, float, float> OnMove;
    public static event Action<int> OnDash;
    public static event Action<int> OnAbility;
    public static event Action<int> OnShove;
    public static event Action<int> OnStart;

    [HideInInspector] public float horizontal;
    [HideInInspector] public float vertical;

    private PlayerInput playerInput;
    private int id;
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        Debug.Log(playerInput.user.id);
        id = (int)playerInput.user.index;
    }

    #region INPUT ACTIONS 

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        vertical = context.ReadValue<Vector2>().y;
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnDash?.Invoke(id);
        }
    }

    public void Ability(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnAbility?.Invoke(id);
        }
    }

    public void Shove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnShove?.Invoke(id);
        }
    }

    public void StartGame(InputAction.CallbackContext context)
    {
        if (context.performed && PlayerSelectScript.arePlayersReady)
        {
            OnStart?.Invoke(id);
        }
    }

    #endregion

    // Update is called once per frame
    void Update()
    {
        OnMove?.Invoke(id, horizontal, vertical);
    }
}
