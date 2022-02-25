using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemies")]
    public Enemy fireEnemy;
    public Enemy iceEnemy;
    [HideInInspector]
    public Enemy enemyInScene;
    
    public static int numberOfEnemies = 5; // How many enemies in the level?

    [Header("Spawn Points")]
    public GameObject spawnPoint; // Location for each enemy to spawn

    [Header("Arrays of Enemy Types & Spawnable Enemies")]
    private Enemy[] enemies = new Enemy[2]; // array to store enemies that we can add to
    private Enemy[] enemiesToSpawn = new Enemy[numberOfEnemies]; // array of level's spawnable enemies

    [Header("Timing and Rand Numbers")]
    private CountdownTimer countdownTimer;
    private int randEnemy; // Allows for random spawning
    public Text enemiesRemainingText;

    void Start()
    {
        countdownTimer = FindObjectOfType<CountdownTimer>();
        enemies[0] = fireEnemy; // TODO: Update if more enemies are added
        enemies[1] = iceEnemy;

        // Add the enemies to the array of enemies
        // that will be spawned for the level
        for (int i = 0; i < numberOfEnemies; i++)
        {
            randEnemy = Random.Range(1, enemies.Length + 1); // Get a random enemy
            enemiesToSpawn[i] = enemies[randEnemy - 1]; // Put random number in the spawn array
        }
        enemiesRemainingText.text = string.Format("{0} enemies left", numberOfEnemies);
    }

    // This function just spawns enemy,
    // and then decreases number of enemies
    // left in the level, resetting the countdown to spawn
    public void SpawnEnemy()
    {
        enemyInScene = Instantiate(enemiesToSpawn[numberOfEnemies - 1], spawnPoint.transform.position, spawnPoint.transform.rotation);
        numberOfEnemies--;
        Debug.Log("Enemies left: " + numberOfEnemies);
        enemiesRemainingText.text = string.Format("{0} enemies left", numberOfEnemies);
        countdownTimer.timerIsRunning = false;
    }
}