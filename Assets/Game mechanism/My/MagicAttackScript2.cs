using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.Dynamics;
using System;


public class MagicAttackScript2 : MonoBehaviour {
    public int force = 999;
    public float unpin = 10f;
    public int damage;
    public string[] damageTags;
    public List<GameObject> damagedObjects = new List<GameObject>();
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Damage(Collider damagedObject)
    {
        
        //Debug.LogError(damagedObject.name);
        if (damagedObject != null && Array.IndexOf(damageTags, damagedObject.transform.root.tag) > -1)
        {
            Vector3 dir = damagedObject.transform.position - transform.position;
            var broadcaster = damagedObject.attachedRigidbody.GetComponent<MuscleCollisionBroadcaster>();

            if (broadcaster != null)
            {
                Vector3 dire = dir.normalized * force;
                //Debug.LogError(damagedObject.transform.name + "force:" + dire);
                broadcaster.Hit(unpin, dire, damagedObject.transform.position,false,0f);

            }
            if (!damagedObjects.Contains(damagedObject.transform.root.gameObject))
            {
                damagedObjects.Add(damagedObject.transform.root.gameObject);
                damagedObject.transform.root.Find("Stats").GetComponent<PlayerStats>().DamageIt(damage);
               
            }
        }
    }
    public void clearArray()
    {
        damagedObjects.Clear();
    }
}
