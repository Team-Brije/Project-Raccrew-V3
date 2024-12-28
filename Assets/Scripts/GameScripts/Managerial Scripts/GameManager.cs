using System;
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
    public Image WinnerColor;
    public GameObject WinnerScreen;
    public TMPro.TextMeshProUGUI WinnerText;
    public GameObject[] wonRounds;
    bool Softlock = true;
    public Countdown timer;
    public float timepercentage;
    // -- Static Variables --
    public static int RoundsWonP1;
    public static int RoundsWonP2;
    public static int RoundsWonP3;
    public static int RoundsWonP4;
    public static float DirtP1;
    public static float DirtP2;
    public static float DirtP3;
    public static float DirtP4;
    [HideInInspector] public bool roundOver = false;
    public bool debug = false;
    public static PlayerMovement Player1;
    public static PlayerMovement Player2;
    public static PlayerMovement Player3;
    public static PlayerMovement Player4;
    public static bool DirtCap = true;
    // --- GAME VARIABLES --- 
    public static float MaxDirtPercentage = 2;
    public static int GameTimer = 60;
    public static float SpawnFrequency = 7;
    public static bool CanSpawnPowerUps = true;
    public static bool CanRumble = true;


    // Start is called before the first frame update
    private void Start()
    {
        Time.timeScale = 1f;
        roundOver = false;
        InitializeGame();
        PlayerSelectScript.arePlayersReady = false;
    }

    // Update is called once per frame
    void Update()
    {

        foreach (PlayerStatus player in playerList)
        {
            if (player.isOut == true)
            {
                playerList.Remove(player);
            }
        }

        if (playerList.Count == 1)
        {

            Color winnercolor = playerList[0].GetComponent<PlayerStatus>().MapacheColor;
            string winner = playerList[0].PlayerName;
            WinnerScreen.SetActive(true);
            WinnerText.text = winner + " Wins!";
            WinnerColor.color = winnercolor;
            Softlock = false;
            timer.Stop();
            Time.timeScale = 1 * timepercentage;

            if (winner == "Player 1" && !roundOver)
            {
                RoundsWonP1++;
                roundOver = true;

                for (int i = 0; i < RoundsWonP1; i++)
                {
                    wonRounds[i].gameObject.SetActive(true);
                }

                Invoke("RestartGame", 5 * timepercentage);
            }
            if (winner == "Player 2" && !roundOver)
            {
                RoundsWonP2++;
                roundOver = true;

                for (int i = 0; i < RoundsWonP2; i++)
                {
                    wonRounds[i].gameObject.SetActive(true);
                }

                Invoke("RestartGame", 5 * timepercentage);
            }
            if (winner == "Player 3" && !roundOver)
            {
                RoundsWonP3++;
                roundOver = true;

                for (int i = 0; i < RoundsWonP3; i++)
                {
                    wonRounds[i].gameObject.SetActive(true);
                }

                Invoke("RestartGame", 5 * timepercentage);
            }
            if (winner == "Player 4" && !roundOver)
            {
                RoundsWonP4++;
                roundOver = true;

                for (int i = 0; i < RoundsWonP4; i++)
                {
                    wonRounds[i].gameObject.SetActive(true);
                }

                Invoke("RestartGame", 5 * timepercentage);
            }

            CheckForWinner();
        }

        if (playerList.Count == 0 && Softlock && !debug)
        {
            WinnerScreen.SetActive(true);
            WinnerText.text = "That was literally frame perfect, HOW. No one Wins";
            WinnerColor.color = Color.grey;
            Invoke("RestartGame", 5);
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
        //AddPlayers();
        Setup();
        ResetVariables();
    }

    public void ResetVariables()
    {
        foreach (GameObject player in players)
        {
            player.GetComponent<MovementHandler>().canDash = true;
            player.GetComponent<PlayerPowerupStorage>().MassReset();
        }
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
        Player1 = null;
        Player2 = null;
        Player3 = null;
        Player4 = null;
    }

    public void AddPlayers()
    {
        if (GameObject.FindGameObjectWithTag("Player1"))
        {
            players.Add(GameObject.FindGameObjectWithTag("Player1"));
            Player1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerMovement>();
        }
        if (GameObject.FindGameObjectWithTag("Player2"))
        {
            players.Add(GameObject.FindGameObjectWithTag("Player2"));
            Player2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerMovement>();
        }
        if (GameObject.FindGameObjectWithTag("Player3"))
        {
            players.Add(GameObject.FindGameObjectWithTag("Player3"));
            Player3 = GameObject.FindGameObjectWithTag("Player3").GetComponent<PlayerMovement>();
        }
        if (GameObject.FindGameObjectWithTag("Player4"))
        {
            players.Add(GameObject.FindGameObjectWithTag("Player4"));
            Player4 = GameObject.FindGameObjectWithTag("Player4").GetComponent<PlayerMovement>();
        }
    }
    
    public static void AddPercentage(int num, float percentage)
    {
        if (num == 1)
        {
            DirtP1 += percentage;

            if (DirtP1 >= MaxDirtPercentage && DirtCap)
            {
                DirtP1 = MaxDirtPercentage;
            }
            else if (!DirtCap)
            {
                DirtP1 *= 2;
            }
        }
        if (num == 2)
        {
            DirtP2 += percentage;

            if (DirtP2 >= MaxDirtPercentage && DirtCap)
            {
                DirtP2 = MaxDirtPercentage;
            }
            else if (!DirtCap)
            {
                DirtP2 *= 2;
            }
        }
        if (num == 3)
        {
            DirtP3 += percentage;

            if (DirtP3 >= MaxDirtPercentage && DirtCap)
            {
                DirtP3 = MaxDirtPercentage;
            }
            else if (!DirtCap)
            {
                DirtP3 *= 2;
            }
        }
        if (num == 4)
        {
            DirtP4 += percentage;

            if (DirtP4 >= MaxDirtPercentage && DirtCap)
            {
                DirtP4 = MaxDirtPercentage;
            }
            else if (!DirtCap)
            {
                DirtP4 *= 2;
            }
        }
    }

    public static void StartStun(int num, float stuntime)
    {
        if (stuntime == 0)
        {
            return;
        }
        if (num == 1)
        {
            Player1.EnableStun(stuntime);
        }
        if (num == 2)
        {
            Player2.EnableStun(stuntime);
        }
        if (num == 3)
        {
            Player3.EnableStun(stuntime);
        }
        if (num == 4)
        {
            Player4.EnableStun(stuntime);
        }
    }

    public void Setup()
    {
        foreach (GameObject player in players)
        {
            //playerList.Add(player.GetComponent<PlayerStatus>());
            //player.GetComponent<PlayerMovement>().enabled = true;
            player.GetComponent<PlayerStatus>().isOut = false;
        }
        DirtP1 = 1;
        DirtP2 = 1;
        DirtP3 = 1;
        DirtP4 = 1;
    }
}
