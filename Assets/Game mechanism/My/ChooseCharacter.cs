using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCharacter : MonoBehaviour {
    public GameObject player;
    public GameObject SpawnPoint;
    private bool choosed = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        //Debug.LogError(other.transform.root.tag);
        if(!choosed && other.transform.root.tag == "StartPlayer")
        {
            var bullet = (GameObject)Instantiate(
            player,
            SpawnPoint.transform.position,
            SpawnPoint.transform.rotation);
            Destroy(other.transform.root.gameObject);
            
            choosed = true;
            //Destroy(gameObject);
        }
    }
}
