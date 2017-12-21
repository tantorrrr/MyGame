using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class useEventsTrigger : StateMachineBehaviour {
    public int eventNumber;
    [Range(1, 100)] public float startTimePercent;
    private bool wasTriggered = false;
    public string eventTriggerObjectName = "Events";
	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        wasTriggered = false;
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
       // Debug.LogError(stateInfo.normalizedTime);
        if(stateInfo.normalizedTime * 100 > startTimePercent && !wasTriggered)
        {
            animator.gameObject.transform.root.Find(eventTriggerObjectName).GetComponent<EventsTrigger>().startEvent(eventNumber);
            //GameObject..Find("Character Controller").GetComponent<EventsTrigger>().startEvent(eventNumber);
            wasTriggered = true;
        }
       
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	if(!wasTriggered)
        {
            animator.gameObject.transform.root.Find(eventTriggerObjectName).GetComponent<EventsTrigger>().startEvent(eventNumber);
           
            wasTriggered = true;
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
