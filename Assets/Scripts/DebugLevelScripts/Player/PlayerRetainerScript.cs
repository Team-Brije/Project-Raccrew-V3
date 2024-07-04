using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRetainerScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Main Menu")
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
