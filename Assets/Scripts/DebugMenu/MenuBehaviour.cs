using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour
{
    public int speedDemo = 5;
    public int dashSpeedDemo = 10;

    public GameObject menu;
    private bool menuActive = true;

    public GameManager gameManager;

    public TextMeshProUGUI[] roundswon;

    public TextMeshProUGUI phantomModeOn;
    public TextMeshProUGUI phantomModeOff;

    public TextMeshProUGUI speed;

    public TextMeshProUGUI dashSpeed;

    public GameObject PlayerUI;
    public GameObject InitializePlayersButton;

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

        speed.text = speedDemo.ToString();
        dashSpeed.text = dashSpeedDemo.ToString();
    }   

    public void ReloadScene()
    {
        string current = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(current);
    }

    public void InitializePlayers()
    {
        gameManager.InitializeGame();
        InitializePlayersButton.SetActive(false);
    }

    public void DisableUI()
    {
        PlayerUI.SetActive(false);
    }

    public void PhantomModeOn()
    {
        phantomModeOff.color = Color.white;
        phantomModeOn.color = Color.green;
    }
    public void PhantomModeOff()
    {
        phantomModeOff.color = Color.green;
        phantomModeOn.color = Color.white;
    }

    public void SpeedUp()
    {
        speedDemo ++; 
    }

    public void SpeedDown()
    {
        speedDemo --;
    }

    public void DashSpeedUp()
    {
        dashSpeedDemo ++;
    }

    public void DashSpeedDown()
    {
        dashSpeedDemo --;
    }
}
