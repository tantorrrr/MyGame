using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearDamageArray : MonoBehaviour {
    public GameObject weapon;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void clearDamageArray()
    {
        weapon.GetComponent<Damage>().clearArray();
    }
}
