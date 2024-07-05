using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerMenuManager : MonoBehaviour
{
    public GameObject[] gameObjects;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("PlayerHolder"))
        {
            gameObjects = GameObject.FindGameObjectsWithTag("PlayerHolder");
        }

        foreach (GameObject gameObject in gameObjects)
        {
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    
}
