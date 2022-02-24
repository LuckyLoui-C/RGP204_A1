using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudSpawner : MonoBehaviour
{
    // Have children spawn randomly within certain distances of the parent
    // Spawn no higher than 5 and no lower than 1 
    // Y -1, 5
    // X -13
    float spawnRate = 10.0f;
    float rand;
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        rand = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Countdown 10 seconds
        if (spawnRate > 0)
        {
            spawnRate -= Time.deltaTime;
        }
        else spawnRate = 10.0f;

        // Spawn every 9.5ish seconds (sometimes)
        if (spawnRate > 0.559f && spawnRate < 0.56)
        {
            rand = Random.Range(1.0f, 5.0f);
            Instantiate(prefab, new Vector3(-13, rand, 0), Quaternion.identity);
        }
    }
}
