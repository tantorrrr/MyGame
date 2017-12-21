using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFireball : MonoBehaviour {
    public GameObject fireBall;
    public float speed = 3;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void spawn()
    {
        var bullet = (GameObject)Instantiate(
            fireBall,
            transform.position,
            transform.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * speed;

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 5.0f);
    }
}
