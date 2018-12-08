using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retry_Update : MonoBehaviour {

    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update () {
	    if (Scene_Manager.gameEnd)
        {
            animator.SetBool("isGameEnd", true);
        }	
	}
}
