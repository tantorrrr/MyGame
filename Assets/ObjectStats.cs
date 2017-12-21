using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStats : MonoBehaviour {
    [Header("Stats:")]
    public float speed;
    public float attackSpeed;
    public float leftWeaponDamage;
    public float rightWeaponDamage;
    public float health;
    public float power;
    public float armor;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void updateStats()
    {
        PlayerStatistics ps = gameObject.transform.root.Find("Character Controller").GetComponent<PlayerStatistics>();
        ps.speed += speed;
        ps.attackSpeed += attackSpeed;
        ps.leftWeaponDamage += leftWeaponDamage;
        ps.rightWeaponDamage += rightWeaponDamage;
        ps.health += health;
        ps.power += power;
        ps.armor += armor;
    }
}
