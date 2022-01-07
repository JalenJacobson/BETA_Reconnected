using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
     public GameObject[] objects;                // The prefab to be spawned.
     public float spawnTime = 6f;            // How long between each spawn.
     private Vector3 spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
       InvokeRepeating ("Spawn", spawnTime, spawnTime); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
         void Spawn ()
     {
         spawnPosition.x = Random.Range (-174, -146);
         spawnPosition.y = 26f;
         spawnPosition.z = Random.Range (-96, -123);
 
         Instantiate(objects[UnityEngine.Random.Range(0, objects.Length - 1)], spawnPosition, Quaternion.identity);
     }
}
