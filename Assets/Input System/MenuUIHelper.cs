using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MenuUIHelper : MonoBehaviour
{
    public PlayerInput inputActions;
    EventSystem eventSystem;
    public GameObject Play;
    public GameObject Back;

    private void Awake()
    {
        eventSystem = EventSystem.current;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Play.transform.parent.gameObject.activeSelf);
    }

    public void ChangeControls(PlayerInput input)
    {
        switch (input.currentControlScheme)
        {
            case "Gamepad":
                if (Play.transform.parent.gameObject.activeSelf)
                {
                    eventSystem.SetSelectedGameObject(Play);
                }
                else
                {
                    eventSystem.SetSelectedGameObject(Back);
                }
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                break;
            case "Keyboard":
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                break;

        }
    }
}
