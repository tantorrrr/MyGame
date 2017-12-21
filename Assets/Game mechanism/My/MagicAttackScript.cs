using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.Dynamics;
using System;

public class MagicAttackScript : MonoBehaviour {
    public int areaForce = 999;
    public float unpin = 10f;
    public float radius;
    public LayerMask layerMask;
    public int damage;
    public string[] damageTags;
    public List<GameObject> damagedObjects = new List<GameObject>();
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void attack()
    {
        Collider[] objects = UnityEngine.Physics.OverlapSphere(transform.position,radius,layerMask);
        foreach (Collider h in objects)
        {

            Rigidbody r = h.GetComponent<Rigidbody>();
            if (r != null && h.gameObject.transform.root.tag == "Enemy")
            {
                Vector3 dir = h.transform.position - transform.position;
                var broadcaster = h.attachedRigidbody.GetComponent<MuscleCollisionBroadcaster>();

                if (broadcaster != null)
                {
                    Vector3 dire = dir.normalized * areaForce;
                    Debug.LogError(h.transform.name + "force:" + dire);
                    broadcaster.Hit(unpin, dire, h.transform.position,false,0f);
                    Damage(h.gameObject);
                    //  broadcaster.Hit(unpin, * force, h.transform.position);
                    //broadcaster.Hit()
                }
                //r.AddExplosionForce(9999, transform.position, 100);
            }
        }
        damagedObjects.Clear();
    }
    public void Damage(GameObject damagedObject)
    {
        if (damagedObject != null && Array.IndexOf(damageTags, damagedObject.transform.root.tag) > -1)
        {
            //Debug.LogError(collision.impulse);
            if (!damagedObjects.Contains(damagedObject.transform.root.gameObject))
            {
                
                
                ///
                damagedObjects.Add(damagedObject.transform.root.gameObject);
                ///
                
                //Random.Range(minDamage, maxDamage);
                damagedObject.transform.root.Find("Stats").GetComponent<PlayerStats>().DamageIt(damage);
                //collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(2000, transform.position, 1000);

                // other.GetComponent<getParent>().parent.GetComponent<PlayerStats>().HP -= 20;

            }
        }
    }
}
