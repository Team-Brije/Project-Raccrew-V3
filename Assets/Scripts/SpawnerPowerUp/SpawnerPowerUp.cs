using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerPowerUp : MonoBehaviour
{
    public List<GameObject> SpawnPoints = new List<GameObject>();
    public Vector3 minRange;
    public Vector3 maxRange;
    public float spawnTime;
    public GameObject powerPrefab;
    private float actTime;
    
    void Start(){
        ResetTime();
    }
    void Update()
    {
        NextSpawnTimer();
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
        Instantiate(powerPrefab, SpawnPoints[Random.Range(0,SpawnPoints.Count)].transform);
    }
    public void RangeSpawn(){
        Vector3  position = new Vector3(Random.Range(minRange.x,maxRange.x),Random.Range(minRange.y,maxRange.y),Random.Range(minRange.z,maxRange.z));
        Instantiate(powerPrefab, position, Quaternion.identity);
    }
    public void ResetTime(){
        actTime = spawnTime;
    }
}
