using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using UnityEngine.SceneManagement;

public class DeathZoneScript : MonoBehaviour {
    private Stopwatch deathTimeCount = new Stopwatch();
    public Canvas warningCanvas;
    public int deathTime = 3;
    public Text timeDisplay;
    public Text warningLabel;
    public bool outOfZone = false;
    // Use this for initialization
    private void Start()
    {
        //How much time cat will die (in seconds)
        deathTime = 10;
        timeDisplay.enabled = false;
        warningLabel.enabled = false;
    }

    public void Call()
    {
        if(outOfZone == true)
        {
            deathTimeCount.Start();
            timeDisplay.enabled = true;
            warningLabel.enabled = true;
        }
        else
        {
            deathTimeCount.Reset();
            timeDisplay.enabled = false;
            warningLabel.enabled = false;
            
        }
        
    }
    private void Update()
    {
        float catFuel = GameObject.Find("Cat Lite").GetComponent<CatMovement>().fuelLevel;
        long timeLeft = (deathTime * 2000 -deathTimeCount.ElapsedMilliseconds)/1000;
        timeDisplay.text = timeLeft.ToString();
        //if (outOfZone == false)
        //{
        //    Call();
        //    print(1111);
        //}
            
        if(deathTimeCount.ElapsedMilliseconds>deathTime*2000)
        {
            GameObject endtext = GameObject.Find("HUDCanvas/End_Game");
            timeDisplay.enabled = false;
            endtext.GetComponent<Text>().enabled = true;
            if(Input.GetKeyDown(KeyCode.Y))
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            if (Input.GetKeyDown(KeyCode.N))
                Application.Quit();
                
        }
    }
}
