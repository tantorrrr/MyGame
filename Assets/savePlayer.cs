using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
#if (UNITY_STANDALONE || UNITY_EDITOR_WIN || UNITY_EDITOR_OSX ) && (!UNITY_WEBPLAYER && !UNITY_WEBGL && !UNITY_ANDROID && !UNITY_IOS)
using System.Net.NetworkInformation;
#endif
using System.Net;
using System.Collections.Generic;
using System;
[Serializable]
public class savePlayer : MonoBehaviour {
    private string info;
    public int playerID;
    public GameObject waitingPanel;
    [SerializeField] public string savePlayerURL;
    [SerializeField] public string securePassword;
    int NrScarsT; int NrEyeBrowT; int NrSkinFaceT; int NrColorNumberT; int NrColorPilosityT; int NrBeardT; int NrHairSkullT; int NrHeadAddT; int NrEyeT; int NrPantT; int NrTorsoT; int NrShoeT; int NrGloveT; int NrBeltT; int NrRobeLongT; int NrRobeShortT; int NrHairM; int NrHeadM; int NrJawM; int NrEyeM; int NrTorsoM; int NrTorsoAddM; int NrBeltM; int NrBeltAddM; int NrShoulderRM; int NrShoulderLM; int NrArmRM; int NrArmLM; int NrLegRM; int NrLegLM; int NrWeaponRM; int NrWeaponLM;

    // Use this for initialization
    void Start () {
#if (UNITY_STANDALONE || UNITY_EDITOR_WIN || UNITY_EDITOR_OSX) && !UNITY_WEBPLAYER
        ShowNetworkInterfaces();

#endif
        
    }
	
