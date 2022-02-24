using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemies")]
    public Enemy fireEnemy;
    public Enemy iceEnemy;
    
    public static int numberOfEnemies = 5; // How many enemies in the level?

    [Header("Spawn Points")]
    public GameObject spawnPoint; // Location for each enemy to spawn

    [Header("Arrays of Enemy Types & Spawnable Enemies")]
    private Enemy[] enemies = new Enemy[2]; // array to store enemies that we can add to
    private Enemy[] enemiesToSpawn = new Enemy[numberOfEnemies]; // array of level's spawnable enemies
    
    [Header("Timing and Rand Numbers")]
    public float timeToSpawn = 5.0f; // How long before next enemy spawn
    private int randEnemy; // Allows for random spawning

    void Start()
    {
        enemies[0] = fireEnemy; // TODO: Update if more enemies are added
        enemies[1] = iceEnemy;

        // Add the enemies to the array of enemies
        // that will be spawned for the level
        for (int i = 0; i < numberOfEnemies; i++)
        {
            randEnemy = Random.Range(1, enemies.Length + 1); // Get a random enemy

            enemiesToSpawn[i] = enemies[randEnemy - 1]; // Put random number in the spawn array
        }
    }

    void Update()
    {
        timeToSpawn -= 1.0f * Time.deltaTime; // countdown 1 second
        
        // This if statement just spawns enemy,
        // and then decreases number of enemies
        // left in the level, resetting the countdown to spawn
        if (timeToSpawn <= 0.0f)
        {
            Instantiate(enemiesToSpawn[numberOfEnemies - 1], spawnPoint.transform.position, spawnPoint.transform.rotation);
            timeToSpawn = 5.0f;
            numberOfEnemies--;
        }
        Debug.Log("Time to spawn: " + timeToSpawn);
        Debug.Log("Enemies left: " + numberOfEnemies);
    }
}