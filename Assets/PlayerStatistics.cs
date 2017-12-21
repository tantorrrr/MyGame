using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStatistics : MonoBehaviour {
    [Header("References")]
    public GameObject characterController;
    public Animator animator;

    [Header("Start Stats:")]
    public float Startspeed;
    public float StartattackSpeed;
    public float StartleftWeaponDamage;
    public float StartrightWeaponDamage;
    public float Starthealth;
    public float Startpower;
    public float StartArmor;
    [Header("Stats:")]
    public float speed;
    public float attackSpeed;
    public float leftWeaponDamage;
    public float rightWeaponDamage;
    public float health;
    public float power;
    public float armor;
    [Header("Canvas:")]
    public bool show = true;
    public Text speedText;
    public Text attackSpeedText;
    public Text leftWeaponDamageText;
    public Text rightWeaponDamageText;
    public Text healthText;
    public Text powerText;
    public Text armorText;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        getStatistics();
        showStats();
	}
    public void getStatistics()
    {
        clearStats();
        ObjectStats[] objectStats = characterController.GetComponentsInChildren<ObjectStats>();
        foreach(ObjectStats stat in objectStats)
        {
            speed+=stat.speed;
            attackSpeed+= stat.attackSpeed;
            leftWeaponDamage+= stat.leftWeaponDamage;
            rightWeaponDamage+= stat.rightWeaponDamage;
            health+= stat.health;
            power+= stat.power;
            armor += stat.armor;
        }
        if(animator)
        applyStats();

    }
    void clearStats()
    {
        speed = Startspeed;
        attackSpeed = StartattackSpeed;
        leftWeaponDamage = StartleftWeaponDamage;
        rightWeaponDamage = StartrightWeaponDamage;
        health = Starthealth;
        power = Startpower;
        armor = StartArmor;
    }
    public void showStats()
    {
        if (show)
        {
            speedText.text = speed.ToString();
            attackSpeedText.text = attackSpeed.ToString();
            leftWeaponDamageText.text = leftWeaponDamage.ToString();
            rightWeaponDamageText.text = rightWeaponDamage.ToString();
            healthText.text = health.ToString();
            powerText.text = power.ToString();

            armorText.text = armor.ToString();
        }
    }
    public void applyStats()
    {
        animator.SetFloat("AttackSpeed", attackSpeed);
        animator.SetFloat("Speed", speed );
    }
}
