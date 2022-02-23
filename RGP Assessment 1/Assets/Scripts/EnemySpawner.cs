using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy fireEnemy;
    public Enemy iceEnemy;

    public float timeToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        timeToSpawn = 3.0f;
        iceEnemy.transform.position.Set(0.0f,0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        timeToSpawn -= 1.0f * Time.deltaTime;
        Debug.Log(timeToSpawn);
        if (timeToSpawn <= 0.0f)
        {
            Instantiate(iceEnemy);
            timeToSpawn = 5.0f;
        }
    }
}
