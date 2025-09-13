using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject ExplosionPrefab;
    public GameObject MainGameObject;
    public float gravity;

    public enum BulletType { GroundHitting, PlayerHitting, UnstoppableForce};
    public BulletType type;

    public Vector3 P0, V0;
    public float velocityMultiply = 1;

    private float t;
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("Die",5); 
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime*velocityMultiply;
        transform.position = positionFunction();
        transform.forward = velocityFunction();
    }

    Vector3 positionFunction()
    {
        Vector3 g = new Vector3(0, gravity, 0);
        return 1f * g * t * t + V0 * t + P0;
    }

    Vector3 velocityFunction()
    {
        Vector3 g = new Vector3(0, gravity, 0);
        return g * t + V0;
    }

    public void Die()
    {
        Destroy(gameObject);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Stage" && type == BulletType.GroundHitting)
        {
            Instantiate(ExplosionPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(MainGameObject);
        }
        if (type == BulletType.PlayerHitting)
        {
            if (other.gameObject.tag == "Player1"  || other.gameObject.tag == "Player2" || other.gameObject.tag == "Player3" || other.gameObject.tag == "Player4")
            {
                Instantiate(ExplosionPrefab, gameObject.transform.position, Quaternion.identity);
                Destroy(MainGameObject);
            }
        }
        if(other.gameObject.tag == "BoundaryPU")
        {
            Destroy(MainGameObject);
        }
    }
}
