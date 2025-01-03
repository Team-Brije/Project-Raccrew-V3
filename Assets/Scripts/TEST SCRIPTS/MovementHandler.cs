using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementHandler : MonoBehaviour
{
    public int playerId;
    float horizontal, vertical;

    Rigidbody rb;

    [HideInInspector] public Transform cam;

    public float initialspeed;
    [HideInInspector] public float speed;
    private float scalingspeed;

    public float smoothtime = 0.1f;
    float turnSmoothVelocity;

    private Vector3 previousPosition; //the previous position of the gameobject
    private Vector3 velocity; //the velocity vector of the gameobject
    private Vector3 yAxis; //the y axis vector
    private Vector3 movedir;

    public bool isMoving;

    [Header("Dash Parameters")]

    public float dashDuration;

    public float dashPercentageBoost = 0.2f;

    public bool canDash = true;

    public bool canMove = true;

    public bool IFrames = false;

    public float IFrameDuration = 2;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        previousPosition = transform.position; //initialize the previous position
        yAxis = new Vector3(0, 1, 0); //initialize the y axis vector
        speed = initialspeed;
    }


    private void OnEnable()
    {
        InputHandler.OnMove += Move;
        InputHandler.OnDash += Dash;
        GameManager.OnStun += EnableStun;
    }

    private void OnDisable()
    {
        InputHandler.OnMove -= Move;
        InputHandler.OnDash -= Dash;
        GameManager.OnStun -= EnableStun;
    }

    void FixedUpdate()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        velocity = transform.position - previousPosition; //calculate the velocity vector
        previousPosition = transform.position; //update the previous position
        if (canMove)
        {
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
                rb.AddForce(movedir.normalized * initialspeed, ForceMode.Force);

            }
        }
    }

    private void Update()
    {
        if (horizontal == 0 && vertical == 0)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
    }


    public void Move(int id, float horizontal1, float vertical1)
    {
        if (id == playerId)
        {
            //Debug.Log("Player id is "+id);
            //Debug.Log("Player " +id+ " horizontal value "+horizontal1);
            //Debug.Log("Player " +id+ " vertical value " + vertical1);
            horizontal = horizontal1;
            vertical = vertical1;
        }
    }

    public void Dash(int id)
    {
        if(canDash && isMoving)
        {
            StartCoroutine(Dashing());
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

    public void EnableStun(int idplayer,float time)
    {
        if (!IFrames && idplayer == playerId)
        {
            StartCoroutine(Stun(time));
            StartCoroutine(IFramesCooldown(IFrameDuration));
        }
    }

    IEnumerator IFramesCooldown(float time)
    {
        yield return new WaitForSeconds(time);
    }

    IEnumerator Stun(float time)
    {
        canMove = false;
        yield return new WaitForSeconds(time);
        canMove = true;
    }
}
