using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIMovementHandler : MonoBehaviour
{
    public int playerId;
    bool confirmationBool;
    public float[] ypos;
    int arrpos;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(0, Mathf.Lerp(1, ypos[arrpos], 100),0);
    }

    public void Confirm(int id, bool isConfirming)
    {

    }

    public void MoveUp(int id)
    {
        if (arrpos >= ypos.Length -1) { arrpos = 0; }
        else { arrpos++; } 
    }

    public void MoveDown(int id)
    {
        if (arrpos <= 0) { arrpos = ypos.Length -1; }
        else { arrpos--; }
    }


}
