using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ScrollController : MonoBehaviour
{
    public InputAction Action;
    [SerializeField] private Scrollbar scrollRect;
    public float scrollvalue;

    private void Start()
    {
        Action.Enable();
        Debug.Log(Action.actionMap);
    }

    private void Update()
    {
        Action.performed += Action_performed;
    }

    private void Action_performed(InputAction.CallbackContext obj)
    {
        
    }

    public void value(float value)
    {
        scrollvalue = value;
    }
    /*
    private void OnEnable()
    {
        scrollUpAction.action.performed += ScrollUp;
        scrollDownAction.action.performed += ScrollDown;
    }

    private void OnDisable()
    {
        scrollUpAction.action.performed -= ScrollUp;
        scrollDownAction.action.performed -= ScrollDown;
    }
    */

    public void Up(InputAction.CallbackContext context)
    {
        
    }

    public void ScrollUp(InputAction.CallbackContext context)
    {
        float scrollAmount = context.ReadValue<float>();
        scrollRect.value += scrollAmount * Time.deltaTime;
    }

    public void ScrollDown(InputAction.CallbackContext context)
    {
        float scrollAmount = context.ReadValue<float>();
        scrollRect.value -= scrollAmount * Time.deltaTime;
    }
}
