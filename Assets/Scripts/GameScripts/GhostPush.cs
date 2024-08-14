using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPush : MonoBehaviour
{
    public float force;
    public float StunTime;

    private void OnTriggerEnter(Collider other)
    {
       

        if (other.gameObject.tag == "Player1")
        {
            Vector3 direction = (transform.position - other.transform.position).normalized;
            other.gameObject.GetComponent<Rigidbody>().AddForce(direction * -force * GameManager.DirtP1);
            GameManager.StartStun(1, StunTime);
        }
        if (other.gameObject.tag == "Player2")
        {
            Vector3 direction = (transform.position - other.transform.position).normalized;
            other.gameObject.GetComponent<Rigidbody>().AddForce(direction * -force * GameManager.DirtP2);
            GameManager.StartStun(2, StunTime);
        }
        if (other.gameObject.tag == "Player3")
        {
            Vector3 direction = (transform.position - other.transform.position).normalized;
            other.gameObject.GetComponent<Rigidbody>().AddForce(direction * -force * GameManager.DirtP3);
            GameManager.StartStun(3, StunTime);
        }
        if (other.gameObject.tag == "Player4")
        {
            Vector3 direction = (transform.position - other.transform.position).normalized;
            other.gameObject.GetComponent<Rigidbody>().AddForce(direction * -force * GameManager.DirtP4);
            GameManager.StartStun(4, StunTime);
        }
    }
}
