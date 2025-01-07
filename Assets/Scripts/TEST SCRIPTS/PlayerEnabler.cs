using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnabler : MonoBehaviour
{
    public List<GameObject> players;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < PlayerSelectScript.NumOfPlayers; i++)
        {
            players[i].SetActive(true);
        }
    }
}
