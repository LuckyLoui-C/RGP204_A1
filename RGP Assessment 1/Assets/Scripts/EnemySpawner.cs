using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemies")]
    public Enemy fireEnemy;
    public Enemy iceEnemy;

    [Header("Spawn Points")]
    public GameObject spawnPoint;

    private Enemy[] enemies = new Enemy[2]; // array to store enemies that we can add to
    
    private float timeToSpawn; // How long before next enemy spawn
    private int randEnemy; // Allows for random spawning

    // Start is called before the first frame update
    void Start()
    {
        timeToSpawn = 3.0f;
        // Add the enemies to the enemy array for spawning
        enemies[0] = fireEnemy;
        enemies[1] = iceEnemy;
    }

    // Update is called once per frame
    void Update()
    {
        randEnemy = Random.Range(0, enemies.Length + 1);
        
        timeToSpawn -= 1.0f * Time.deltaTime; // countdown 1 second each second
        
        if (timeToSpawn <= 0.0f)
        {
            Instantiate(enemies[randEnemy], spawnPoint.transform.position, spawnPoint.transform.rotation);
            timeToSpawn = 5.0f;
        }
        Debug.Log("Time to spawn: " + timeToSpawn);
    }
}