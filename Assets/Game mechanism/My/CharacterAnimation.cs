using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.Dynamics;
using RootMotion.Demos;

public class CharacterAnimation : MonoBehaviour {
    public CharacterThirdPerson characterController;
    public GameObject groundFinder;
    public LayerMask layers;
    public float minHeightToFall = 5;
    public BehaviourPuppet behaviourPuppet;
    public PuppetMaster puppetMaster;
    private bool isFalling= false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Q))
        {
            //Debug.LogError(KeyCode.Space);
            //GetComponent<Animator>().Play("Actions.RunJump", 0);
            GetComponent<Animator>().SetInteger("Skill", 1);
        }
        else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.E))
        {
            GetComponent<Animator>().SetInteger("Skill", 3);
        }
        else if (!Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.E))
        {
            GetComponent<Animator>().SetInteger("Skill", 4);
        }
        else
        {
            GetComponent<Animator>().SetInteger("Skill", 0);
        }

        float FH = GetComponent<Animator>().GetFloat("Jump");
        //Debug.LogError(FH);
        if (FH > minHeightToFall)
        {
            //Fall();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Fall();
        }


        checkDistance();

}
    void Fall()
    {
        
        behaviourPuppet.Resurrect();
        GetComponent<Animator>().SetInteger("Actions", 2);
        isFalling = true;
        Debug.LogError(getDistanceToGround());
        
    }
    public float getDistanceToGround()
    {

        RaycastHit hit;
        Ray downRay = new Ray(groundFinder.transform.position,groundFinder.transform.forward);
        if (Physics.Raycast(downRay, out hit,100,layers))
        {
           // Debug.LogError(hit.distance);
            return hit.distance;
            
        }
        else
        {
            return Mathf.Infinity;
        }
        }
    private void checkDistance()
    {
        if (getDistanceToGround() > minHeightToFall && !isFalling)
        {
            Fall();
        }
        if (isFalling && characterController.animState.onGround)
        {

            puppetMaster.state = PuppetMaster.State.Dead;
        }
    }
}
