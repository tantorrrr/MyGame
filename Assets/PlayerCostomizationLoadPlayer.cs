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
public class PlayerCostomizationLoadPlayer : MonoBehaviour {
    private string info;
    public SkinnedMeshRenderer playerMesh;
    public SkinnedMeshRenderer cloathMesh;
    public maleEditor me;
    [SerializeField] public string getPlayerURL;
    [SerializeField] public string securePassword;
    public bool offlineMode;
    [Header("Values:")]
    public int NrScarsT; public int NrEyeBrowT; public int NrSkinFaceT; public int NrColorNumberT; public int NrColorPilosityT; public int NrBeardT; public int NrHairSkullT; public int NrHeadAddT; public int NrEyeT; public int NrPantT; public int NrTorsoT; public int NrShoeT; public int NrGloveT; public int NrBeltT; public int NrRobeLongT; public int NrRobeShortT; public int NrHairM; public int NrHeadM; public int NrJawM; public int NrEyeM; public int NrTorsoM; public int NrTorsoAddM; public int NrBeltM; public int NrBeltAddM; public int NrShoulderRM; public int NrShoulderLM; public int NrArmRM; public int NrArmLM; public int NrLegRM; public int NrLegLM; public int NrWeaponRM; public int NrWeaponLM;

    // Use this for initialization
    void Start()
    {
#if (UNITY_STANDALONE || UNITY_EDITOR_WIN || UNITY_EDITOR_OSX) && !UNITY_WEBPLAYER
        ShowNetworkInterfaces();

#endif
        getPlayer();
    }

