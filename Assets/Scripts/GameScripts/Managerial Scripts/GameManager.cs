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
    public static int RoundsWonP1;
    public static int RoundsWonP2;
    public static int RoundsWonP3;
    public static int RoundsWonP4;
    public bool roundOver = false;

    // Start is called before the first frame update
    private void Start()
    {
        InitializeGame();
        roundOver = false;
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
            Color winnercolor = playerList[0].GetComponent<MeshRenderer>().material.color;
            string winner = playerList[0].PlayerName;
            Debug.Log("The winner is " + winner);
            WinnerColor.color = winnercolor;

            if(winner == "Player 1" && !roundOver)
            {
                RoundsWonP1++;
                roundOver = true;
            }
            if (winner == "Player 2" && !roundOver)
            {
                RoundsWonP2++;
                roundOver = true;
            }
            if (winner == "Player 3" && !roundOver)
            {
                RoundsWonP3++;
                roundOver = true;
            }
            if (winner == "Player 4" && !roundOver)
            {
                RoundsWonP4++;
                roundOver = true;
            }

            CheckForWinner();
        }
    }

    public void InitializeGame()
    {
        AddPlayers();
        Setup();
    }

    public void CheckForWinner()
    {
        if (RoundsWonP1 == 3)
        {
            Debug.Log("Winner IS P1");
        }
        if (RoundsWonP2 == 3)
        {
            Debug.Log("Winner IS P2");
        }
        if (RoundsWonP3 == 3)
        {
            Debug.Log("Winner IS P3");
        }
        if (RoundsWonP4 == 3)
        {
            Debug.Log("Winner IS P4");
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
