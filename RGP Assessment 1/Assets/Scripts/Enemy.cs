using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header ("Enemy Attributes")]
    public string type;
    public int HP = 1;

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            this.GetComponent<SpriteRenderer>().sprite = null;
            Destroy(this.gameObject);
        }
    }
}