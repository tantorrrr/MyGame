using System.Collections;
#if UNITY_EDITOR
//using UnityEditor;
#endif
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;
using RootMotion.Dynamics;
using System;
//using UnityEditor;

public class Damage : MonoBehaviour {

    public string[] DamageTags;
    public int maxDamage;
    public int minDamage;
    public int minForce;
    public int maxForce;
    [Range(1, 100)] public int hitReactionMinForcePercent;
    public float randomValue;
    public float unpin = 10f;


    public bool destroyOnTriggerEnter = false;

    public bool cleaerArray = false;
    public List<GameObject> damagedObjects = new List<GameObject>();

    private int startMinDamage;
    private int startMaxDamage;

    [Header("Blood Effect")]
    public GameObject blood;
    [Range(1, 100)] public int minDamagePercentToBlood = 70;
    public int emission = 2;
    public float emissionImpulseAdd = 0.01f;
    public int maxEmission = 7;

    [Header("Hit Reaction")]
    public AudioSource hitAudio;



    // Use this for initialization
    void Start () {

        startMaxDamage = maxDamage;
        startMinDamage = minDamage;

	}

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerStay(Collider other)
    {
        
        
           // Debug.LogError(other.transform.root.tag + "  " + other.transform.name, other.gameObject);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        // Debug.LogError(other.transform.name + " + " + other.transform.root.tag, other.gameObject);
       // Debug.LogError("s1");
        if (Array.IndexOf(DamageTags, other.transform.root.tag)>-1)// && other.GetComponent<Collider>().attachedRigidbody)
        {
            Debug.LogError("s2");
            if (!damagedObjects.Contains(other.transform.root.gameObject))
            {
                Debug.LogError("s3");
                if (true)//!other.gameObject.transform.root.Find("Character Controller").GetComponent<CharacterPublicVariables>().blocking)
                {
                    Debug.LogError("s4");
                    Debug.LogError("damage");
                    randomValue = UnityEngine.Random.Range(0f, 100f);
                    Vector3 dir = other.transform.position - transform.position; //collision.transform.root.Find("Character Controller").position;
                                                                                 // Debug.LogError(dir + "" + dir.normalized);
                    var broadcaster = other.GetComponent<Collider>().attachedRigidbody.GetComponent<MuscleCollisionBroadcaster>();
                    if (broadcaster != null)
                    {

                        int randomForce = (int)(((randomValue * (maxForce - minForce)) / 100) + minForce);
                        ////////////////
                        Vector3 relativePos;
                        if (transform.root.Find("Character Controller"))
                            relativePos = other.transform.root.Find("Character Controller").position - transform.root.Find("Character Controller").position;
                        else
                            relativePos = other.transform.root.Find("Character Controller").position - transform.position;
                        Quaternion rotation = Quaternion.LookRotation(relativePos);
                        float rot = Mathf.Abs((other.transform.root.Find("Character Controller").eulerAngles.y - rotation.eulerAngles.y));
                        //float rot = Mathf.Abs((other.transform.root.Find("Character Controller").eulerAngles.y - transform.root.Find("Character Controller").eulerAngles.y));

                        //Debug.LogError(other.transform.root.Find("Character Controller").eulerAngles + "   " + transform.root.Find("Character Controller").eulerAngles + "    " + (other.transform.root.Find("Character Controller").eulerAngles.y - transform.root.Find("Character Controller").eulerAngles.y));
                        //broadcaster.Hit(unpin, dir.normalized * randomForce,other.transform.position,randomValue>hitReactionMinForcePercent,rot);
                        Animator animator;
                        BehaviourPuppet behaviourPuppet = other.transform.root.Find("Behaviours/Puppet").GetComponent<BehaviourPuppet>();
                        animator = other.transform.root.Find("Character Controller/Animation Controller").GetComponent<Animator>();
                        if (randomValue > hitReactionMinForcePercent && animator.GetFloat("HitTurn") == 0f && behaviourPuppet.state == BehaviourPuppet.State.Puppet)
                        {
                            broadcaster.Hit(unpin, dir.normalized * 0, other.transform.position, randomValue > hitReactionMinForcePercent, rot);
                            animator.SetFloat("HitTurn", rot);
                            animator.Play("HitReaction", -1);
                        }
                        else if (animator.GetFloat("HitTurn") != 0f || behaviourPuppet.state != BehaviourPuppet.State.Puppet)
                        {
                            broadcaster.Hit(unpin, dir.normalized * randomForce, other.transform.position, randomValue > hitReactionMinForcePercent, rot);
                        }
                        //Blood Effect
                        if (randomValue >= minDamagePercentToBlood && blood)
                        {
                            var bloodd = Instantiate(blood, other.transform.position, other.transform.rotation);
                            //blood.transform.parent = other.transform;
                            bloodd.transform.LookAt(transform.root.Find("Character Controller").transform.position);
                            bloodd.GetComponent<ParticleSystem>().Emit(Mathf.Min(emission + (int)(emissionImpulseAdd * randomValue), maxEmission));

                        }

                        //Debug.LogError(rot);
                        //broadcaster.Hit()
                    }
                    ///
                    damagedObjects.Add(other.transform.root.gameObject);
                    ///
                    int damage = (int)(((randomValue * (maxDamage - minDamage)) / 100) + minDamage);
                    //Random.Range(minDamage, maxDamage);
                    if (other.transform.root.Find("Stats"))
                        other.transform.root.Find("Stats").GetComponent<PlayerStats>().DamageIt(damage);
                    //collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(2000, transform.position, 1000);

                    // other.GetComponent<getParent>().parent.GetComponent<PlayerStats>().HP -= 20;
                }
                else
                {
                    Debug.LogError("Blocked :)");
                }


            }
            
            if (destroyOnTriggerEnter)
                Destroy(gameObject);
        }
        else if (other != null && other.transform.root.gameObject.layer == LayerMask.NameToLayer("Terrain") && Array.IndexOf(DamageTags, other.transform.root.tag) > -1)
        {
            //Debug.LogError("buil");
            if (!damagedObjects.Contains(other.transform.root.gameObject))
            {
                randomValue = UnityEngine.Random.Range(0f, 100f);
                ///
                damagedObjects.Add(other.transform.root.gameObject);
                ///
                int damage = (int)(((randomValue * (maxDamage - minDamage)) / 100) + minDamage);
                //Random.Range(minDamage, maxDamage);
                if (other.transform.root.Find("Stats"))
                    other.transform.root.Find("Stats").GetComponent<PlayerStats>().DamageIt(damage);


            }
            if (destroyOnTriggerEnter)
                Destroy(gameObject);
        }
        if (cleaerArray)
            clearArray();
        

    }
    
    public void clearArray()
    {
     //   Debug.LogError("clear");
        damagedObjects.Clear();
    }
    public void setMaxDamage( int max)
    {
        maxDamage = max;
      
    }
    public void setMinDamage(int min)
    {
         minDamage = min;
    }
    public void returnToStartDamageValues()
    {
           maxDamage = startMaxDamage ;
           minDamage = startMinDamage;
    }
    
}
