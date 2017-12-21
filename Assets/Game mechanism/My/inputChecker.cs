using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputChecker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.LogError(Input.GetKey(KeyCode.Space) + "---" + Input.GetKey(KeyCode.LeftShift));	
        
	}
}
