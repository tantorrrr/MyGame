using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lele : MonoBehaviour {
    public GameObject obj;
    public bool fixedUpdate;
    public bool lateUpdate;
    public bool update;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(update)
        transform.position = obj.transform.position;
	}
    private void FixedUpdate()
    {
        if(fixedUpdate)
        transform.position = obj.transform.position;
    }
    private void LateUpdate()
    {
        if (lateUpdate)
            transform.position = obj.transform.position;
    }

}
