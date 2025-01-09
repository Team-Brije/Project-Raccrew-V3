using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesBehaviour : MonoBehaviour
{
    public float speed;
    public float timeout;
    private bool canStartSpawn=false;
    // Start is called before the first frame update
    void Start()
    {
        canStartSpawn=false;
        StartCoroutine(TimeOut());
    }

    // Update is called once per frame
    void Update()
    {
        if(canStartSpawn){
            if (gameObject.transform.position.y < 2.8f){
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+speed, gameObject.transform.position.z);
            }
        }
    }

    public IEnumerator TimeOut(){
        yield return new WaitForSeconds(timeout);
        canStartSpawn=true;
    }
}
