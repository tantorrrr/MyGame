using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomCustomization : MonoBehaviour {
    public maleEditor me;
    private bool candestroy = false;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        //if (candestroy)
         //  Destroy(gameObject, 1f);
        if (me.loaded && !candestroy)
        {
            candestroy = true;
            me.randomAll();
            
        }
        
    }
}
