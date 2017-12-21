using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour {
    public float forceApplied = 50;
    public float hoverForce;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    

    void OnCollisionEnter(Collision col)
    {
      //  Debug.Log("Collision!   " + col.transform.name + "   " + col.transform.root.Find("Character Controller").name);
       // if (col.gameObject.name == "Sphere")
       // {
           // col.gameObject.GetComponent<Rigidbody>().AddForce(0, forceApplied, 0);
      //  }
     // col.transform.root.Find("Character Controller").GetComponent<Rigidbody>().AddForce(0, forceApplied, 0);
     //   col.transform.root.Find("Character Controller").GetComponent<Rigidbody>().AddForce(Vector3.up * hoverForce, ForceMode.Acceleration);
    }
}
