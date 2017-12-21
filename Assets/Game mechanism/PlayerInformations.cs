using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInformations : MonoBehaviour {
    int NrScarsT; int NrEyeBrowT; int NrSkinFaceT; int NrColorNumberT; int NrColorPilosityT; int NrBeardT; int NrHairSkullT; int NrHeadAddT; int NrEyeT; int NrPantT; int NrTorsoT; int NrShoeT; int NrGloveT; int NrBeltT; int NrRobeLongT; int NrRobeShortT; int NrHairM; int NrHeadM; int NrJawM; int NrEyeM; int NrTorsoM; int NrTorsoAddM; int NrBeltM; int NrBeltAddM; int NrShoulderRM; int NrShoulderLM; int NrArmRM; int NrArmLM; int NrLegRM; int NrLegLM; int NrWeaponRM; int NrWeaponLM;
    
    public savePlayer saveP;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SavePlayer(int NrScarsTex, int NrEyeBrowTex, int NrSkinFaceTex, int NrColorNumberTex, int NrColorPilosityTex, int NrBeardTex, int NrHairSkullTex, int NrHeadAddTex, int NrEyeTex, int NrPantTex, int NrTexorsoTex, int NrShoeTex, int NrGloveTex, int NrBeltTex, int NrRobeLongTex, int NrRobeShortTex, int NrHairModel, int NrHeadModel, int NrJawModel, int NrEyeModel, int NrTexorsoModel, int NrTexorsoAddModel, int NrBeltModel, int NrBeltAddModel, int NrShoulderRModel, int NrShoulderLModel, int NrArmRModel, int NrArmLModel, int NrLegRModel, int NrLegLModel, int NrWeaponRModel, int NrWeaponLModel)
    {
        NrScarsT = NrScarsTex; NrEyeBrowT = NrEyeBrowTex; NrSkinFaceT = NrSkinFaceTex; NrColorNumberT = NrColorNumberTex; NrColorPilosityT = NrColorPilosityTex; NrBeardT = NrBeardTex; NrHairSkullT = NrHairSkullTex; NrHeadAddT = NrHeadAddTex; NrEyeT = NrEyeTex; NrPantT = NrPantTex; NrTorsoT = NrTexorsoTex; NrShoeT = NrShoeTex; NrGloveT = NrGloveTex; NrBeltT = NrBeltTex; NrRobeLongT = NrRobeLongTex; NrRobeShortT = NrRobeShortTex; NrHairM = NrHairModel; NrHeadM = NrHeadModel; NrJawM = NrJawModel; NrEyeM = NrEyeModel; NrTorsoM = NrTexorsoModel; NrTorsoAddM = NrTexorsoAddModel; NrBeltM = NrBeltModel; NrBeltAddM = NrBeltAddModel; NrShoulderRM = NrShoulderRModel; NrShoulderLM = NrShoulderLModel; NrArmRM = NrArmRModel; NrArmLM = NrArmLModel; NrLegRM = NrLegRModel; NrLegLM = NrLegLModel; NrWeaponRM = NrWeaponRModel; NrWeaponLM = NrWeaponLModel;
        saveP.SavePlayer(NrScarsT, NrEyeBrowT, NrSkinFaceT, NrColorNumberT, NrColorPilosityT, NrBeardT, NrHairSkullT, NrHeadAddT, NrEyeT, NrPantT, NrTorsoT, NrShoeT, NrGloveT, NrBeltT, NrRobeLongT, NrRobeShortT, NrHairM, NrHeadM, NrJawM, NrEyeM, NrTorsoM, NrTorsoAddM, NrBeltM, NrBeltAddM, NrShoulderRM, NrShoulderLM, NrArmRM, NrArmLM, NrLegRM, NrLegLM, NrWeaponRM, NrWeaponLM);
        
        

    }
    
    
}
