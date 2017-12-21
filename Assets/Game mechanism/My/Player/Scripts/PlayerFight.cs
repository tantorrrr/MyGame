using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using RootMotion.Dynamics;
using RootMotion.Demos;
using RootMotion;

public class PlayerFight : MonoBehaviour {
    //public bool[] useAimIK = { false, false, false };
    // public GameObject AimIk;
    //references
    [Header("References")]
    public Animator animator;
    public CharacterPuppet chPuppet;
    public CameraController cameraController;
    public ActivateWeapons weapons;
    
    //
    public Transform[] backSwordPlaces;
    public GameObject[] hands;
    public Transform[] handSwordPlaces;
    public CharacterMeleeDemo CMD;
    public UserControlThirdPerson userControlThirdPerson;

    [Header("Walking Camera Settings")]
    public float strafeMaxCameraDistance;
    public float strafeMinCameraDistance;
    public float directionalMaxCameraDistance;
    public float directionalMinCameraDistance;
    [Header("Weapon System")]
    //weapon system
    public bool weaponReady = true;
    public bool leftWeapon = false;
    public bool rightWeapon = false;
    // public  UnityEvent ev;
    // Use this for initialization
    void Start () {
        //weaponInHands = new Transform[weapons.weapons.Length];
        if(weapons.weapons.Length>0)
        hands = new GameObject[weapons.weapons.Length];
        for (int i = 0; i < weapons.weapons.Length; i++)
        {
           // weaponInHands[i] = weapons.weapons[i].transform;
            hands[i] = weapons.weapons[i].transform.parent.gameObject;
            
        }
        if (weapons.weapons[0])
        {
            rightWeapon = true;
            animator.SetBool("RightWeapon", rightWeapon);
        }
        if (weapons.weapons[1])
        {
            leftWeapon = true;
            animator.SetBool("LeftWeapon", leftWeapon);
        }
    }
	
	// Update is called once per frame
	void Update () {
        animator.SetFloat("AttackHeight", cameraController.y);
        InputChecker();
        /*
        if (Input.GetMouseButtonDown(0))
            animator.SetInteger("Attack", 1);
        else if(Input.GetMouseButtonDown(1))
            animator.SetInteger("Attack", 2);
        else if (Input.GetMouseButtonDown(2))
            animator.SetInteger("Attack", 3);
        else if (Input.GetKeyDown(KeyCode.E))
        {
           // animator.SetInteger("Attack", 4);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetInteger("Magic", 1);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetInteger("Magic", 2);
        }
        */
        // animator.SetInteger("Key", Input.GetMouseButtonDown(2) ? 0 : 3);
        /*
        // Mouse left button
        if (Input.GetMouseButtonDown(0))
        {
            if (useAimIK[0])
            {
                AimIk.SetActive(true);
            }
            GetComponent<Animator>().SetTrigger("Key");
        }
        // Mouse right button
        if (Input.GetMouseButtonDown(1))
        {
            
            if (useAimIK[1])
            {
                AimIk.SetActive(true);
            }
            GetComponent<Animator>().SetBool("Key1",true);
        }
        else if (Input.GetMouseButtonUp(1))
        {
            if (useAimIK[1])
            {
                AimIk.SetActive(false);
            }
            GetComponent<Animator>().SetBool("Key1", false);
        }
        // Mouse middle button
        if (Input.GetMouseButtonDown(2))
        {
            if (useAimIK[2])
            {
                AimIk.SetActive(true);
            }
            GetComponent<Animator>().SetTrigger("Key2");
        }*/

    }
    void EquipWeapon()
    {
        weaponReady = true;
        animator.SetBool("WeaponReady", weaponReady);
        CMD.moveMode = CharacterThirdPerson.MoveMode.Strafe;
        cameraController.maxDistance = strafeMaxCameraDistance;
        cameraController.minDistance = strafeMinCameraDistance;

        
    }
    void UnequipWeapon()
    {
        weaponReady = false;
        animator.SetBool("WeaponReady", weaponReady);
        CMD.moveMode = CharacterThirdPerson.MoveMode.Directional;
        cameraController.maxDistance = directionalMaxCameraDistance;
        cameraController.minDistance = directionalMinCameraDistance;

    }
    void EquipChecker()
    {

    }
    void InputChecker()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            animator.SetBool("Block", true);
           
        }
        if (Input.GetKeyUp(KeyCode.B))
        {
            animator.SetBool("Block", false);

        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!weaponReady)
                EquipWeapon();
            else
                UnequipWeapon();

        }
        if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
        {
            animator.SetInteger("Attack", 4);
        }
        else if (Input.GetMouseButton(0))
        {
            animator.SetInteger("Attack", 1);
        }
        else if (Input.GetMouseButton(1))
        {
            animator.SetInteger("Attack", 2);
        }
        else if (Input.GetMouseButton(2))
        {
            animator.SetInteger("Attack", 3);
        }
        else 
        {
            animator.SetInteger("Attack", 0);
        }
        
        if (weaponReady && Input.GetKey(KeyCode.LeftShift)) 
        {
            //userControlThirdPerson.state.move = userControlThirdPerson.state.move / 2;
            //Debug.LogError(userControlThirdPerson.state.move);
            
        }
        if (Input.GetKey(KeyCode.F))
        {
            animator.SetInteger("Attack", 7);
        }
    }
    public void getWeapon(bool v)
    {
        if (!v) {
            if(weapons.weapons[0])
            if (weapons.weapons[0].GetComponent<ObjectType>().objectType == ObjectType.objType.weapon)
            {
                weapons.weapons[0].transform.SetParent(backSwordPlaces[0], false);
                weapons.weapons[0].transform.position = backSwordPlaces[0].position;
                weapons.weapons[0].transform.rotation = backSwordPlaces[0].rotation;
                
            }
            else
            {
                weapons.weapons[0].transform.SetParent(backSwordPlaces[2], false);
                weapons.weapons[0].transform.position = backSwordPlaces[2].position;
                weapons.weapons[0].transform.rotation = backSwordPlaces[2].rotation;
                
            }
            if(weapons.weapons[1])
            if (weapons.weapons[1].GetComponent<ObjectType>().objectType == ObjectType.objType.weapon)
            {
                
                weapons.weapons[1].transform.SetParent(backSwordPlaces[1], false);
                weapons.weapons[1].transform.position = backSwordPlaces[1].position;
                weapons.weapons[1].transform.rotation = backSwordPlaces[1].rotation;
            }
            else
            {
                
                weapons.weapons[1].transform.SetParent(backSwordPlaces[3], false);
                weapons.weapons[1].transform.position = backSwordPlaces[3].position;
                weapons.weapons[1].transform.rotation = backSwordPlaces[3].rotation;
            }
            //weapons.weapons[i].transform.position = weapons.weapons[i].transform.position;



        }
        else
        {
            for (int i = 0; i < 2; i++)
            {
                if (weapons.weapons[i])
                {
                    weapons.weapons[i].transform.SetParent(handSwordPlaces[i], false);
                    weapons.weapons[i].transform.position = handSwordPlaces[i].position;
                    weapons.weapons[i].transform.rotation = handSwordPlaces[i].rotation;
                }
            }
        }
    }
}
