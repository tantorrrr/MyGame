using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour {
    public Transform collisionObject;
    public Transform parent;
    // Use this for initialization
    void Start () {
        Physics.IgnoreCollision(collisionObject.GetComponent<Collider>(), GetComponent<Collider>());
        // childCollision(parent);
        foreach(Collider coll in parent.GetComponentsInChildren<Collider>())
        {
            Physics.IgnoreCollision(coll, GetComponent<Collider>());
        }
       // Debug.LogError( parent.GetComponentsInChildren<Collider>().Length );
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }

        
    }
    void childCollision(Transform obj)
    {
        foreach (Transform child in parent)
        {
            Debug.LogError(child.name);
            childCollision(child);
        }
    }
}
