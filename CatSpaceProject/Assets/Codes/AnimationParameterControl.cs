using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationParameterControl : MonoBehaviour {
    Animator animator;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftShift) == true && gameObject.GetComponent<CatMovement>().fuelLevel>0)
            animator.SetBool("onJet", true);
        else
            animator.SetBool("onJet", false);
        if (Input.GetMouseButtonDown(1))
            animator.SetTrigger("Play");
    }
}
