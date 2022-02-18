using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Game_Manager : MonoBehaviour
{
    public enum State
    {
        Idle,
        Dot,
        Dash
    }

    float countDown = 10.0f;
    public Text disvar;
    bool isDash = false;

    void Start()
    {
        
    }

 
    void Update()
    {
        // Timer Script
        if (countDown > 0)
        {
            countDown -= Time.deltaTime;
        }
        double b = System.Math.Round(countDown, 2);
        disvar.text = b.ToString();

        //if (countDown < 0)
        //{
        //    Debug.Log("Completed");
        //}


        // Inputs
        // Start the counter on space key down 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            countDown = 0.5f;
        }
        
        // Detect Dashes and Dots
        // Dash (holding space)
        if (Input.GetKeyUp(KeyCode.Space) && countDown > 0 && countDown < 0.3f)
        {
            Debug.Log("Dash");
        }
        // Dots (tapping space)
        if (Input.GetKeyUp(KeyCode.Space) && countDown > 0.3f)
        {
            Debug.Log("Dot");
        }
    }
}
