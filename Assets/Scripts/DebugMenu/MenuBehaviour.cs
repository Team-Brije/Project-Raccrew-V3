using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour
{

    public GameObject menu;
    private bool menuActive = true;

    public GameManager gameManager;

    public TextMeshProUGUI[] roundswon;

    [Header("Speed & Dash Variables")]
    public TextMeshProUGUI dashSpeed;
    public TextMeshProUGUI speed;

    public GameObject PlayerUI;
    public GameObject InitializePlayersButton;

    public List<GameObject> players;

    public Countdown countdown;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U) && menuActive)
        {
            menu.SetActive(false);
            menuActive = false;
        }
        else if (Input.GetKeyDown(KeyCode.U) && !menuActive)
        {
            menu.SetActive(true);
            menuActive = true;
        }

        roundswon[0].text = GameManager.RoundsWonP1.ToString();
        roundswon[1].text = GameManager.RoundsWonP2.ToString();
        roundswon[2].text = GameManager.RoundsWonP3.ToString();
        roundswon[3].text = GameManager.RoundsWonP4.ToString();

        if(players != null)
        {
            dashSpeed.text = players[0].GetComponent<PlayerMovement>().dashPercentageBoost.ToString();
            speed.text = players[0].GetComponent<PlayerMovement>().initialspeed.ToString();
        }
    }   

    public void ReloadScene()
    {
        
        SceneManager.LoadScene("DebugCleanser");
    }

    public void InitializePlayers()
    {
        gameManager.InitializeGame();
        AddPlayers();
        InitializePlayersButton.SetActive(false);
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

    public void DisableUI()
    {
        PlayerUI.SetActive(false);
    }

    public void DashSpeedUp()
    {
        foreach (GameObject player in players)
        {
            player.GetComponent<PlayerMovement>().dashPercentageBoost += .1f;
        }
    }

    public void DashSpeedDown()
    {
        foreach (GameObject player in players)
        {
            player.GetComponent<PlayerMovement>().dashPercentageBoost -= .1f;
        }
    }

    public void SpeedUp()
    {
        foreach (GameObject player in players)
        {
            player.GetComponent<PlayerMovement>().initialspeed += 10f;
        }
    }

    public void SpeedDown()
    {
        foreach (GameObject player in players)
        {
            player.GetComponent<PlayerMovement>().initialspeed -= 10f;
        }
    }

    public void StopTimer()
    {
        countdown.Stop();
    }

    public void ContinueTimer()
    {
        countdown.Begin();
    }

}
