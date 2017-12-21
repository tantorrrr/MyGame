using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerMagicAttack2 : MonoBehaviour {
    public GameObject mgScriptObject;
    public string layerMask;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        
        if (LayerMask.LayerToName(other.transform.gameObject.layer) == layerMask)
        {
          //  Debug.Log(LayerMask.LayerToName(other.transform.gameObject.layer));
            
            mgScriptObject.GetComponent<MagicAttackScript2>().Damage(other);
        }
        //else
         //   Debug.Log(LayerMask.LayerToName(other.transform.gameObject.layer));

        



    }

}
