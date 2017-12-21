using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class freezeEffect : MonoBehaviour {
    public float freezeTime = 8f;
    public float freezeAnimationSpeed = 0.1f;
    public string[] enemyTags;
    public float effectTime = 5f;
    public List<GameObject> FreezeObjects = new List<GameObject>();
    public List<GameObject> CollisionsObjects = new List<GameObject>();
    private bool canFreeze = true;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    private void OnTriggerStay(Collider other)
    {
        if (!canFreeze)
            return;
        if (other != null && Array.IndexOf(enemyTags, other.transform.root.tag) > -1)
        {
            //Debug.LogError(collision.impulse);
            if (!FreezeObjects.Contains(other.transform.root.gameObject))
            {
                FreezeObjects.Add(other.transform.root.gameObject);
                //CollisionsObjects.Add(other.gameObject);
                other.transform.root.Find("Character Controller/Animation Controller").GetComponent<Animator>().SetFloat("Speed", freezeAnimationSpeed);
               // Debug.LogError(other.transform.root.gameObject.name);
                //Invoke("unfreezeObject", freezeTime);
                StartCoroutine(unfreezeObject(other.transform.root.gameObject));


            }
            
        }
        
    }
    
    private void OnTriggerExit(Collider other)
    {
        /*if (other != null && Array.IndexOf(enemyTags, other.transform.root.tag) > -1)
        {
            //Debug.LogError(collision.impulse);
            if (CollisionsObjects.Contains(other.gameObject))
            {
                FreezeObjects.Remove(other.transform.root.gameObject);
                CollisionsObjects.Remove(other.gameObject);
                other.transform.root.Find("Character Controller/Animation Controller").GetComponent<Animator>().SetFloat("Speed", 1);

            }

        }*/

    }
    public void startEffect()
    {
        canFreeze = true;
        Invoke("cantFreeze", effectTime);
    }
    private void cantFreeze()
    {
        canFreeze = false;
    }
    IEnumerator unfreezeObject(GameObject obj)
    {
        yield return new WaitForSeconds(freezeTime);
        FreezeObjects.Remove(obj.transform.root.gameObject);
        //CollisionsObjects.Remove(other.gameObject);
        obj.transform.root.Find("Character Controller/Animation Controller").GetComponent<Animator>().SetFloat("Speed", 1);
        
    }
}
