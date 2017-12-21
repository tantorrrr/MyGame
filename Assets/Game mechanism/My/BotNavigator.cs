using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RootMotion.Demos;

public class BotNavigator : UserControlThirdPerson
{
    public GameObject target;
    public GameObject target2;
    //Animator anim;
    NavMeshAgent agent;
    

    public float stoppingDistance = 0.5f;
    public float stoppingThreshold = 1.5f;

    public float minDistance = 0.5f;
    public float maxDistance = 0.7f;
    private Vector3 lastPosition;
    private Vector3 currentPosition;
    private float startSpeed;
    void Start()
    {
        
        //anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        // Don’t update position automatically
        agent.updatePosition = false;
        agent.updateRotation = false;
        agent.destination = target2.transform.position;
        startSpeed = agent.speed;
    }

     void Update()
    {
        agent.destination = target2.transform.position;


        // Vector3 direction = agent.velocity;
        Vector3 direction =  agent.nextPosition - transform.position;
            direction.y = 0f;
            float moveSpeed = walkByDefault ? 0.5f : 1f;
            float sD = state.move != Vector3.zero ? stoppingDistance : stoppingDistance * stoppingThreshold;

            state.move = direction.magnitude > sD ? direction.normalized * moveSpeed : Vector3.zero;

       // }
        currentPosition = transform.position;
       // Debug.LogError(agent.velocity);
        float dist = Vector3.Distance(agent.nextPosition, transform.position);
        if (dist < minDistance)
        {
            agent.speed = startSpeed + 0.2f;
        }
        else if (dist > maxDistance)
        {
            agent.speed = startSpeed ;
        }
        //agent.updatePosition = false;
        //agent.updatePosition = true;
        //GetComponent<LookAt>().lookAtTargetPosition = agent.steeringTarget + transform.forward;


        //state.move = 
        // transform.position = agent.nextPosition;
    }
}
