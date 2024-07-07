using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public Transform cam;

    public float horizontal;
    public float vertical;

    public float initialspeed;
    float speed;
    public float scalingspeed;
    

    public float smoothtime = 0.1f;
    float turnSmoothVelocity;

    private Vector3 previousPosition; //the previous position of the gameobject
    private Vector3 velocity; //the velocity vector of the gameobject
    private Vector3 yAxis; //the y axis vector
    private Vector3 movedir;
    [Header("Dash Parameters")]

    public float dashDuration;

    public float dashPercentageBoost = 0.2f;

    bool canDash = true;

    // Start is called before the first frame update
    void Start()
    {
        previousPosition = transform.position; //initialize the previous position
        yAxis = new Vector3(0, 1, 0); //initialize the y axis vector
        speed = initialspeed;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        velocity = transform.position - previousPosition; //calculate the velocity vector
        previousPosition = transform.position; //update the previous position

        float dot = Vector3.Dot(velocity, yAxis); //calculate the dot product

        if (dot > 0.01f)
        {
            Debug.Log("Moving upwards");
            speed = scalingspeed;

        }
        else if (dot == 0)
        {
            speed = initialspeed;
        }

        Vector3 direction = new Vector3(horizontal * speed, rb.velocity.y * 0, vertical * speed);
        if (direction.magnitude >= 0.1f)
        {
            float targetangle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetangle, ref turnSmoothVelocity, smoothtime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            movedir = Quaternion.Euler(0f, targetangle, 0f) * Vector3.forward;
            /*
            rb.velocity = movedir.normalized * speed;
            rb.velocity = new Vector3(rb.velocity.x, -9.8f, rb.velocity.z);
            */
            rb.AddForce(movedir.normalized*initialspeed,ForceMode.Force);
          
        }
        /*
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
        */

    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        vertical = context.ReadValue<Vector2>().y;
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if(context.performed && canDash)
        {
            StartCoroutine(Dashing());
        }
    }

    public void StartGame(InputAction.CallbackContext context)
    {
        if(PlayerSelectScript.arePlayersReady && context.performed)
        {
            SceneManager.LoadScene("Loading");
        }
    }

    public IEnumerator Dashing()
    {
        Debug.Log("Dashing");
        canDash = false;
        float startspeed = initialspeed;
        float dashingspeed = initialspeed * dashPercentageBoost;
        rb.AddForce(movedir.normalized * dashingspeed, ForceMode.Impulse);
        yield return new WaitForSeconds(dashDuration);
        //initialspeed = startspeed;
        canDash = true;
    }
}
