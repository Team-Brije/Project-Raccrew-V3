using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPowerupStorage : MonoBehaviour
{
    MovementHandler player;
    Animator animator;
    GameObject prefabtospawn;
    GameObject placeholderprefab;
    int Times;

    [HideInInspector] public bool hasobject = false;
    [HideInInspector] public int ID; //0 = back, 1 = front
    [HideInInspector] public string AnimName;
    [HideInInspector] public bool hasAnim = false;
    [HideInInspector] public string playerTag;

    Transform objectspawnback;
    Transform objectspawnfront;
    

    DeletePlaceholder delobj0;
    DeletePlaceholder delobj1;

    public GameObject front;
    public GameObject back;

    int id;

    private void OnEnable()
    {
        InputHandler.OnAbility += Abilty;
    }

    private void OnDisable()
    {
        InputHandler.OnAbility -= Abilty;
    }

    private void Start()
    {
        playerTag = gameObject.tag;
        player = GetComponent<MovementHandler>();
        animator = GetComponent<Animator>();
        objectspawnfront = front.transform;
        objectspawnback = back.transform;
        delobj0 = back.GetComponent<DeletePlaceholder>();
        delobj1 = front.GetComponent<DeletePlaceholder>();
        id = player.playerId;
    }

    public void StartAnim(string name)
    {
        animator.Play(name);
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

    public void MassReset()
    {
        ResetAnims();
        ResetObjects();
        player.initialspeed = player.speed;
        player.transform.localScale = new Vector3(1, 1, 1);
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
        if(delobj0 != null)
        delobj0.DeleteObjects();
        if(delobj1 != null)
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
            //Debug.Log("Shot Fired");
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

    public void UseObject()
    {
        if(hasobject)
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

    public void PlayAnim()
    {
        if (hasAnim)
        {
            animator.Play(AnimName);
            hasAnim = false;
        }
    }

    public void Abilty(int idhandler)
    {
        if (id == idhandler)
        {
            UseObject();
            PlayAnim();
        }
    }

    public void ChangePosition(GameObject playerPos, int duration)
    {
        StartCoroutine(MeteorTime(duration, playerPos));
        
    }
    public IEnumerator MeteorTime(int duration, GameObject playerPos)
    {
        player.transform.position = playerPos.transform.position;
        Rigidbody rb = player.GetComponent<Rigidbody>();
        rb.useGravity = false;
        yield return new WaitForSeconds(duration);
        rb.useGravity = true;
    }
}
