using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TowerController : MonoBehaviour {
    public string[] EnemyTags;
    public int minDamage;
    public int maxDamage;
    public GameObject bulletsSpawner;
    public GameObject spawnedObject;
    public float speed;
    public float shootSpeed;
    public float bulletDestroyTime;
    private bool canShoot = true;
    public List<GameObject> EnteredObjects = new List<GameObject>();

    public float distance;
    public GameObject enemy;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CheckIfIsAlive();
        if (EnteredObjects.Count > 0)
        {
            
            distance = Vector3.Distance(EnteredObjects[0].transform.Find("Character Controller").transform.position, transform.position);
            enemy = EnteredObjects[0].transform.Find("Character Controller").gameObject;
            for (int i = 0; i< EnteredObjects.Count; i++)
            {
                
                if(distance > Vector3.Distance(EnteredObjects[i].transform.Find("Character Controller").transform.position, transform.position))
                {
                    distance = Vector3.Distance(EnteredObjects[i].transform.Find("Character Controller").transform.position, transform.position);
                    enemy = EnteredObjects[i].transform.Find("Character Controller").gameObject;
                    
                }
            }
            AttackEnemy();
        }
	}
    public void CheckIfIsAlive()
    {
        for (int i = 0; i < EnteredObjects.Count; i++)
        {
            
            if (!EnteredObjects[i])
            {
               // EnteredObjects.Remove(EnteredObjects[i]);
                EnteredObjects.RemoveAt(i);
                continue;
            }
            if (EnteredObjects[i].transform.root.Find("Stats"))
            {
                if (EnteredObjects[i].transform.root.Find("Stats").GetComponent<PlayerStats>().dead)
                {
                    // EnteredObjects.Remove(EnteredObjects[i]);
                    EnteredObjects.RemoveAt(i);
                }
            }


        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.LogError(other.transform.name);
        //EnteredObjects = new List<GameObject>();
        if(other.transform.root.Find("Stats"))
        if (!EnteredObjects.Contains(other.transform.root.gameObject) && !other.transform.root.Find("Stats").GetComponent<PlayerStats>().dead)
        {
            if (Array.IndexOf(EnemyTags, other.transform.root.tag) > -1)
            {
                EnteredObjects.Add(other.transform.root.gameObject);

            }
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (EnteredObjects.Contains(other.transform.root.gameObject))
        {
            if (Array.IndexOf(EnemyTags, other.transform.root.tag) > -1)
            {
                EnteredObjects.Remove(other.transform.root.gameObject);

            }
        }
    }
    public void AttackEnemy()
    {
        Vector3 pos = enemy.transform.position;
        pos.y += 1;
        bulletsSpawner.transform.LookAt(pos);
        if (canShoot)
        {
            canShoot = false;
            Invoke("LetItShoot", shootSpeed);
            SpawnBullet();
        }
        
    }
    public void SpawnBullet()
    {
        var bullet = (GameObject)Instantiate(
            spawnedObject,
            bulletsSpawner.transform.position,
            bulletsSpawner.transform.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * speed;
        bullet.GetComponent<Damage>().setMinDamage(minDamage);
        bullet.GetComponent<Damage>().setMaxDamage(maxDamage);
        bullet.GetComponent<Damage>().DamageTags = EnemyTags;


        // Destroy the bullet after 2 seconds
        Destroy(bullet, bulletDestroyTime);
    }
    private void LetItShoot()
    {
        canShoot = true;
    }
}