    // Update is called once per frame
    void Update()
    {

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
    public void getPlayer()
    {
        // NrScarsT = NrScarsTex; NrEyeBrowT = NrEyeBrowTex; NrSkinFaceT = NrSkinFaceTex; NrColorNumberT = NrColorNumberTex; NrColorPilosityT = NrColorPilosityTex; NrBeardT = NrBeardTex; NrHairSkullT = NrHairSkullTex; NrHeadAddT = NrHeadAddTex; NrEyeT = NrEyeTex; NrPantT = NrPantTex; NrTorsoT = NrTexorsoTex; NrShoeT = NrShoeTex; NrGloveT = NrGloveTex; NrBeltT = NrBeltTex; NrRobeLongT = NrRobeLongTex; NrRobeShortT = NrRobeShortTex; NrHairM = NrHairModel; NrHeadM = NrHeadModel; NrJawM = NrJawModel; NrEyeM = NrEyeModel; NrTorsoM = NrTexorsoModel; NrTorsoAddM = NrTexorsoAddModel; NrBeltM = NrBeltModel; NrBeltAddM = NrBeltAddModel; NrShoulderRM = NrShoulderRModel; NrShoulderLM = NrShoulderLModel; NrArmRM = NrArmRModel; NrArmLM = NrArmLModel; NrLegRM = NrLegRModel; NrLegLM = NrLegLModel; NrWeaponRM = NrWeaponRModel; NrWeaponLM = NrWeaponLModel;
        if(!offlineMode)
        StartCoroutine(LoadPlayer());
        else
            me.LoadPlayerCos(NrScarsT, NrEyeBrowT, NrSkinFaceT, NrColorNumberT, NrColorPilosityT, NrBeardT, NrHairSkullT, NrHeadAddT, NrEyeT, NrPantT, NrTorsoT, NrShoeT, NrGloveT, NrBeltT, NrRobeLongT, NrRobeShortT, NrHairM, NrHeadM, NrJawM, NrEyeM, NrTorsoM, NrTorsoAddM, NrBeltM, NrBeltAddM, NrShoulderRM, NrShoulderLM, NrArmRM, NrArmLM, NrLegRM, NrLegLM, NrWeaponRM, NrWeaponLM);

        //Invoke("CreatePlayer", 0.2f);

    }
    IEnumerator LoadPlayer()
    {


#if (UNITY_STANDALONE || UNITY_EDITOR_WIN || UNITY_EDITOR_OSX) && (!UNITY_WEBPLAYER && !UNITY_WEBGL && !UNITY_ANDROID && !UNITY_IOS)

        string sends = getPlayerURL + "?" + "player_id=" + PlayerPrefs.GetInt("userID") + "&secureid="  + securePassword.Trim();
        Debug.LogError(sends);
#endif
#if UNITY_WEBGL || UNITY_WEBPLAYER || UNITY_ANDROID || UNITY_IOS

			string sends = RegisterUrl + "?" + "firstname=" + firstName.text.Trim () + "&lastname=" + lastName.text.Trim () + "&age=" + Age.text.Trim () + "&country=" + Country.text.Trim () + "&username=" + userName.text.Trim () + "&email=" + Email.text.Trim () + "&password=" + Password.text.Trim () + "&mac=1&secure=" + securePassword.Trim ();

#endif
        WWW php_query = new WWW(sends);
        yield return php_query;
        Debug.LogError(php_query.text);
        string[] split = php_query.text.Split(',');

        if (split[0].Trim() == "1")
        {
            NrScarsT = int.Parse(split[2].Trim());
            NrEyeBrowT = int.Parse(split[3].Trim());
            NrSkinFaceT = int.Parse(split[4].Trim());
            NrColorNumberT = int.Parse(split[5].Trim());
            NrColorPilosityT = int.Parse(split[6].Trim());
            NrBeardT = int.Parse(split[7].Trim());
            NrHairSkullT = int.Parse(split[8].Trim());
            NrHeadAddT = int.Parse(split[9].Trim());
            NrEyeT = int.Parse(split[10].Trim());
            NrPantT = int.Parse(split[11].Trim());
            NrTorsoT = int.Parse(split[12].Trim());
            NrShoeT = int.Parse(split[13].Trim());
            NrGloveT = int.Parse(split[14].Trim());
            NrBeltT = int.Parse(split[15].Trim());
            NrRobeLongT = int.Parse(split[16].Trim());
            NrRobeShortT = int.Parse(split[17].Trim());
            NrHairM = int.Parse(split[18].Trim());
            NrHeadM = int.Parse(split[19].Trim());
            NrJawM = int.Parse(split[20].Trim());
            NrEyeM = int.Parse(split[21].Trim());
            NrTorsoM = int.Parse(split[22].Trim());
            NrTorsoAddM = int.Parse(split[23].Trim());
            NrBeltM = int.Parse(split[24].Trim());
            NrBeltAddM = int.Parse(split[25].Trim());
            NrShoulderRM = int.Parse(split[26].Trim());
            NrShoulderLM = int.Parse(split[27].Trim());
            NrArmRM = int.Parse(split[28].Trim());
            NrArmLM = int.Parse(split[29].Trim());
            NrLegRM = int.Parse(split[30].Trim());
            NrLegLM = int.Parse(split[31].Trim());
            NrWeaponRM = int.Parse(split[32].Trim());
            NrWeaponLM = int.Parse(split[33].Trim());
            
            // Debug.LogError(NrScarsT, NrEyeBrowT, NrSkinFaceT, NrColorNumberT, NrColorPilosityT, NrBeardT, NrHairSkullT, NrHeadAddT, NrEyeT, NrPantT, NrTorsoT, NrShoeT, NrGloveT, NrBeltT, NrRobeLongT, NrRobeShortT, NrHairM, NrHeadM, NrJawM, NrEyeM, NrTorsoM, NrTorsoAddM, NrBeltM, NrBeltAddM, NrShoulderRM, NrShoulderLM, NrArmRM, NrArmLM, NrLegRM, NrLegLM, NrWeaponRM, NrWeaponLM);
            me.LoadPlayerCos(NrScarsT, NrEyeBrowT, NrSkinFaceT, NrColorNumberT, NrColorPilosityT, NrBeardT, NrHairSkullT, NrHeadAddT, NrEyeT, NrPantT, NrTorsoT, NrShoeT, NrGloveT, NrBeltT, NrRobeLongT, NrRobeShortT, NrHairM, NrHeadM, NrJawM, NrEyeM, NrTorsoM, NrTorsoAddM, NrBeltM, NrBeltAddM, NrShoulderRM, NrShoulderLM, NrArmRM, NrArmLM, NrLegRM, NrLegLM, NrWeaponRM, NrWeaponLM);
            //playerMesh.enabled = true;
            //cloathMesh.enabled = true;
            // After Login do what you want ex. load new scene ...
            //Application.LoadLevel(1);

            //mainPanel.OpenPanel();


        }
        else if (split[0].Trim() == "2")
        {
            //  PlayerPrefs.SetString("TempUser", userName.text.Trim());
            //GetLoginCanvas.ToggleCanvas ("active");

        }
        else
        {
            //WarningMsg.text = split [0];
            Debug.LogError(split[0]);


        }





    }
}