using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public static float DirtP1;
    public static float DirtP2;
    public static float DirtP3;
    public static float DirtP4;

    // Start is called before the first frame update
    private void Start()
    {
        roundOver = false;
        InitializeGame();
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
                Invoke("RestartGame", 5);
            }
            if (winner == "Player 2" && !roundOver)
            {
                RoundsWonP2++;
                roundOver = true;
                Invoke("RestartGame", 5);
            }
            if (winner == "Player 3" && !roundOver)
            {
                RoundsWonP3++;
                roundOver = true;
                Invoke("RestartGame", 5);
            }
            if (winner == "Player 4" && !roundOver)
            {
                RoundsWonP4++;
                roundOver = true;
                Invoke("RestartGame", 5);
            }

            CheckForWinner();
        }
    }


    void RestartGame()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void InitializeGame()
    {
        CleanList();
        AddPlayers();
        Setup();
    }

    public void CheckForWinner()
    {
        if (RoundsWonP1 == 3)
        {
            Debug.Log("Game Winner IS P1");
            SendToWinnerScreen();
        }
        if (RoundsWonP2 == 3)
        {
            Debug.Log("Game Winner IS P2");
            SendToWinnerScreen();
        }
        if (RoundsWonP3 == 3)
        {
            Debug.Log("Game Winner IS P3");
            SendToWinnerScreen();
        }
        if (RoundsWonP4 == 3)
        {
            Debug.Log("Game Winner IS P4");
            SendToWinnerScreen();
        }
    }

    public void SendToWinnerScreen()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void CleanList()
    {
        playerList.Clear();
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
    
    public static void AddPercentage(int num, float percentage)
    {
        if (num == 1)
        {
            DirtP1 += percentage;
        }
        if (num == 2)
        {
            DirtP2 += percentage;
        }
        if (num == 3)
        {
            DirtP3 += percentage;
        }
        if (num == 4)
        {
            DirtP4 += percentage;
        }
    }

    public void Setup()
    {
        foreach (GameObject player in players)
        {
            playerList.Add(player.GetComponent<PlayerStatus>());
            player.GetComponent<PlayerMovement>().enabled = true;
            player.GetComponent<PlayerStatus>().isOut = false;
        }
        DirtP1 = 1;
        DirtP2 = 1;
        DirtP3 = 1;
        DirtP4 = 1;
    }
}
