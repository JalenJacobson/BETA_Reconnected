using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
     public GameObject[] mines; 
     public GameObject[] batteries;               // The prefab to be spawned.
     public float spawnTime = 6f;            // How long between each spawn.
     public Vector3 spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // void OnTriggerEnter(Collider other)
    // {
    //     if(other.name == "IdleLuz" || other.name == "Brute" || other.name == "SatBot" || other.name == "Pump" || other.name == "Gears")
    //     {
    //         InvokeRepeating ("Spawn", spawnTime, spawnTime);
    //     }
    // }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn1()
     {
         spawnPosition.x = Random.Range (-39, 15);
         spawnPosition.y = 26f;
         spawnPosition.z = Random.Range (-31, -43);
 
         Instantiate(mines[UnityEngine.Random.Range(0, mines.Length - 1)], spawnPosition, Quaternion.identity);
     }
     void Spawn2()
     {
         spawnPosition.x = Random.Range (-39, 15);
         spawnPosition.y = 26f;
         spawnPosition.z = Random.Range (-13, 1);
 
         Instantiate(mines[UnityEngine.Random.Range(0, mines.Length - 1)], spawnPosition, Quaternion.identity);
     }
     void batterySpawn1()
     {
         spawnPosition.x = Random.Range (-39, 15);
         spawnPosition.y = 26f;
         spawnPosition.z = Random.Range (-31, -43);
 
         Instantiate(batteries[UnityEngine.Random.Range(0, batteries.Length - 1)], spawnPosition, Quaternion.identity);
     }
     void batterySpawn2()
     {
         spawnPosition.x = Random.Range (-39, 15);
         spawnPosition.y = 26f;
         spawnPosition.z = Random.Range (-13, 1);
 
         Instantiate(batteries[UnityEngine.Random.Range(0, batteries.Length - 1)], spawnPosition, Quaternion.identity);
     }
     void Spawn3()
     {
         spawnPosition.x = Random.Range (1, 15);
         spawnPosition.y = 26f;
         spawnPosition.z = Random.Range (-13, -43);
 
         Instantiate(mines[UnityEngine.Random.Range(0, mines.Length - 1)], spawnPosition, Quaternion.identity);
     }
     void Spawn4()
     {
         spawnPosition.x = Random.Range (-27, -39);
         spawnPosition.y = 26f;
         spawnPosition.z = Random.Range (-13, -43);
 
         Instantiate(mines[UnityEngine.Random.Range(0, mines.Length - 1)], spawnPosition, Quaternion.identity);
     }
}
