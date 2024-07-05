using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRetainerScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Awake()
    { 
        DontDestroyOnLoad(gameObject);
        //SceneManager.sceneLoaded += OnSceneLoaded;
    }
    /*
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().name == "Main Menu" && gameObject != null)
        {
            Destroy(this);
        }
    }
    */
    // Update is called once per frame
    void Update()
    {
        
    }
}
