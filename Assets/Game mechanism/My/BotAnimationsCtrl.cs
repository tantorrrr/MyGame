using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotAnimationsCtrl : MonoBehaviour {
    public Animator animator;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void attackAnimation(int number)
    {
        animator.SetInteger("Attack", number);
    }
}
