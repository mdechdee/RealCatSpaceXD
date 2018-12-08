using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackOnOff : MonoBehaviour {

    public CatMovement catMovement;

    // Use this for initialization
    public ParticleSystem[] jetpackPs;
    AudioSource jetSound;
    public AudioClip startJet;
    public AudioClip onJet;
    public AudioClip endJet;
    private bool endAble = false;
    void Start () {
        catMovement = GetComponentInParent<CatMovement>();
        jetpackPs = GetComponentsInChildren<ParticleSystem>();
        jetSound = GetComponentInChildren<AudioSource>();
        if(jetpackPs == null)
        {
            print("No Jetpack Flame!");
        }
    }
	
	// Update is called once per frame
	void Update(){
        jetPackSound();
        if (Input.GetKey(KeyCode.LeftShift) == true && catMovement.useJetpack == true)
        {
            foreach (ParticleSystem ps in jetpackPs)
            {
                if (ps.isPlaying == false)
                {
                    ps.Play();
                }
            }
        }
        else
        {
            foreach (ParticleSystem ps in jetpackPs)
            {
                ps.Stop();
            }   
        }
        
    }
    void jetPackSound()
    {
        
        if (Input.GetKeyDown(KeyCode.LeftShift) && catMovement.useJetpack == true)
        {
            jetSound.PlayOneShot(startJet);
            jetSound.PlayDelayed(startJet.length);
            endAble = true;
        }
        if(catMovement.useJetpack == false && endAble == true)
        {
            jetSound.Stop();
            jetSound.PlayOneShot(endJet);
            endAble = false;
        }
    }
}
