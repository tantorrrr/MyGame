using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restartRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    private void LateUpdate()
    {
        Quaternion newRotation = transform.rotation;
        newRotation.x = 0;
        newRotation.z = 0;
        transform.rotation = newRotation;
    }
}
