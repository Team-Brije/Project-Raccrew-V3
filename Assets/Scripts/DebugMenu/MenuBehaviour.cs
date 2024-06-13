using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuBehaviour : MonoBehaviour
{
    public int speedDemo = 5;
    public int dashSpeedDemo = 10;

    public GameObject menu;
    private bool menuActive = false;

    public TextMeshProUGUI phantomModeOn;
    public TextMeshProUGUI phantomModeOff;

    public TextMeshProUGUI speed;

    public TextMeshProUGUI dashSpeed;

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

            speed.text = speedDemo.ToString();
        dashSpeed.text = dashSpeedDemo.ToString();
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
