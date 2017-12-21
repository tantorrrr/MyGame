using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {
    public GameObject[] objectsToActivate;
    public GameObject[] objectsToDisactivate;

    public maleEditor me;
    public GameObject objToSpawn;
    public GameObject ml;
    public PlayerInformations pi;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void start()
    {
        
        
        

        
         pi.SavePlayer(me.ScarsN, me.EyeBrowN, me.skinFaceN, me.colorNumber, me.colorPilosityNumber, me.BeardN, me.HairSkullN, me.headAddN, me.EyeN, me.PantN, me.TorsoN, me.ShoeN, me.GloveN, me.BeltN, me.robeLongN, me.robeShortN, me.hairModelN, me.headN, me.jawN, me.eyeN, me.torsoN, me.torsoAddN, me.beltN, me.beltAddN, me.shoulderRN, me.shoulderLN, me.armRN, me.armLN, me.legRN, me.legLN, me.weaponRN, me.weaponLN);
        foreach (GameObject obj in objectsToDisactivate)
        {
            Destroy(obj);
        }

        foreach (GameObject obj in objectsToActivate)
        {

            obj.SetActive(true);
        }
    }
    
}
