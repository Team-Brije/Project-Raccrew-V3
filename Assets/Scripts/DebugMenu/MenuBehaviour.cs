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

        dashSpeed.text = PlayerMovement.dashPercentageBoost.ToString();
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

    public void DashSpeedUp()
    {
        PlayerMovement.dashPercentageBoost += .1f;
    }

    public void DashSpeedDown()
    {
        PlayerMovement.dashPercentageBoost -= .1f;
    }

    public void StopTimer()
    {
        Countdown.isCountingDown = false;
    }

    public void ContinueTimer()
    {
        Countdown.isCountingDown = true;
    }

}
