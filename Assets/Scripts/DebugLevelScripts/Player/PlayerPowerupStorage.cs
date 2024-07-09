using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPowerupStorage : MonoBehaviour
{
    PlayerMovement player;
    Animator animator;
    GameObject prefabtospawn;
    GameObject placeholderprefab;
    int Times;

    [HideInInspector] public bool hasobject = false;
    [HideInInspector] public int ID; //0 = back, 1 = front
    [HideInInspector] public string AnimName;
    [HideInInspector] public bool hasAnim = false;

    public Transform objectspawnback;
    public Transform objectspawnfront;
    public DeletePlaceholder delobj0;
    public DeletePlaceholder delobj1;

    private void Start()
    {
        player = GetComponent<PlayerMovement>();
        //animator = GetComponent<Animator>();
    }

    public void StartAnim(string name)
    {
        //animator.Play(name);
        AnimName = name;
    }

    public void ChangeScale(float scale, int duration)
    {
        StartCoroutine(ScaleTimer(duration, scale));
    }

    public void ChangeSpeed(float speed, int duration)
    {
        StartCoroutine(SpeedTimer(duration, speed));
    }

    public IEnumerator ScaleTimer(int duration, float scale)
    {
        Vector3 vector3 = new Vector3(scale, scale, scale);
        player.transform.localScale = vector3;
        yield return new WaitForSeconds(duration);
        player.transform.localScale = new Vector3(1,1,1);
    }

    public IEnumerator SpeedTimer(int duration, float speed)
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

    public void SpawnObject(int TimesSpawned)
    {
        Times = TimesSpawned;   
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

    public void ResetObjects()
    {
        hasobject = false;
        delobj0.DeleteObjects();
        delobj1.DeleteObjects();
        placeholderprefab = null;
        prefabtospawn = null;
    }

    public void ResetAnims()
    {
        hasAnim = false;
        AnimName = null;
    }

    public IEnumerator WaitForWave(Vector3 POS,Quaternion ROT)
    {
        for (int i = 0; i < Times; i++)
        {
            Debug.Log("Shot Fired");
            Instantiate(prefabtospawn, POS, ROT);
            yield return new WaitForSeconds(1);
        }
    }

    public void SpawnTrueObject()
    {
        if (ID == 0)
        {
            Vector3 position = objectspawnback.position;
            Quaternion rotation = objectspawnback.rotation;
            StartCoroutine(WaitForWave(position, rotation));
        }
        if (ID == 1)
        {
            Vector3 position = objectspawnfront.position;
            Quaternion rotation = objectspawnfront.rotation;
            StartCoroutine(WaitForWave(position, rotation));            
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

    public void PlayAnim(InputAction.CallbackContext context)
    {
        if (context.performed && hasAnim)
        {
            animator.Play(AnimName);
            hasAnim = false;
        }
    }

}
