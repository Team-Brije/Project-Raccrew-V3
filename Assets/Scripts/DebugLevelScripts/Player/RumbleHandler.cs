using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RumbleHandler : MonoBehaviour
{
    [HideInInspector] public PlayerInput input;
    public Gamepad gamepad;
    int id;
    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<PlayerInput>();
        gamepad = input.GetDevice<Gamepad>();
        id = input.user.index;
    }

    private void OnEnable()
    {
        GameManager.OnRumble += StartRumble;
    }

    private void OnDisable()
    {
        GameManager.OnRumble -= StartRumble;
    }

    public void StartRumble(int idplayer)
    {
        if (gamepad != null && GameManager.CanRumble && id == idplayer)
        {
            gamepad.SetMotorSpeeds(0.5f, 1f);
            Invoke(nameof(StopRumble), 0.5f);
        }
    }

    public void StopRumble()
    {
        if (gamepad != null)
        {
            gamepad.SetMotorSpeeds(0, 0);
        }
    }
}
