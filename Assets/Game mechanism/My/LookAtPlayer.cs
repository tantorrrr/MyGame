using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.Dynamics;

public class LookAtPlayer : MonoBehaviour {
    public GameObject playerCamera;
    public GameObject characterController;
    
    public bool haveBalance;
    public float yAdd;
    public LayerMask terrainLayer;
    // Use this for initialization
    void Start () {
		//behaviourPuppet.onLoseBalance
	}
    void Awake()
    {
        

    }
    public void HaveBalance()
    {
        haveBalance = true;
    }
    public void HaventBalance()
    {
        haveBalance = false;
    }
    // Update is called once per frame
    void Update () {
        if(playerCamera)
        transform.LookAt(playerCamera.transform.position);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit,100f,terrainLayer))
        {
            
               // Debug.LogError("Found an object - distance: " + hit.distance);
            transform.position = new Vector3(characterController.transform.position.x, hit.point.y + yAdd, characterController.transform.position.z);
            
        }
            

        
       
    }
    
}
