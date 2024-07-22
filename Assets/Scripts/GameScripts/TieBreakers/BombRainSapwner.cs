using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombRainSapwner : MonoBehaviour
{
    public Vector2 minRangeSpawn;
    public Vector2 maxRangeSpawn;
    public float heightSpawn;
    public GameObject bombPrefab;
    private float time;
    void Start(){
        SpawnerPowerUp.SpawnPowerUpTimerBool = false;
        time = 2;
        StartCoroutine(BombSpawnTime());
    }
    private IEnumerator BombSpawnTime(){
        while(true) {
            Vector3 finalSpawn = new Vector3 (Random.Range (minRangeSpawn.x,maxRangeSpawn.x),heightSpawn,Random.Range(minRangeSpawn.y,maxRangeSpawn.y));
            Instantiate(bombPrefab,finalSpawn,Quaternion.identity);
            if(time > 0){
            yield return new WaitForSeconds(time);
            time = time-0.2f;
            }else{
                yield return new WaitForSeconds(0.2f);
            }
        }
    }
}
