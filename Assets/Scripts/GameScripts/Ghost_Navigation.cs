using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Ghost_Navigation : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    public string playerTag;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag).transform;
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine("Destroy");
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.position;
    }
    IEnumerator Destroy()
    {
        Destroy(transform.parent.gameObject,10f);
        yield return new WaitForSeconds(5f);
    }
}
