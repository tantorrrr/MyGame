using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.Dynamics;


public class MappingWeightController : MonoBehaviour {
    public BehaviourPuppet behaviourPuppet;
    public PuppetMaster puppetMaster;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       // Debug.LogError(behaviourPuppet.state);
		if(behaviourPuppet.state != BehaviourPuppet.State.Puppet)
        {
            puppetMaster.mappingWeight = 1;
        }
        else
        {
            puppetMaster.mappingWeight = 0;
        }
	}
}
