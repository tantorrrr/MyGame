using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.Dynamics;
using System;

public class Trap002 : MonoBehaviour {
    public Animator anim;

    public int force = 999;
    public float unpin = 10f;
    public string[] damageTags;
    public List<GameObject> collisionObjects = new List<GameObject>();
    public List<GameObject> finalcollisionObjects = new List<GameObject>();
    public float waitTime = 2f;
    private bool used = false;
    private bool UsePerm = true;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay(Collider other)
    {
        if (UsePerm)
        {
            anim.SetBool("Use", true);
            UsePerm = false;
            //anim.SetBool("CanUse", false);
            //used = true;
        }
        if (!collisionObjects.Contains(other.gameObject)){
            collisionObjects.Add(other.gameObject);
        }
            

        
    }
    private void OnTriggerExit(Collider other)
    {
        if (collisionObjects.Contains(other.gameObject))
        {
            collisionObjects.Remove(other.gameObject);
        }


    }
    public void addForce()
    {
        finalcollisionObjects = collisionObjects;
        foreach (GameObject obj in finalcollisionObjects)
        {
            //Debug.LogError(obj.transform.name);

           Vector3 dir = transform.up;
            if (obj != null && Array.IndexOf(damageTags, obj.transform.root.tag) > -1)
            {
                if (obj.GetComponent<Collider>().GetComponent<MuscleCollisionBroadcaster>()!=null)
                {

                    var broadcaster = obj.GetComponent<Collider>().GetComponent<MuscleCollisionBroadcaster>();

                    if (broadcaster != null)
                    {
                        Vector3 dire = dir.normalized * force;
                        //Debug.LogError(obj.transform.name + "force:" + dire);
                        broadcaster.Hit(unpin, dire, obj.transform.position,false,0f);


                    }
               }
                
            }
        }
        // used = false;
        anim.SetBool("Use", false);
        collisionObjects.Clear();
        Invoke("canUse", waitTime);
    }
    private void canUse()
    {
        //anim.SetBool("CanUse", true);
        UsePerm = true;
    }
}
