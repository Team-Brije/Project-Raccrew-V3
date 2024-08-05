using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RIngTieBreaker : MonoBehaviour
{
    public float force;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2" || other.gameObject.tag == "Player3" || other.gameObject.tag == "Player4")
        {
            Vector3 direction = (transform.position - other.transform.position).normalized;
            other.gameObject.GetComponent<Rigidbody>().AddForce(direction * -force);
            Debug.Log("Esta detectando mamadas");
        }
    }
}
