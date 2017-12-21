using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using RootMotion.Dynamics;
using RootMotion.Demos;
using RootMotion;
using UnityEngine.UI;

public class CharacterBehaviourController : MonoBehaviour
{
    //public bool[] useAimIK = { false, false, false };
    // public GameObject AimIk;
    public Animator animator;
    public CharacterPuppet chPuppet;
    public CameraController cameraController;
    public bool weaponReady = true;
    public ActivateWeapons weapons;
    public Transform[] backSwordPlaces;
    public GameObject[] hands;
    public Transform[] handSwordPlaces;
    public CharacterMeleeDemo CMD;
    public UserControlThirdPerson userControlThirdPerson;

    [Header("Strafe Walking")]
    public float strafeMaxCameraDistance;
    public float strafeMinCameraDistance;

    public float directionalMaxCameraDistance;
    public float directionalMinCameraDistance;

    [Header("Hand Power")]
    public int maxHandPower = 100;
    public float handPower;
    public int hitPowerReduction;
    public Image HandPowerImage;
    public float regeneration;
    public float regTime;


    // Use this for initialization
    void Start()
    {
        
        hands = new GameObject[weapons.weapons.Length];
        for (int i = 0; i < weapons.weapons.Length; i++)
        {
            hands[i] = weapons.weapons[i].transform.parent.gameObject;
        }
        InvokeRepeating("handPowerReg", regTime, regTime);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("AttackHeight", cameraController.y);
        InputChecker();
        

    }
    public void reduceHandPower()
    {
        if (handPower - hitPowerReduction > 0)
            handPower -= hitPowerReduction;
        else
            handPower = 0;
        if (handPower > 0)
        {
            UpdateHandPowerBar(handPower);
        }
        else
        {
            UpdateHandPowerBar(0);
        }
    }
    void handPowerReg()
    {
        if(handPower + regeneration < maxHandPower)
            handPower += regeneration;
        else
            handPower = maxHandPower;
        UpdateHandPowerBar(handPower);
    }
    private void UpdateHandPowerBar(float hp)
    {
        float left = 50f;
        float right = 250 - 2 * hp;
        float posY = -50f;
        float height = 30f;
        RectTransform this_rect = HandPowerImage.rectTransform;
        this_rect.anchorMin = new Vector2(0, 1);
        this_rect.anchorMax = new Vector2(1, 1);
        Vector2 temp = new Vector2(left, posY - (height / 2f));
        this_rect.offsetMin = temp;
        temp = new Vector3(-right, temp.y + height);
        this_rect.offsetMax = temp;

    }
    void InputChecker()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            animator.SetTrigger("Block");

        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            weaponReady = !weaponReady;
            animator.SetTrigger("ChangeWeapon");
            animator.SetBool("WeaponReady", weaponReady);

        }
        if (weaponReady)
        {
            CMD.moveMode = CharacterThirdPerson.MoveMode.Strafe;
            cameraController.maxDistance = strafeMaxCameraDistance;
            cameraController.minDistance = strafeMinCameraDistance;
        }
        else
        {
            CMD.moveMode = CharacterThirdPerson.MoveMode.Directional;
            cameraController.maxDistance = directionalMaxCameraDistance;
            cameraController.minDistance = directionalMinCameraDistance;
        }
        //Attack
        if (handPower - hitPowerReduction >= 0)
        {
            if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
            {
                animator.SetInteger("Attack", 4);
                weaponReady = true;
            }
            else if (Input.GetMouseButton(0))
            {
                animator.SetInteger("Attack", 1);
                weaponReady = true;
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


            if (Input.GetKey(KeyCode.F))
            {
                animator.SetInteger("Attack", 7);
            }
        }
        else
        {
            animator.SetInteger("Attack", 0);
        }



    }
    
    public void getWeapon(bool v)
    {
        if (!v)
        {
            for (int i = 0; i < weapons.weapons.Length; i++)
            {
                weapons.weapons[i].transform.SetParent(backSwordPlaces[i], false);
                weapons.weapons[i].transform.position = backSwordPlaces[i].position;
                weapons.weapons[i].transform.rotation = backSwordPlaces[i].rotation;
                


            }
        }
        else
        {
            for (int i = 0; i < weapons.weapons.Length; i++)
            {
                weapons.weapons[i].transform.SetParent(handSwordPlaces[i], false);
                weapons.weapons[i].transform.position = handSwordPlaces[i].position;
                weapons.weapons[i].transform.rotation = handSwordPlaces[i].rotation;

            }
        }
    }
}
