﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using UnityEngine.SceneManagement;

public class DeathZoneScript : MonoBehaviour {
    CatMovement catmovement;
    private Stopwatch deathTimeCount = new Stopwatch();
    public Canvas warningCanvas;
    public int deathTime = 3;
    public Text timeDisplay;
    public Text warningLabel;
    public bool outOfZone = false;
    // Use this for initialization

    private void Awake()
    {
        catmovement = GameObject.FindGameObjectWithTag("Player").GetComponent<CatMovement>();    
    }

    private void Start()
    {
        //How much time cat will die (in seconds)
        deathTime = 10;
        timeDisplay.enabled = false;
        warningLabel.enabled = false;
    }

    public void Call()
    {
        if (outOfZone == true)
        {
            AudioSource BG = GameObject.Find("Cat Lite/Main Camera").GetComponent<AudioSource>();
            BG.Stop();
            AudioSource DieSound = GetComponent<AudioSource>();
            DieSound.Play();
            deathTimeCount.Start();
            timeDisplay.enabled = true;
            warningLabel.enabled = true;
        }
        else
        {
            AudioSource DieSound = GetComponent<AudioSource>();
            DieSound.Stop();
            AudioSource BG = GameObject.Find("Cat Lite/Main Camera").GetComponent<AudioSource>();
            BG.Play();

            deathTimeCount.Reset();
            timeDisplay.enabled = false;
            warningLabel.enabled = false;
            
        }
        
    }

    void GameOver()
    {
        Text gameovertext = GameObject.Find("HUDCanvas/GameOver").GetComponent<Text>();
        Text resumegame = GameObject.Find("HUDCanvas/End_Game").GetComponent<Text>();
        gameovertext.enabled = true;
        resumegame.enabled = true;
        if (Input.GetKeyDown(KeyCode.Y))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (Input.GetKeyDown(KeyCode.N))
            Application.Quit();
    }

    private void Update()
    {
        if (catmovement.gameover == true)
        {
            GameOver();
        }

        float catFuel = GameObject.Find("Cat Lite").GetComponent<CatMovement>().fuelLevel;
        long timeLeft = (deathTime * 1000 -deathTimeCount.ElapsedMilliseconds)/1000;
        timeDisplay.text = timeLeft.ToString();
        //if (outOfZone == false)
        //{
        //    Call();
        //    print(1111);
        //}
            
        if(deathTimeCount.ElapsedMilliseconds>deathTime*1000)
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
