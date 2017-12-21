using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;

public class SwitchAimIK : MonoBehaviour {
    public float speed= 0.1f;

	// Use this for initialization
	void Start () {
       // InvokeRepeating("Down", 0, 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ChangeWeight(bool up)
    {
        Debug.LogError("Elo");
        CancelInvoke("Down");
        CancelInvoke("UP");
        if (up)
        {
            InvokeRepeating("UP", 0, 0.001f);
        }

        else
        {
            InvokeRepeating("Down", 0, 0.001f);
        }
            
    }
    void Down()
    {

        if (GetComponent<AimIK>().solver.IKPositionWeight > 0)
        {
            GetComponent<AimIK>().solver.IKPositionWeight -= speed;
        }
        else
        {
            GetComponent<AimIK>().solver.IKPositionWeight = 0;
            CancelInvoke("Down");
        }
        


    }
    void UP()
    {

        if (GetComponent<AimIK>().solver.IKPositionWeight < 1)
        {
            GetComponent<AimIK>().solver.IKPositionWeight += speed;
        }
        else
        {
            GetComponent<AimIK>().solver.IKPositionWeight = 1;
            CancelInvoke("UP");
        }



    }
}
