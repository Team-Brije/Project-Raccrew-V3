using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<PlayerStatus> playerList;
    [SerializeField] private List<GameObject> players = new List<GameObject>();
    public RawImage WinnerColor;

    // Start is called before the first frame update
    private void Start()
    {
        AddPlayers();
        Setup();
    }

    // Update is called once per frame
    void Update()
    {
        
        foreach(PlayerStatus player in playerList)
        {
            if(player.isOut == true)
            {
                playerList.Remove(player);
            }
        }

        if (playerList.Count == 1)
        {
            Color winnercolor = playerList[0].MapacheColor;
            string winner = playerList[0].PlayerName;
            Debug.Log("The winner is " + winner);
            WinnerColor.color = winnercolor;
        }
    }

    public void AddPlayers()
    {
        if (GameObject.FindGameObjectWithTag("Player1"))
        {
            players.Add(GameObject.FindGameObjectWithTag("Player1"));
        }
        if (GameObject.FindGameObjectWithTag("Player2"))
        {
            players.Add(GameObject.FindGameObjectWithTag("Player2"));
        }
        if (GameObject.FindGameObjectWithTag("Player3"))
        {
            players.Add(GameObject.FindGameObjectWithTag("Player3"));
        }
        if (GameObject.FindGameObjectWithTag("Player4"))
        {
            players.Add(GameObject.FindGameObjectWithTag("Player4"));
        }
    }
    
    public void Setup()
    {
        foreach (GameObject player in players)
        {
            playerList.Add(player.GetComponent<PlayerStatus>());
        }
    }
}
