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
        GameManager.RoundsWonP1 = 0;
        GameManager.RoundsWonP2 = 0;
        GameManager.RoundsWonP3 = 0;
        GameManager.RoundsWonP4 = 0;

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
