using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPowerUp : MonoBehaviour
{
    public List<GameObject> SpawnPoints = new List<GameObject>();
    public Vector3 minRange;
    public Vector3 maxRange;
    public List<ScriptableObjPower> PowerUps;
    public GameObject powerPrefab; 
    private float actTime;
    public static bool SpawnPowerUpTimerBool;

    void Start(){
        ResetTime();
        SpawnPowerUpTimerBool = GameManager.CanSpawnPowerUps;
    }
    void Update()
    {
        if (SpawnPowerUpTimerBool)
        {
            NextSpawnTimer();
        }
    }
    public void NextSpawnTimer(){
        actTime -= Time.deltaTime;
        if(actTime <= 0){
            if(SpawnPoints.Count != 0){
                PointsSpawn();
                ResetTime();
            }else{
                RangeSpawn();
                ResetTime();
            }
        }
    }

    public void PointsSpawn(){        
        SelectPowerUp();
        Instantiate(powerPrefab, SpawnPoints[Random.Range(0,SpawnPoints.Count)].transform);
    }
    public void RangeSpawn(){
        SelectPowerUp();
        Vector3  position = new Vector3(Random.Range(minRange.x,maxRange.x),Random.Range(minRange.y,maxRange.y),Random.Range(minRange.z,maxRange.z));
        Instantiate(powerPrefab, position, Quaternion.identity);
    }
    public void ResetTime(){
        actTime = GameManager.SpawnFrequency;
    }

    public void SelectPowerUp()
    {
        powerPrefab.GetComponentInChildren<PowerUpPrefabAssigner>()._powerUp = PowerUps[Random.Range(0, PowerUps.Count)];
    }
}
