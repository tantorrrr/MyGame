using UnityEngine;
using System.Collections;
using RootMotion.Demos;

	
	/// <summary>
	/// User input for an AI controlled character controller.
	/// </summary>
	public class UserControlAI : UserControlThirdPerson {

		public Transform moveTarget;
		public float stoppingDistance = 0.5f;
		public float stoppingThreshold = 1.5f;
        public bool canWalk = true;

		protected override void Update () {
        float moveSpeed;
        if (canWalk)
            moveSpeed = walkByDefault ? 0.5f : 1f;
        else
            moveSpeed = 0;

            Vector3 direction = moveTarget.position - transform.position;
			direction.y = 0f;

			float sD = state.move != Vector3.zero? stoppingDistance: stoppingDistance * stoppingThreshold;
            //Debug.LogError(sD);
			state.move = direction.magnitude > sD? direction.normalized * moveSpeed: Vector3.zero;
            //Debug.LogError("pup" + state.move);

            
		}
	}


