using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float ExplosionForce;
    public float FloorUpwardsForce;
    public float Time;
    public float DirtPercentage;
    public float StunTime;
    
    // Start is called before the first frame update
    void Start()
    {
        if (Time != 0)
        {
            Invoke("Die", Time);
        }
    }


    private void OnTriggerStay(Collider other)
    { 
        if (other.gameObject.tag == "Player1")
        {
            other.GetComponent<Rigidbody>().AddExplosionForce(ExplosionForce * GameManager.DirtP1 , gameObject.transform.position, Random.Range(5, 10), FloorUpwardsForce,ForceMode.Impulse);
            GameManager.StartStun(1, StunTime);
        }
        if (other.gameObject.tag == "Player2")
        {
            other.GetComponent<Rigidbody>().AddExplosionForce(ExplosionForce * GameManager.DirtP2, gameObject.transform.position, Random.Range(5, 10), FloorUpwardsForce, ForceMode.Impulse);
            GameManager.StartStun(2, StunTime);
        }
        if (other.gameObject.tag == "Player3")
        {
            other.GetComponent<Rigidbody>().AddExplosionForce(ExplosionForce * GameManager.DirtP3, gameObject.transform.position, Random.Range(5, 10), FloorUpwardsForce, ForceMode.Impulse);
            GameManager.StartStun(3, StunTime);
        }
        if (other.gameObject.tag == "Player4")
        {
            other.GetComponent<Rigidbody>().AddExplosionForce(ExplosionForce * GameManager.DirtP4, gameObject.transform.position, Random.Range(5, 10), FloorUpwardsForce, ForceMode.Impulse);
            GameManager.StartStun(4, StunTime);
        }

    }


    private void OnTriggerExit(Collider other)
    {
        CameraShake.Instance.ShakeThisCamera(0.2f, 1f);
        if (other.gameObject.tag == "Player1")
        {
            GameManager.AddPercentage(1, DirtPercentage);
        }
        if (other.gameObject.tag == "Player2")
        {
            GameManager.AddPercentage(2, DirtPercentage);
        }
        if (other.gameObject.tag == "Player3")
        {  
            GameManager.AddPercentage(3, DirtPercentage);
        }
        if (other.gameObject.tag == "Player4")
        {
            GameManager.AddPercentage(4, DirtPercentage);
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
