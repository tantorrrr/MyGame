using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawner : MonoBehaviour {
    public GameObject trap;
    public GameObject trapPositioner;
    public LayerMask CollisionLayers;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Vector3 pos = FindPosition();
            var sTrap = (GameObject)Instantiate(
           trap,
           pos,
           transform.rotation);
        }
	}
    private Vector3 FindPosition()
    {
        RaycastHit hit;
        Ray downRay = new Ray(trapPositioner.transform.position, trapPositioner.transform.forward);
        if (Physics.Raycast(downRay, out hit, CollisionLayers))
        {
            return hit.point;
        }
        else
        {
            return trapPositioner.transform.position;
        }
    }
}
