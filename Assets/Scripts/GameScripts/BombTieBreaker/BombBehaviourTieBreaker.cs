using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehaviourTieBreaker : MonoBehaviour
{
    public GameObject Explotion;
    private Rigidbody bombRb;
    void Start(){   
        bombRb = GetComponent<Rigidbody>();
        BombRotation();
    }
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Stage"){
        Instantiate(Explotion,gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
        }
    }
    private void BombRotation(){
        Vector3 randomTorque = 10f * Random.onUnitSphere;
        bombRb.AddTorque(randomTorque,ForceMode.Impulse);
    }
}
