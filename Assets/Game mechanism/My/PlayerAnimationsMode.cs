using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationsMode : MonoBehaviour {
    public int playerMode;
    public GameObject[] items;
    
    // Use this for initialization
    void Start () {
        GetComponent<Animator>().SetInteger("Mode", playerMode);
        foreach( GameObject it in items)
        {
            it.active = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
}
