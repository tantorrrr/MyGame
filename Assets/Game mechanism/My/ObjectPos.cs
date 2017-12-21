using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPos : MonoBehaviour {
    public Transform objectPosition;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = objectPosition.position;
        transform.rotation = objectPosition.rotation;
	}
}
