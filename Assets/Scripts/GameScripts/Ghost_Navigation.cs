using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Ghost_Navigation : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent; 
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player1").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.position;    
    }
}
