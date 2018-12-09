using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackOnOff : MonoBehaviour {

    private CatMovement catMovement;

    // Use this for initialization
    public ParticleSystem[] jetpackPs;
    AudioSource jetSound;
    public AudioClip startJet;
    public AudioClip onJet;
    public AudioClip endJet;
    private bool endAble = false;
    void Start () {
        
        jetpackPs = GetComponentsInChildren<ParticleSystem>();
        jetSound = GetComponentInChildren<AudioSource>();
        if(jetpackPs == null)
        {
            print("No Jetpack Flame!");
        }
    }
	
	// Update is called once per frame
	void Update(){
        catMovement = gameObject.transform.parent.gameObject.GetComponent<CatMovement>();
        if (Input.GetKey(KeyCode.LeftShift) == true && catMovement.fuelLevel > 0)
        {
            if(jetpackPs[0].isPlaying == false)
            {
                jetpackPs[0].Play();
                jetpackPs[1].Play();
            }
            
        }
        else
        {
            foreach (ParticleSystem ps in jetpackPs)
            {
                ps.Stop();
            }   
        }
        jetPackSound();
    }
    void jetPackSound()
    {
        
        if (Input.GetKeyDown(KeyCode.LeftShift) == true && catMovement.fuelLevel > 0)
        {
            jetSound.PlayOneShot(startJet);
            jetSound.PlayDelayed(startJet.length);
            endAble = true;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift) == true && endAble == true)
        {
            jetSound.Stop();
            jetSound.PlayOneShot(endJet);
            endAble = false;
        }
    }
}
