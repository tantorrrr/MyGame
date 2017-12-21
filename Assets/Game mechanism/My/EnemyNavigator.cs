using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using RootMotion;

public class EnemyNavigator : MonoBehaviour
{
    
    UnityEngine.AI.NavMeshAgent nav;
    [Header("Way Mark")]
    public GameObject[] navObjects;
    public bool canGo = true;
    public float stopDistance= 1f;
    


    public int currObject = 0;

    [Header("Enemy Finder")]
    public float minDistance;
    
    public string enemyTag;
    public GameObject[] enemyGameObjects;
    public GameObject currentEnemy;
    public float currentDistance;

    public float attackDistance;
    public float attackDistanceToBuildings = 2f;
    public LayerMask BuildingsLayer;
    public UserControlAI UserControlAI;
    public BotAnimationsCtrl botAnimationCtrl;
    public GameObject CharacterController;
    // Use this for initialization
    void Start()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
     void Update()
    {
        if (navObjects.Length > 0)
        {
            if (!findEnemiesAndFightIfCan() && navObjects[currObject])
            {
                if (UserControlAI)
                {
                    //UserControlAI.moveTarget = transform;
                }
                stopDistance = nav.stoppingDistance + 0.1f;
                float distance = Vector3.Distance(transform.position, navObjects[currObject].transform.position);
                if (distance < stopDistance && currObject < (navObjects.Length - 1))
                {
                    currObject++;

                }

                else if (distance < 2f && currObject == (navObjects.Length - 1)) { }
                // nav.ResetPath();
                // nav.Stop();
                else
                {
                    botAnimationCtrl.attackAnimation(0);
                    UserControlAI.canWalk = true;
                    navigateToObject(navObjects[currObject]);
                }

            }
        }
        else
        {
            if (!findEnemiesAndFightIfCan())
            {
                
                    botAnimationCtrl.attackAnimation(0);
                    UserControlAI.canWalk = false;
                    
                

            }
        }
        
        
    }
    private bool findEnemiesAndFightIfCan()
    {
        
        if (GameObject.FindGameObjectWithTag(enemyTag) != null)
        {
            //array of enemies//
            enemyGameObjects = GameObject.FindGameObjectsWithTag(enemyTag);
            int i = 0;
            foreach (GameObject enemy in enemyGameObjects)
            {
                enemyGameObjects[i] = enemy.transform.root.Find("Character Controller").gameObject;
                i++;
            }
                currentEnemy = enemyGameObjects[0];

            //distance to enemy//
            currentDistance = Vector3.Distance(transform.position, enemyGameObjects[0].transform.position);
            foreach (GameObject enemy in enemyGameObjects)
            {
                if(enemy.transform.root.Find("Stats"))
                if (currentDistance > Vector3.Distance(transform.position, enemy.transform.position) && !enemy.transform.root.Find("Stats").GetComponent<PlayerStats>().dead)
                {
                    currentDistance = Vector3.Distance(transform.position, enemy.transform.position);
                    currentEnemy = enemy;
                }
            }

            //switch from walking to attack//
            if (currentDistance < minDistance)
            {
               /* if (nav.remainingDistance < nav.stoppingDistance)
                {
                    UserControlAI.canWalk = false;
                    Vector3 lookPosition = navObjects[currObject].transform.position;
                    lookPosition.y = transform.position.y;
                    CharacterController.transform.LookAt(lookPosition);
                    transform.LookAt(lookPosition);
                }
                else
                {
                    UserControlAI.canWalk = true;
                }*/

                navigateToObject(currentEnemy);
               // Debug.LogError(LayerMask.LayerToName(currentEnemy.transform.root.gameObject.layer) + "--" + LayerMask.LayerToName(BuildingsLayer.MaskToNumbers()[0]));
                if (UserControlAI && ( Vector3.Distance(CharacterController.transform.position, currentEnemy.transform.position)< attackDistance) || (Array.IndexOf(BuildingsLayer.MaskToNumbers(),currentEnemy.transform.root.gameObject.layer)>-1 && Vector3.Distance(CharacterController.transform.position, currentEnemy.transform.position) < attackDistanceToBuildings))
                {
                    UserControlAI.canWalk = false;
                    Vector3 lookPosition = currentEnemy.transform.position;
                    lookPosition.y = transform.position.y;
                    CharacterController.transform.LookAt(lookPosition);
                    transform.LookAt(lookPosition);
                    botAnimationCtrl.attackAnimation(1);
                }
                else
                {
                    UserControlAI.canWalk = true;
                    botAnimationCtrl.attackAnimation(0);
                }
                return true;

            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }

            
    }
    private void navigateToObject(GameObject navObject)
    {
        nav.SetDestination(navObject.transform.position);
    }
    public void setPositionOfObj(GameObject obj)
    {
        transform.position = obj.transform.position;
    }
}
