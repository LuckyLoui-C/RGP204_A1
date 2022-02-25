using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Game_Manager : MonoBehaviour
{
    public Enemy enemy;
    [HideInInspector]
    public CountdownTimer countdownTimer;
    public bool gameIsRunning;

    public enum State
    {
        Idle,
        Dot,
        Dash
    }

    public Text timer;
    public Text dotsDashesUI;
    public Text underline1;
    public Text underline2;
    public Text underline3;
    public Text underline4;
    public Text input1;
    public Text input2;
    public Text input3;
    public Text input4;

    public Text[] inputs;

    int currentInput = 0;

    float countDown = 0.5f;
    float sixtySecondTimer = 60.0f;
    bool isDash = false;

    int[] inputArray;

    void Start()
    {
        // Create an array to store our inputs (dots and dashes)
        // no input = 0
        // dot = 1
        // dash = 2
        inputArray = new int[4];
        //inputs = new Text[4];
        for (int i = 0; i >= 3 ; i++)
        {
            inputArray[i] = 0;
        }
        gameIsRunning = true;
 
    }

 
    void Update()
    {
        enemy = FindObjectOfType<Enemy>();
        countdownTimer = FindObjectOfType<CountdownTimer>();

        // Timer for dot and dash inputs
        if (countDown > 0)
        {
            countDown -= Time.deltaTime;
        }
        double b = System.Math.Round(countDown, 2);
        // debug text
        timer.text = b.ToString();

        // Timer for the input UI (flashing underlines for the inputed dot and dashes)
        // Just an infinite timer that counts down from 1 minute to 0 repeatedly
        if (sixtySecondTimer > 0)
            sixtySecondTimer -= Time.deltaTime;
        else sixtySecondTimer = 60.0f;
        double c = System.Math.Round(sixtySecondTimer, 2);
        // debug text
        dotsDashesUI.text = c.ToString();

        //if (countDown < 0)
        //{
        //    Debug.Log("Completed");
        //}

        // Flashing Input Underline
        flashyUnderlines();

        // Inputs
        // Start the timer on space key down 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            countDown = 0.5f;
        }
        
        // Detect Dashes and Dots
        // Dash (holding space)
        if (Input.GetKeyUp(KeyCode.Space) && countDown < 0.35f)
        {
            // Debug Text
            Debug.Log("Dash");
            dotsDashesUI.text = "Dash";
           

            // have an iterator that goes up when an input is entered
            inputArray[currentInput] = 2;
            inputs[currentInput].text = "__";
            currentInput++;
            // debug text array 
            Debug.Log(inputArray[0].ToString());
            Debug.Log(inputArray[1].ToString());
            Debug.Log(inputArray[2].ToString());
            Debug.Log(inputArray[3].ToString());
        }
        // Dots (tapping space)
        if (Input.GetKeyUp(KeyCode.Space) && countDown > 0.35f)
        {
            Debug.Log("Dot");
            dotsDashesUI.text = "Dot";
            inputArray[currentInput] = 1;
            inputs[currentInput].text = "o";
            currentInput++;

            // debug text array
            Debug.Log(inputArray[0].ToString());
            Debug.Log(inputArray[1].ToString());
            Debug.Log(inputArray[2].ToString());
            Debug.Log(inputArray[3].ToString());
        }

        // Casts the corresponding spells and resets the currentInput & array
        if (inputArray[3] > 0)
        {
            morseCodeReader();
            inputArray[0] = 0;
            inputArray[1] = 0;
            inputArray[2] = 0;
            inputArray[3] = 0;
            resetInputs();
        }
        
    }

    void flashyUnderlines()
    {
        if (currentInput == 0)
        {
            if ((int)sixtySecondTimer % 2 <= 0)
                underline1.gameObject.SetActive(true);
            else
                underline1.gameObject.SetActive(false);
        }
        if (currentInput == 1)
        {
            underline1.gameObject.SetActive(true);
            if ((int)sixtySecondTimer % 2 <= 0)
                underline2.gameObject.SetActive(true);
            else
                underline2.gameObject.SetActive(false);
        }
        if (currentInput == 2)
        {
            underline1.gameObject.SetActive(true);
            underline2.gameObject.SetActive(true);
            if ((int)sixtySecondTimer % 2 <= 0)
                underline3.gameObject.SetActive(true);
            else
                underline3.gameObject.SetActive(false);
        }
        if (currentInput == 3)
        {
            underline1.gameObject.SetActive(true);
            underline2.gameObject.SetActive(true);
            underline3.gameObject.SetActive(true);
            if ((int)sixtySecondTimer % 2 <= 0)
                underline4.gameObject.SetActive(true);
            else
                underline4.gameObject.SetActive(false);
        }
        if (currentInput == 4)
        {
            underline1.gameObject.SetActive(true);
            underline2.gameObject.SetActive(true);
            underline3.gameObject.SetActive(true);
            underline4.gameObject.SetActive(true);
        }
    }

    void resetInputs()
    {
        currentInput = 0;
        for (int i = 0; i <= 3; i++)
        {
            inputs[i].text = " ";
        }
        underline1.gameObject.SetActive(false);
        underline2.gameObject.SetActive(false);
        underline3.gameObject.SetActive(false);
        underline4.gameObject.SetActive(false);
    }
   
    void morseCodeReader()
    {
        // If the inputs are anything from the Morse Code Alphabet (currently only F works, everything else just resets it)
        //A   1 2
        //B   2 1 1 1
        //C   2 1 2 1
        //D   2 1 1
        //E   1
        //F   1 1 2 1
        if (inputArray[0] == 1 &&
            inputArray[1] == 1 &&
            inputArray[2] == 2 &&
            inputArray[3] == 1)
        {
            Debug.Log("F");
            // do cool things
            enemy.die();
            countdownTimer.timerIsRunning = true;

            /////
            resetInputs();
        }
        else
        {
            // reset everything 
            resetInputs();
        }

        //G   2 2 1
        //H   1 1 1 1
        //I   1 1
        //J   1 2 2 2
        //K   2 1 2
        //L   1 2 1 1
        //M   2 2
        //N   2 1
        //O   2 2 2
        //P   1 2 2 1
        //Q   2 2 1 2
        //R   1 2 1
        //S   1 1 1
        //T   2
        //U   1 1 2
        //V   1 1 1 2
        //W   1 2 2
        //X   2 1 1 2
        //Y   2 1 2 2
        //Z   2 2 1 1
    }
}
