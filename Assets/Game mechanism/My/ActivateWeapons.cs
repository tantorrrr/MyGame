using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWeapons : MonoBehaviour {
    public GameObject[] weapons;
    public Animator animator;
    public AudioSource audioSource;
    public bool leftWeapon;
    public bool rightWeapon;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(weapons[1])
        if (weapons[1].GetComponent<ObjectType>().objectType==ObjectType.objType.shield)
            animator.SetBool("LeftShield", true);
        else
            animator.SetBool("LeftWeapon", true);
        if(weapons[0])
        if (weapons[0].GetComponent<ObjectType>().objectType == ObjectType.objType.shield)
            animator.SetBool("RightShield", true);
        else
            animator.SetBool("RightWeapon", true);
       
    }
    public void ActivateWeapon(int number)
    {
        if (number < weapons.Length && weapons[number] != null)
        {
            if(weapons[number].layer != LayerMask.NameToLayer("WeaponOn") && audioSource)
                audioSource.Play();
            weapons[number].layer = LayerMask.NameToLayer("WeaponOn");
            for (int i = 0; i < weapons[number].transform.childCount; i++) {
                weapons[number].transform.GetChild(i).gameObject.layer = LayerMask.NameToLayer("WeaponOn");

            }
        }
        
       // Debug.LogError("sw");
       
    }
    public void DisactivateWeapon(int number)
    {
        if (number < weapons.Length && weapons[number] != null)
        {
            weapons[number].layer = LayerMask.NameToLayer("WeaponOff");
            for (int i = 0; i < weapons[number].transform.childCount; i++)
            {
                weapons[number].transform.GetChild(i).gameObject.layer = LayerMask.NameToLayer("WeaponOff");
                if(weapons[number].transform.GetChild(i).gameObject.GetComponent<Damage>())
                weapons[number].transform.GetChild(i).gameObject.GetComponent<Damage>().clearArray();

            }
            if (weapons[number].GetComponent<Damage>())
            weapons[number].GetComponent<Damage>().clearArray();

        }
            
    }
}
