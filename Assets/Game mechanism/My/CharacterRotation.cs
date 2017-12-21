using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion;

public class CharacterRotation : MonoBehaviour {
    public CharacterMeleeDemo characterMelee;
    public float attackTurnSpeed;
    private float turnSpeed;
    // Use this for initialization
    void Start () {
        turnSpeed = characterMelee.turnSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void activateRotation(bool state)
    {
        if (state)
            characterMelee.turnSpeed = turnSpeed;
        else
            characterMelee.turnSpeed = attackTurnSpeed;
    }
}
