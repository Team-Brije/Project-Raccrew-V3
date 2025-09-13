using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public static event Action<int, float, float> OnMove;
    public static event Action<int> OnDash;
    public static event Action<int> OnAbility;
    public static event Action<int> OnShove;
    public static event Action<int> OnStart;
    public static event Action<int, bool> OnConfirm;
    public static event Action<int> OnUp;
    public static event Action<int> OnDown;
    public static event Action<int> OnLeft;
    public static event Action<int> OnRight;
    public static event Action<int, bool> OnThisIsMe;

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

    public void Confirm(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            OnConfirm?.Invoke(id, true);
        }
        else if (context.canceled)
        {
            OnConfirm?.Invoke(id, false);
        }
    }

    public void Up(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnUp?.Invoke(id);
        }
    }

    public void Down(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnDown?.Invoke(id);
        }
    }

    public void Left(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnLeft?.Invoke(id);
        }
    }

    public void Right(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnRight?.Invoke(id);
        }
    }

    public void ThisIsMe(InputAction.CallbackContext context)
    {
        Debug.Log($"[InputHandler] ThisIsMe triggered: {context.phase}");
        if (context.performed) { OnThisIsMe?.Invoke(id, true); }
        else if (context.canceled) { OnThisIsMe?.Invoke(id, false); }
    }

    #endregion

    // Update is called once per frame
    void Update()
    {
        OnMove?.Invoke(id, horizontal, vertical);
    }
}
