using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClearParameters : StateMachineBehaviour {
    [Header("INT")]
    public string intParName;
    public int intToValue;
    [Header("FLOAT")]
    public string floatParName;
    public float floatToValue;
    [Header("BOOL")]
    public string boolParName;
    public bool boolToValue;

    public bool onExit = false;

    // public UnityEvent ev;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (!onExit)
        {
            if (intParName != "")
                animator.SetInteger(intParName, intToValue);
            if (floatParName != "")
                animator.SetFloat(floatParName, floatToValue);
            if (boolParName != "")
                animator.SetBool(boolParName, boolToValue);
        }
    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if(onExit)
        {
            if (intParName != "")
                animator.SetInteger(intParName, intToValue);
            if (floatParName != "")
                animator.SetFloat(floatParName, floatToValue);
            if (boolParName != "")
                animator.SetBool(boolParName, boolToValue);
        }
	
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
