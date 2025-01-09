using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesSpawn : MonoBehaviour
{
    public Vector2 minRangeSpawn;
    public Vector2 maxRangeSpawn;
    public GameObject spikePrefab;
    private float time;

    // Start is called before the first frame update
    void Start(){
        SpawnerPowerUp.SpawnPowerUpTimerBool = false;
        time = 2;
        StartCoroutine(SpikeSpawnTime());
    }
    private IEnumerator SpikeSpawnTime(){
        while(true) {
            Vector3 finalSpawn = new Vector3 (Random.Range (minRangeSpawn.x,maxRangeSpawn.x),0,Random.Range(minRangeSpawn.y,maxRangeSpawn.y));
            Instantiate(spikePrefab,finalSpawn,Quaternion.identity);
            if(time > 0){
            yield return new WaitForSeconds(time);
            time = time-0.2f;
            }else{
                yield return new WaitForSeconds(0.2f);
            }
        }
    }
}
