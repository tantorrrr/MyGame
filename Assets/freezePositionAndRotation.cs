using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freezePositionAndRotation : MonoBehaviour {
   public Vector3 position;
   public Quaternion rotation;
    // Use this for initialization
    void Start () {
        position = transform.localPosition;
        rotation = transform.localRotation;
        GetComponent<Rigidbody>().isKinematic = false;
	}
	
	// Update is called once per frame
	void Update () {
       // GetComponent<Rigidbody>().isKinematic = false;
       // position = transform.localPosition;
       // rotation = transform.localRotation;
         transform.localPosition = position;
         transform.localRotation = rotation;
    }
}
