using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnBlock : StateMachineBehaviour {
    [Range(1, 100)] public float startTimePercent = 0f;
    [Range(1, 100)] public float stopTimePercent = 100f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (stateInfo.normalizedTime * 100 > startTimePercent && stateInfo.normalizedTime * 100 < stopTimePercent)
        {
            animator.gameObject.transform.root.Find("Character Controller").GetComponent<CharacterPublicVariables>().blocking = true;

        }
        if (stateInfo.normalizedTime * 100 >= stopTimePercent)
        {
            animator.gameObject.transform.root.Find("Character Controller").GetComponent<CharacterPublicVariables>().blocking = false;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
