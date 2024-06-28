using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPowerupStorage : MonoBehaviour
{
    PlayerMovement player;
    Animator animator;
    public Transform objectspawn;
    [HideInInspector]public bool hasobject = false;

    GameObject prefabtospawn;
    GameObject placeholderprefab;
    private void Start()
    {
        player = GetComponent<PlayerMovement>();
        //animator = GetComponent<Animator>();
    }

    public void StartAnim(string name)
    {
        animator.Play(name);
    }

    public void ChangeSpeed(float speed, int duration)
    {
        StartCoroutine(Timer(duration, speed));
    }

    public IEnumerator Timer(int duration, float speed)
    {
        float originalspeed = player.initialspeed;
        player.initialspeed = speed * originalspeed;
        yield return new WaitForSeconds(duration);
        player.initialspeed = originalspeed;
    }

    public void SetObjects(GameObject prefabtospawn1, GameObject placeholderprefab1)
    {
        prefabtospawn = prefabtospawn1;
        placeholderprefab = placeholderprefab1;
    }

    public void SpawnObject()
    {
        if(!hasobject)
        {
            Instantiate(placeholderprefab, objectspawn);
            hasobject = true;
        }
    }

    public void SpawnTrueObject()
    {
        Instantiate(prefabtospawn);

    }

    public void UseObject(InputAction.CallbackContext context)
    {
        if(context.performed && hasobject)
        {
            SpawnTrueObject();
        }
    }
}
