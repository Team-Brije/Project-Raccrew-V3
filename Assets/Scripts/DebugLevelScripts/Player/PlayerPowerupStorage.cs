using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPowerupStorage : MonoBehaviour
{
    PlayerMovement player;
    Animator animator;
    public Transform objectspawnback;
    public Transform objectspawnfront;
    [HideInInspector]public bool hasobject = false;
    [HideInInspector]public int ID; //0 = back, 1 = front
    public DeletePlaceholder delobj0;
    public DeletePlaceholder delobj1;


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
        if(!hasobject && ID == 0)
        {
            Instantiate(placeholderprefab, objectspawnback);
            delobj1.DeleteObjects();
            hasobject = true;
        }
        if (!hasobject && ID == 1)
        {
            Instantiate(placeholderprefab, objectspawnfront);
            delobj0.DeleteObjects();
            hasobject = true;
        }
    }

    public void SpawnTrueObject()
    {
        if (ID == 0)
        {
            Vector3 position = objectspawnback.position;
            Instantiate(prefabtospawn,position,Quaternion.identity);
        }
        if (ID == 1)
        {
            Vector3 position = objectspawnfront.position;
            Instantiate(prefabtospawn, position, Quaternion.identity);
        }
        hasobject = false;
    }

    public void UseObject(InputAction.CallbackContext context)
    {
        if(context.performed && hasobject)
        {
            SpawnTrueObject();
            if(ID == 0)
            {
                delobj0.DeleteObjects();
            }
            if(ID == 1)
            {
                delobj1.DeleteObjects();
            }
        }
    }
}
