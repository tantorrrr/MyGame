using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowAnimationsCTRL : MonoBehaviour {
    public Animator bowAnimator;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void shoot()
    {
        bowAnimator.SetTrigger("Fire");
    }
    public void ready(bool ready)
    {
        bowAnimator.SetBool("Ready", ready);
    }
}
