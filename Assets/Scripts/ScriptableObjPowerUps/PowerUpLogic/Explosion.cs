using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float ExplosionForce;
    public float FloorUpwardsForce;



    // Start is called before the first frame update
    void Start()
    {

        Invoke("Die", 1.5f);
        
    }


    private void OnTriggerStay(Collider other)
    { 
        if (other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2" || other.gameObject.tag == "Player3" || other.gameObject.tag == "Player4")
        {
            other.GetComponent<Rigidbody>().AddExplosionForce(ExplosionForce, gameObject.transform.position, Random.Range(5, 10), FloorUpwardsForce,ForceMode.Impulse);
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