	// Update is called once per frame
	void Update () {
		playerID = PlayerPrefs.GetInt("userID");
    }
    public void ShowNetworkInterfaces()
    {
#if (UNITY_STANDALONE || UNITY_EDITOR_WIN || UNITY_EDITOR_OSX) && (!UNITY_WEBPLAYER && !UNITY_WEBGL && !UNITY_IOS && !UNITY_ANDROID)

        IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
        NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

        foreach (NetworkInterface adapter in nics)
        {
            PhysicalAddress address = adapter.GetPhysicalAddress();
            byte[] bytes = address.GetAddressBytes();
            string mac = null;
            for (int i = 0; i < bytes.Length; i++)
            {
                mac = string.Concat(mac + (string.Format("{0}", bytes[i].ToString("X2"))));
                if (i != bytes.Length - 1)
                {
                    mac = string.Concat(mac + "-");
                }
            }
            info += mac;

        }
#endif

    }
    public void SavePlayer(int NrScarsTex, int NrEyeBrowTex, int NrSkinFaceTex, int NrColorNumberTex, int NrColorPilosityTex, int NrBeardTex, int NrHairSkullTex, int NrHeadAddTex, int NrEyeTex, int NrPantTex, int NrTexorsoTex, int NrShoeTex, int NrGloveTex, int NrBeltTex, int NrRobeLongTex, int NrRobeShortTex, int NrHairModel, int NrHeadModel, int NrJawModel, int NrEyeModel, int NrTexorsoModel, int NrTexorsoAddModel, int NrBeltModel, int NrBeltAddModel, int NrShoulderRModel, int NrShoulderLModel, int NrArmRModel, int NrArmLModel, int NrLegRModel, int NrLegLModel, int NrWeaponRModel, int NrWeaponLModel)
    {
        NrScarsT = NrScarsTex; NrEyeBrowT = NrEyeBrowTex; NrSkinFaceT = NrSkinFaceTex; NrColorNumberT = NrColorNumberTex; NrColorPilosityT = NrColorPilosityTex; NrBeardT = NrBeardTex; NrHairSkullT = NrHairSkullTex; NrHeadAddT = NrHeadAddTex; NrEyeT = NrEyeTex; NrPantT = NrPantTex; NrTorsoT = NrTexorsoTex; NrShoeT = NrShoeTex; NrGloveT = NrGloveTex; NrBeltT = NrBeltTex; NrRobeLongT = NrRobeLongTex; NrRobeShortT = NrRobeShortTex; NrHairM = NrHairModel; NrHeadM = NrHeadModel; NrJawM = NrJawModel; NrEyeM = NrEyeModel; NrTorsoM = NrTexorsoModel; NrTorsoAddM = NrTexorsoAddModel; NrBeltM = NrBeltModel; NrBeltAddM = NrBeltAddModel; NrShoulderRM = NrShoulderRModel; NrShoulderLM = NrShoulderLModel; NrArmRM = NrArmRModel; NrArmLM = NrArmLModel; NrLegRM = NrLegRModel; NrLegLM = NrLegLModel; NrWeaponRM = NrWeaponRModel; NrWeaponLM = NrWeaponLModel;
        StartCoroutine(savePlayerCostomisation());
        //Invoke("CreatePlayer", 0.2f);

    }
    IEnumerator savePlayerCostomisation()
    {
        waitingPanel.SetActive(true);
        
#if (UNITY_STANDALONE || UNITY_EDITOR_WIN || UNITY_EDITOR_OSX) && (!UNITY_WEBPLAYER && !UNITY_WEBGL && !UNITY_ANDROID && !UNITY_IOS)

            string sends = savePlayerURL + "?" + "player_id=" + playerID + "&NrScarsTex=" + NrScarsT + "&NrEyeBrowTex=" + NrEyeBrowT + "&NrSkinFaceTex=" + NrSkinFaceT + "&NrColorNumberTex=" + NrColorNumberT + "&NrColorPilosityTex=" + NrColorPilosityT + "&NrBeardTex= " + NrBeardT + "&NrHairSkullTex=" + NrHairSkullT + "&NrHeadAddTex= " + NrHeadAddT + "&NrEyeTex=" + NrEyeT + "&NrPantTex= " + NrPantT + "&NrTexorsoTex=" + NrTorsoT + "&NrShoeTex= " + NrShoeT + "&NrGloveTex=" + NrGloveT + "&NrBeltTex= " + NrBeltT + "&NrRobeLongTex=" + NrRobeLongT+ "&NrRobeShortTex= " + NrRobeShortT + "&NrHairModel=" + NrHairM + "&NrHeadModel= " + NrHeadM + "&NrJawModel=" + NrJawM + "&NrEyeModel= " + NrEyeM + "&NrTexorsoModel=" + NrTorsoM + "&NrTexorsoAddModel= " + NrTorsoAddM + "&NrBeltModel=" + NrBeltM + "&NrBeltAddModel= " + NrBeltAddM + "&NrShoulderRModel=" + NrShoulderRM + "&NrShoulderLModel= " + NrShoulderLM + "&NrArmRModel=" + NrArmRM + "&NrArmLModel= " + NrArmLM + "&NrLegRModel=" + NrLegRM + "&NrLegLModel= " + NrLegLM + "&NrWeaponRModel=" + NrWeaponRM + "&NrWeaponLModel=" + NrWeaponLM + "&secure=" + securePassword.Trim();
        Debug.LogError(sends);
#endif
#if UNITY_WEBGL || UNITY_WEBPLAYER || UNITY_ANDROID || UNITY_IOS

			string sends = RegisterUrl + "?" + "firstname=" + firstName.text.Trim () + "&lastname=" + lastName.text.Trim () + "&age=" + Age.text.Trim () + "&country=" + Country.text.Trim () + "&username=" + userName.text.Trim () + "&email=" + Email.text.Trim () + "&password=" + Password.text.Trim () + "&mac=1&secure=" + securePassword.Trim ();

#endif
            WWW php_query = new WWW(sends);
            yield return php_query;
            if (php_query.text.Trim() == "1")
            {
            Debug.LogError(php_query.text);
            //GetLoginCanvas.ToggleCanvas("login");
        }
            else
            {
               // WarningMSG.text = php_query.text;
                Debug.LogError(php_query.text);
            }




        waitingPanel.SetActive(false);
    }
}
