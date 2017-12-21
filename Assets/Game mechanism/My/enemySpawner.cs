using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {
    public GameObject enemyPrefab;
    public GameObject[] navObjects;
    public float spawnTime = 1f;
    public string SpawnedObjectRootTag = "Enemy";
    public string AttackTag = "Player";
	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void Spawn()
    {
        

        // Find a random index between zero and one less than the number of spawn points.
        //int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        var sEnemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
        sEnemy.transform.root.Find("Navigator").GetComponent<EnemyNavigator>().navObjects = navObjects;
        sEnemy.transform.root.Find("Navigator").GetComponent<EnemyNavigator>().enemyTag = AttackTag;
        sEnemy.transform.root.tag = SpawnedObjectRootTag;
        sEnemy.transform.root.Find("Weapons").GetComponent<ActivateWeapons>().weapons[0].GetComponent<Damage>().DamageTags[0] = AttackTag;
    }
}
