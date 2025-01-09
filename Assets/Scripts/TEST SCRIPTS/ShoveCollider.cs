using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoveCollider : MonoBehaviour
{
    Shovehandler shovehandler = new Shovehandler();
    public float speed = 100000;
    public float shoveSpeed = 150000;
    public float DirtPercentage;
    public float StunTime;


    public void OnTriggerEnter(Collider other) {
        if (shovehandler.isShoving == false)
        {
            if (other.gameObject.tag == "Player1")
            {
                float pushForce = shoveSpeed*GameManager.DirtP1;
                float dirtForce = pushForce * 2;
                Debug.Log(dirtForce);
                other.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * dirtForce, ForceMode.Impulse);
                GameManager.StartStun(1, StunTime);
        } else if (other.gameObject.tag == "Player2")
            {
                float pushForce = shoveSpeed*GameManager.DirtP2;
                float dirtForce = pushForce * 2;
                other.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * dirtForce, ForceMode.Impulse);
                GameManager.StartStun(2, StunTime);
        } else if (other.gameObject.tag == "Player3")
            {
                float pushForce = shoveSpeed*GameManager.DirtP3;
                float dirtForce = pushForce * 2;
                other.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * dirtForce, ForceMode.Impulse);
                GameManager.StartStun(3, StunTime);
        } else if (other.gameObject.tag == "Player4")
            {
                float pushForce = shoveSpeed*GameManager.DirtP4;
                float dirtForce = pushForce * 2;
                other.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * dirtForce, ForceMode.Impulse);
                GameManager.StartStun(4, StunTime);
        }
    }}
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player1")
        {
            GameManager.AddPercentage(1, DirtPercentage);
            Debug.Log("Anadir tierra 1");
        }
        if (other.gameObject.tag == "Player2")
        {
            GameManager.AddPercentage(2, DirtPercentage);
            Debug.Log("Anadir tierra 2");
        }
        if (other.gameObject.tag == "Player3")
        {  
            GameManager.AddPercentage(3, DirtPercentage);
            Debug.Log("Anadir tierra 3");
        }
        if (other.gameObject.tag == "Player4")
        {
            GameManager.AddPercentage(4, DirtPercentage);
            Debug.Log("Anadir tierra 4");
        }
    }
}
