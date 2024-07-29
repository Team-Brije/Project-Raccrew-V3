using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Power Up", menuName = "PowerUps/Spawn Based PowerUp")]
public class PowerUpSpawn : ScriptableObjPower
{
    public GameObject PrefabToSpawn;
    public GameObject placeholderPrefab;
    public enum AbilityType { StandardSpawn, ComplexSpawnGhost}
    public AbilityType type;

    public static List<string> players = new List<string>();

    public override void Apply(GameObject target)
    {
        if (type == AbilityType.StandardSpawn)
        {
            target.GetComponent<PlayerPowerupStorage>().ResetAnims();
            target.GetComponent<PlayerPowerupStorage>().ID = 0;
            target.GetComponent<PlayerPowerupStorage>().hasobject = false;
            target.GetComponent<PlayerPowerupStorage>().SetObjects(PrefabToSpawn, placeholderPrefab);
            target.GetComponent<PlayerPowerupStorage>().SpawnObject(1);
        }
        if (type == AbilityType.ComplexSpawnGhost)
        {
            SetList();
            string playerShooter = target.GetComponent<PlayerPowerupStorage>().playerTag;
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i] == playerShooter)
                {
                    players.Remove(players[i]);
                }
            }
            Ghost_Navigation[] ghosts = PrefabToSpawn.GetComponentsInChildren<Ghost_Navigation>();
            for (int i = 0;i < ghosts.Length; i++)
            {
                Debug.Log("Start Okay");
                int randNum = Random.Range(0, players.Count);
                string RandomTag = players[randNum];
                ghosts[i].playerTag = RandomTag;
                Debug.Log("Finish Okay");
            }
            Debug.Log("Set Successful");
            target.GetComponent<PlayerPowerupStorage>().ResetAnims();
            target.GetComponent<PlayerPowerupStorage>().ID = 0;
            target.GetComponent<PlayerPowerupStorage>().hasobject = false;
            target.GetComponent<PlayerPowerupStorage>().SetObjects(PrefabToSpawn, placeholderPrefab);
            target.GetComponent<PlayerPowerupStorage>().SpawnObject(1);
        }
    }

    void SetList()
    {
        players.Clear();
        if(PlayerSelectScript.NumOfPlayers >= 2)
        {
            players.Add("Player1");
            players.Add("Player2");
        }
        if (PlayerSelectScript.NumOfPlayers >= 3)
        {
            players.Add("Player3");
        }
        if (PlayerSelectScript.NumOfPlayers == 4)
        {
           players.Add("Player4");
        }
    }
}
