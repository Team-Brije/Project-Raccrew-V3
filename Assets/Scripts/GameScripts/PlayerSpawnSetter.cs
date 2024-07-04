using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnSetter : MonoBehaviour
{
    GameObject player;
    public string playertag;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(playertag);
        player.transform.position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
