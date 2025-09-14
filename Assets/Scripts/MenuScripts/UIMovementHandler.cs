using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIMovementHandler : MonoBehaviour
{
    public int playerId;
    bool confirmationBool;
    public float[] ypos;
    int arrpos;
    float timer;
    public MovementHandler movementHandler;
    public GameObject playerUI;
    public GameObject characterselectUI;
    float fillamount;
    public Image image;
    float fullAmount;

    public CharacterSelectItemStorage[] itemStorages;
    private void OnEnable()
    {
        InputHandler.OnUp += MoveUp;
        InputHandler.OnDown += MoveDown;
        InputHandler.OnConfirm += Confirm;
    }

    private void OnDisable()
    {
        InputHandler.OnUp -= MoveUp;
        InputHandler.OnDown -= MoveDown;
        InputHandler.OnConfirm -= Confirm;
    }

    // Start is called before the first frame update
    void Start()
    {
        confirmationBool = false;
        fullAmount = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerSelectScript.arePlayersReady = false;
        transform.localPosition = new Vector3(0, Mathf.Lerp(1, ypos[arrpos], 100),0);
        if ( confirmationBool )
        {
            timer += Time.deltaTime;
            fillamount = timer / fullAmount;

            image.fillAmount = fillamount;
            if ( timer >= fullAmount)
            {
                foreach (var item in itemStorages)
                {
                    item.SetAttribute();
                }
                movementHandler.canMove = true;
                if (PlayerSelectScript.NumOfPlayers > 1) { PlayerSelectScript.arePlayersReady = true; }
                playerUI.SetActive(false);
                characterselectUI.SetActive(false);
                gameObject.SetActive(false);
            }
        }
        else
        {
            timer = 0;
            image.fillAmount = 0;
        }
    }

    public void Confirm(int id, bool isConfirming)
    {
        if(id == playerId)
        {
            confirmationBool = isConfirming;
        }
    }

    public void MoveUp(int id)
    {
        if (id != playerId) { return; }
        if (arrpos >= ypos.Length -1) { arrpos = 0; }
        else { arrpos++; } 
    }

    public void MoveDown(int id)
    {
        if(id != playerId) { return; }
        if (arrpos <= 0) { arrpos = ypos.Length -1; }
        else { arrpos--; }
    }


}
