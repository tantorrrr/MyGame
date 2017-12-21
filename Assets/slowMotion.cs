using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowMotion : MonoBehaviour {
    public float desiredFreezeDuration;
    public float desiredTimeScale;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.V))
        {
            SlowMotionController.AddSlowMotion(desiredFreezeDuration, desiredTimeScale);
            //SlowMotionController.AddSlowMotion(,)
        }
	}
}
