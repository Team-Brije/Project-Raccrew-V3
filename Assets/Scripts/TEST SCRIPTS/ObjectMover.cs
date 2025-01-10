using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    bool canInteract;
    public UIMovementHandler movementHandler;
    Animator animator;
    int playerId;

    private void OnEnable()
    {
        InputHandler.OnLeft += MoveLeft;
        InputHandler.OnRight += MoveRight;
    }

    private void OnDisable()
    {
        InputHandler.OnLeft -= MoveLeft;
        InputHandler.OnRight -= MoveRight;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Selector")
            canInteract = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Selector")
            canInteract = false;
    }


    // Start is called before the first frame update
    void Start()
    {
        canInteract = false;
        animator = GetComponent<Animator>();
        playerId = movementHandler.playerId;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,1,0,Space.World);
    }

    public void MoveLeft(int id)
    {
        if (id == playerId && canInteract)
        {
            animator.Play("GoToLeft");
        }
    }

    public void MoveRight(int id)
    {
        if (id == playerId && canInteract)
        {
            animator.Play("GoToRight");
        }
    }
}
