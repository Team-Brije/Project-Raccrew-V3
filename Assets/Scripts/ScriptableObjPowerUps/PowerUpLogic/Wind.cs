using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public float WindStrength;
    public float FloorUpwardsForce;
    public float StunTime;
    Transform origin;

    private void Start()
    {
        origin = transform;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player1")
        {
            other.GetComponent<Rigidbody>().AddForce((origin.forward * WindStrength) * GameManager.DirtP1, ForceMode.Force); 
            GameManager.StartStun(1,StunTime);
        }
        if (other.gameObject.tag == "Player2")
        {
            other.GetComponent<Rigidbody>().AddForce((origin.forward * WindStrength) * GameManager.DirtP2, ForceMode.Force);
            GameManager.StartStun(2, StunTime);
        }
        if (other.gameObject.tag == "Player3")
        {
            other.GetComponent<Rigidbody>().AddForce((origin.forward * WindStrength) * GameManager.DirtP3, ForceMode.Force);
            GameManager.StartStun(3, StunTime);
        }
        if (other.gameObject.tag == "Player4")
        {
            other.GetComponent<Rigidbody>().AddForce((origin.forward * WindStrength) * GameManager.DirtP4, ForceMode.Force);
            GameManager.StartStun(4, StunTime);
        }
    }
}
