using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footSteps : MonoBehaviour {
    public float minDistance = 0.01f;
    GameObject terrain;
    public bool onGround = true;
    [Header("Check values :)")]
    public float distance1;
    public float distance2;
    public float distance3;
    public Transform trigger1;
    public Transform trigger2;
    public Transform trigger3;
    // Use this for initialization
    void Start () {
       terrain = GameObject.Find("Terrain");
	}
	
	// Update is called once per frame
	void Update () {
        distance1 = trigger1.position.y - terrain.transform.position.y;
        distance2 = trigger2.position.y - terrain.transform.position.y;
        distance3 = trigger3.position.y - terrain.transform.position.y;
        if (trigger1.position.y - terrain.transform.position.y < minDistance && trigger2.position.y - terrain.transform.position.y < minDistance && trigger3.position.y - terrain.transform.position.y < minDistance && !onGround)
        {
            GetComponent<AudioSource>().Play();
            onGround = true;
        }
        else if (trigger1.position.y - terrain.transform.position.y > minDistance && trigger2.position.y - terrain.transform.position.y > minDistance && trigger3.position.y - terrain.transform.position.y > minDistance)
        {
            onGround = false;
        }
    }
    
}
