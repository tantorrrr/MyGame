using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navigatorController : MonoBehaviour {
    NavMeshAgent nav;
    public float navSpeed;
    public Animator anim;
    private float currSpeed;
    // Use this for initialization
    void Start () {
        nav = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
        currSpeed = anim.GetFloat("Speed") * navSpeed;
        nav.speed = currSpeed;
	}
}
