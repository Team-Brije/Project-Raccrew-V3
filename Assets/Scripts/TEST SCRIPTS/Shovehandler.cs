using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovehandler : MonoBehaviour
{
    [Header("Event Listener Variables")]
    MovementHandler player;
    public int playerId;

    [Header("Shove Variables")]
    [HideInInspector] public bool isShoving = false;
    [HideInInspector] public bool isMoving;
    public float stunTime;
    public Collider shoveCollider;

    private void OnEnable() {
        InputHandler.OnShove += Shove;
    }
    private void OnDisable() {
        InputHandler.OnShove -= Shove;
    }
    private void Start() {
        player = GetComponent<MovementHandler>();
        playerId = player.playerId;
    }
    public void Shove(int id){
        if(id==playerId){
            StartCoroutine(shoveActivator());
            StartCoroutine(lawbringer());
        }
    }
    public IEnumerator lawbringer()
    {
        isShoving = true;
        yield return new WaitForSeconds(1.6f);
        isShoving = false;
    }
    public void StartStun()
    {
        StartCoroutine(StunTimer());
    }
    public IEnumerator StunTimer()
    {
        isMoving = false;
        yield return new WaitForSeconds(stunTime);
        isMoving = true;
    }
    public IEnumerator shoveActivator(){
        shoveCollider.enabled=true;  
        yield return new WaitForSeconds(0.9f);
        shoveCollider.enabled=false;
    }
}
