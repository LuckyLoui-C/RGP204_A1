using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    [HideInInspector]
    public EnemySpawner enemySpawner;
    [HideInInspector]
    public Game_Manager gameManager;
    [HideInInspector]
    public Text timeText;

    public bool timerIsRunning = false;
    public float timeToSpawn = 5.0f; // How long before next enemy spawn

    void Start()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>(); // Reference the spawner
        gameManager = FindObjectOfType<Game_Manager>(); // Reference game manager in scene
        timeText = FindObjectOfType<CountdownTimer>().GetComponent<Text>(); // Reference timer text
        timerIsRunning = true; // Start the timer
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (gameManager.gameIsRunning)
            {
                timeToSpawn -= Time.deltaTime; // Every frame, minus deltaTime from remaining time, counts down.
                DisplayTime(timeToSpawn);
                if (timeToSpawn <= 0)
                {
                    enemySpawner.SpawnEnemy();
                    timeToSpawn = 5.0f;
                }
            }
            else
            {
                Debug.Log("Time ran out");
                //timeRemaining = 0;
                //gameManager.player.GetComponent<PlayerHealth>().Die("Time ran out! :(");
                timerIsRunning = false;
            }
        }
        else
            timeText.text = string.Format("'Spell' out the spell :)");
    }
    void DisplayTime(float timeToDisplay) // TODO: Timer UI
    {
        timeToDisplay += 1;

        //float minutes = Mathf.FloorToInt(timeToDisplay / 60); // Divide by 60 to get min. remaining
        float seconds = Mathf.FloorToInt(timeToDisplay % 60); // Modulus 60 to get sec. remaining

        timeText.text = string.Format("Next enemy in: {0:0}", seconds);
    }
}