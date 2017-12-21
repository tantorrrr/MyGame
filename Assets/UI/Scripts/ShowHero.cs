using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHero : MonoBehaviour {
    public GameObject Hero;
    public Transform SpawnPoint;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SpawnHero()
    {
        int childs = SpawnPoint.transform.childCount;
        for (int i=0; i < childs; i++)
        {
            GameObject.Destroy(SpawnPoint.transform.GetChild(i).gameObject);
        }
        ////
        if (Hero != null)
        {
            GameObject hero = Instantiate(Hero, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
            hero.transform.parent = SpawnPoint.transform;
        }
        
        
    }
}
