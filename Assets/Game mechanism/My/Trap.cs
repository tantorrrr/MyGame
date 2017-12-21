using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter(Collision collision)
    {
        collision.transform.root.Find("Stats").GetComponent<PlayerStats>().DamageIt(100);
        collision.gameObject.AddComponent<FixedJoint>().connectedBody = transform.GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        other.transform.root.Find("Stats").GetComponent<PlayerStats>().DamageIt(100);
        other.gameObject.AddComponent<FixedJoint>().connectedBody = transform.GetComponent<Rigidbody>();
    }
}
