﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLayerWeight : StateMachineBehaviour {
    public int LayerNumber;
    public float LayerWeight;
    [Range(1, 100)] public float startTimePercent = 0f;
    [Range(1, 100)] public float stopTimePercent = 100f;
    public bool dontEnd = false;
    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.normalizedTime * 100 > startTimePercent && stateInfo.normalizedTime * 100 < stopTimePercent)
        {
            animator.SetLayerWeight(LayerNumber, LayerWeight);
           
        }
        if (stateInfo.normalizedTime * 100 >= stopTimePercent)
        {
            if(!dontEnd)
            animator.SetLayerWeight(LayerNumber, 0);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!dontEnd)
            animator.SetLayerWeight(LayerNumber, 0);
    }

    // OnStateMove is called before OnStateMove is called on any state inside this state machine
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called before OnStateIK is called on any state inside this state machine
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateMachineEnter is called when entering a statemachine via its Entry Node
    //override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash){
    //
    //}

    // OnStateMachineExit is called when exiting a statemachine via its Exit Node
    //override public void OnStateMachineExit(Animator animator, int stateMachinePathHash) {
    //
    //}
}
