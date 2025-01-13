using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBucketScript : MonoBehaviour
{
    public float massChange;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    { 
        if (other.gameObject.tag == "Player1")
        {
            other.GetComponent<Rigidbody>().mass = massChange;

        }
        if (other.gameObject.tag == "Player2")
        {
            other.GetComponent<Rigidbody>().mass = massChange;
        }
        if (other.gameObject.tag == "Player3")
        {
            other.GetComponent<Rigidbody>().mass = massChange;
        }
        if (other.gameObject.tag == "Player4")
        {
            other.GetComponent<Rigidbody>().mass = massChange;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player1")
        {
            other.GetComponent<Rigidbody>().mass = 1f;
        }
        if (other.gameObject.tag == "Player2")
        {
            other.GetComponent<Rigidbody>().mass = 1f;
        }
        if (other.gameObject.tag == "Player3")
        {  
            other.GetComponent<Rigidbody>().mass = 1f;
        }
        if (other.gameObject.tag == "Player4")
        {
            other.GetComponent<Rigidbody>().mass = 1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
