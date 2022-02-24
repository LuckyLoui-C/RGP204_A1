using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header ("Enemy Attributes")]
    public string type;
    public int HP = 1;

    void Update()
    {
        if (HP <= 0)
        {
            this.GetComponent<SpriteRenderer>().sprite = null; // Replace with particle effect
            Destroy(this.gameObject);
        }
    }
}