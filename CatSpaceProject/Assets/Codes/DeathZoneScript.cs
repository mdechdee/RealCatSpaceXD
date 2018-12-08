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
        if(outOfZone == false)
        {
            deathTimeCount.Start();
            outOfZone = true;
            timeDisplay.enabled = true;
            warningLabel.enabled = true;
        }
        else
        {
            deathTimeCount.Reset();
            outOfZone = false;
            timeDisplay.enabled = false;
            warningLabel.enabled = false;
        }
        
    }
    private void Update()
    {

        long timeLeft = (deathTime * 1000 -deathTimeCount.ElapsedMilliseconds)/1000;
        timeDisplay.text = timeLeft.ToString();
        if(deathTimeCount.ElapsedMilliseconds>deathTime*1000)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
