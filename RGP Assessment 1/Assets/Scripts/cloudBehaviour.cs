using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudBehaviour : MonoBehaviour
{
    Vector3 velocity;
    float outOfBounds = 12;
    public GameObject me;

    // Spawn no higher than 5 and no lower than -1 
    // Y -1, 5


    // Slowly Scroll from -13 to 12 in the X
    // X -13 12





    void Start()
    {
        velocity = new Vector3(2f, 0, 0);
        me = gameObject;
    }

    void Update()
    {
        // movement
        transform.position += ( velocity * Time.deltaTime);

        if (transform.position.x >= outOfBounds)
        {
            Destroy(me);
        }
    }
}
