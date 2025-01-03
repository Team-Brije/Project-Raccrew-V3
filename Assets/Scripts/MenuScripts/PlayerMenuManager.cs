using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerMenuManager : MonoBehaviour
{
    public List<GameObject> gameObjects;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.RoundsWonP1 = 0;
        GameManager.RoundsWonP2 = 0;
        GameManager.RoundsWonP3 = 0;
        GameManager.RoundsWonP4 = 0;

        if (GameObject.FindGameObjectWithTag("PlayerHandler1"))
        {
            gameObjects.Add(GameObject.FindGameObjectWithTag("PlayerHandler1"));

        }

        if (GameObject.FindGameObjectWithTag("PlayerHandler2"))
        {
            gameObjects.Add(GameObject.FindGameObjectWithTag("PlayerHandler2"));

        }

        if (GameObject.FindGameObjectWithTag("PlayerHandler3"))
        {
            gameObjects.Add(GameObject.FindGameObjectWithTag("PlayerHandler3"));

        }

        if (GameObject.FindGameObjectWithTag("PlayerHandler4"))
        {
            gameObjects.Add(GameObject.FindGameObjectWithTag("PlayerHandler4"));

        }

        foreach (GameObject gameObject in gameObjects)
        {
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    
}
