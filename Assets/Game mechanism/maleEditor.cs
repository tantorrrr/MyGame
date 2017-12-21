using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Threading;
using System.Runtime.CompilerServices;


public class maleEditor : MonoBehaviour
{

    
    public bool loaded;
    // Here is what you need to change in the inspector when changing the character in the scene or if you lose the prefab connection

    public GameObject Character;                   //this is the prefab you will export you can plug the thirdperson controler or the character itself			
    public SkinnedMeshRenderer[] ModelRenderers;       //Renderers for the LOD character model 
    public GameObject[] cloak;                     //Renderers for the LOD cloak model 
    public GameObject[] ShortRobe;                 //Renderers for the LOD ShortRobe model 	
    public GameObject[] LongRobe;                  //Renderers for the LOD LongRobe model 		

    //  _____ _____  _______ _   _ ___ ___ 
    // |_   _| __\ \/ /_   _| | | | _ \ __|
    //   | | | _| >  <  | | | |_| |   / _| 
    //   |_| |___/_/\_\ |_|  \___/|_|_\___|


    public string CharacterRace;

    //system
    public Texture2D atlasBase;  //the full texture atlas template // the base texture

    public Renderer planeRend;    // the material rendere fore the model
    public Texture2D CombineAll;       // the texture that combine all other

   

    public Object[] atlasBaseSearchSkinFace;//search for the texture at directory 
    public Texture2D[] atlasBaseSkinFace;   //as Texture2D[]; array of headAdd texture
    public int skinFaceQ;                   //texture quantity array.Length
    public int skinFaceN;                   //Texture number to select
    public Texture2D skinFaceS;             //The selected texture2D in the array
    
    public int colorNumber;
   
    public Texture2D ColorSkinCombine;

    public Texture2D HeadAddCombine;
    public Object[] headAddSearch;          //search for the texture at directory 
    public Texture2D[] headAdd;             //as Texture2D[]; array of headAdd texture
    public int headAddQ;                    //texture quantity array.Length
    public int headAddN;                    //Texture number to select
    

    public Texture2D EyeBrowCombine;
    public Object[] EyeBrowSearch;          //search for the texture at directory 
    public Texture2D[] EyeBrow;             //as Texture2D[]; array of EyeBrow texture
    public int EyeBrowQ;                    //texture quantity array.Length
    public int EyeBrowN;                    //Texture number to select
    
    public Texture2D ScarsCombine;
    public Object[] ScarsSearch;          //search for the texture at directory 
    public Texture2D[] Scars;             //as Texture2D[]; array of Scars texture
    public int ScarsQ;                    //texture quantity array.Length
    public int ScarsN;                    //Texture number to select
   

    public Texture2D BeardCombine;
    public Object[] BeardSearch;          //search for the texture at directory 
    public Texture2D[] Beard;             //as Texture2D[]; array of Beard texture
    public int BeardQ;                    //texture quantity array.Length
    public int BeardN;                    //Texture number to select
   

    public Texture2D HairSkullCombine;
    public Object[] HairSkullSearch;          //search for the texture at directory 
    public Texture2D[] HairSkull;             //as Texture2D[]; array of HairSkull texture
    public int HairSkullQ;                    //texture quantity array.Length
    public int HairSkullN;                    //Texture number to select
   

    public Object[] EyeSearch;          //search for the texture at directory 
    public Texture2D[] Eye;             //as Texture2D[]; array of Eye texture
    public int EyeQ;                    //texture quantity array.Length
    public int EyeN;                    //Texture number to select
   

    public Texture2D EyeCombine;
    public Object[] PantSearch;          //search for the texture at directory 
    public Texture2D[] Pant;             //as Texture2D[]; array of Pant texture
    public int PantQ;                    //texture quantity array.Length
    public int PantN;                    //Texture number to select
   
    public Texture2D PantCombine;


    public Object[] TorsoSearch;          //search for the texture at directory 
    public Texture2D[] Torso;             //as Texture2D[]; array of Torso texture
    public int TorsoQ;                    //texture quantity array.Length
    public int TorsoN;                    //Texture number to select
   
    public Texture2D TorsoCombine;

    public Object[] ShoeSearch;          //search for the texture at directory 
    public Texture2D[] Shoe;             //as Texture2D[]; array of Shoe texture
    public int ShoeQ;                    //texture quantity array.Length
    public int ShoeN;                    //Texture number to select
   
    public Texture2D ShoeCombine;


    public Object[] GloveSearch;          //search for the texture at directory 
    public Texture2D[] Glove;             //as Texture2D[]; array of Glove texture
    public int GloveQ;                    //texture quantity array.Length
    public int GloveN;                    //Texture number to select
    
    public Texture2D GloveCombine;

    public Object[] BeltSearch;          //search for the texture at directory 
    public Texture2D[] Belt;             //as Texture2D[]; array of Belt texture
    public int BeltQ;                    //texture quantity array.Length
    public int BeltN;                    //Texture number to select
   
    public Texture2D BeltCombine;

   
    public int colorPilosityNumber = 0;
    
    public int randTunique = 0;     //number of tunique randomized
    
    public Object[] cloakSearch;          //search for the texture at directory 
    public Texture2D[] cloakTex;             //as Texture2D[]; array of Belt texture
    public int cloakQ;                    //texture quantity array.Length
    public int cloakN;                    //Texture number to select

    public Texture2D robeLongCombine;
    public bool robeLongB = false;
    public Object[] robeShortSearch;          //search for the texture at directory 
    public Texture2D[] robeShortTex;             //as Texture2D[]; array of Belt texture
    public int robeShortQ;                    //texture quantity array.Length
    public int robeShortN;                    //Texture number to select
   

    public Texture2D robeShortCombine;
    public bool robeShortB = false;
    public Object[] robeLongSearch;          //search for the texture at directory 
    public Texture2D[] robeLongTex;             //as Texture2D[]; array of Belt texture
    public int robeLongQ;                    //texture quantity array.Length
    public int robeLongN;                    //Texture number to select
   
    //    _   ___ __  __  ___  ___ 
    //   /_\ | _ \  \/  |/ _ \| _ \
    //  / _ \|   / |\/| | (_) |   /
    // /_/ \_\_|_\_|  |_|\___/|_|_\



    //feedback armor texture output
    public Material NoneMat;
    public GameObject planeArmor2048;
    public GameObject planeArmor1024;
    public GameObject planeArmor512;
    public Transform[] planeArmor2048Tex;
    public Transform[] planeArmor1024Tex;
    public Transform planeArmor512Tex;
    public Material MatArmor;
    public Material[] MatArmorPart;
    public int MatItemNumber = 0;

    // pilosity texture2D array for changing color on "ArmorPart pilosity" such as hair and beard
    public Texture2D[] hairTex;
    public int hairTexQ = 0;
    public Renderer[] lodHairGet;
    public Texture2D[] jawTex;
    public int jawTexQ = 0;
    public Renderer[] lodJawGet;

    // Moving Uw
    public int itemNumber = 0;
    public MeshFilter[] armorsParts = new MeshFilter[3];
    public GameObject[] equipedArmor;
    public GameObject[] AllArmor;

    public Texture2D TextureArmor;       //The atlas for FindObjectsOfTypeAll armor part
    public int AllArmorsPartN;          //the numero of the armor part 
    public int AllArmorsPartQ;         //quantity of armor part equiped
    public bool[] ArmorpartEquip;      // thos bool  say if a item by categorie is equiped or not 
    public GameObject[] AllArmorsPart;  // array of equiped stuff  
    public MeshFilter[] AllArmorsPartMesh;
    public Texture2D[] TextureArmorPart;
    public Texture2D weaponRArmorSTexture;


    

    //base anchor for item by category
    public Transform anchorHair;
    public Transform anchorHead;
    public Transform anchorJaw;
    public Transform anchorEye;
    public Transform anchorTorso;
    public Transform anchorTorsoAdd;
    public Transform anchorBelt;
    public Transform anchorBeltAdd;
    public Transform anchorShoulderR;
    public Transform anchorShoulderL;
    public Transform anchorArmR;
    public Transform anchorArmL;
    public Transform anchorLegR;
    public Transform anchorLegL;
    public Transform anchorWeaponL;
    public Transform anchorWeaponR;
    public Transform anchorFX;
    // Quantity of item by category
    public int headQ = 0;
    public int hairModelQ = 0;
    public int jawQ = 0;
    public int eyeQ = 0;
    public int torsoQ = 0;
    public int torsoAddQ = 0;
    public int beltQ = 0;
    public int beltAddQ = 0;
    public int shoulderRQ = 0;
    public int shoulderLQ = 0;
    public int armRQ = 0;
    public int armLQ = 0;
    public int legRQ = 0;
    public int legLQ = 0;
    public int weaponRQ = 0;
    public int weaponLQ = 0;
    public int FXQ = 0;
    // Item number selection by category
    public int headN = -1;
    public int hairModelN = -1;
    public int jawN = -1;
    public int eyeN = -1;
    public int torsoN = -1;
    public int torsoAddN = -1;
    public int beltN = -1;
    public int beltAddN = -1;
    public int shoulderRN = -1;
    public int shoulderLN = -1;
    public int armRN = -1;
    public int armLN = -1;
    public int legRN = -1;
    public int legLN = -1;
    public int weaponRN = -1;
    public int weaponLN = -1;
    public int FXN = -1;
    // Item selected by category
    public GameObject headArmorS;
    public GameObject hairModelS;
    public GameObject jawS;
    public GameObject eyeS;
    public GameObject torsoArmorS;
    public GameObject torsoAddArmorS;
    public GameObject beltArmorS;
    public GameObject beltAddArmorS;
    public GameObject shoulderRArmorS;
    public GameObject shoulderLArmorS;
    public GameObject armRArmorS;
    public GameObject armLArmorS;
    public GameObject legRArmorS;
    public GameObject legLArmorS;
    public GameObject weaponRArmorS;
    public GameObject weaponLArmorS;
    public GameObject FXArmorS;
    //ARRAY of Armor part, Weapon and Fx 
    public string[] headArmorSearch;
    public GameObject[] headArmor;
    public string[] eyeAddArmorSearch;
    public GameObject[] eyeAddArmor;
    public GameObject[] hairModel;
    public GameObject[] jaw;
    public GameObject[] torsoArmor;
    public string[] torsoArmorSearch;
    public GameObject[] torsoAddArmor;
    public string[] torsoAddArmorSearch;
    public GameObject[] beltArmor;
    public string[] beltArmorSearch;
    public GameObject[] beltAddArmor;
    public string[] shoulderRArmorSearch;
    public GameObject[] shoulderRArmor;
    public string[] shoulderLArmorSearch;
    public GameObject[] shoulderLArmor;
    public string[] armRArmorSearch;
    public GameObject[] armRArmor;
    public string[] armLArmorSearch;
    public GameObject[] armLArmor;
    public string[] legRArmorSearch;
    public GameObject[] legRArmor;
    public string[] legLArmorSearch;
    public GameObject[] legLArmor;
    public GameObject[] weaponRArmor;
    public GameObject[] weaponLArmor;
    public GameObject[] FXArmor;
    public GameObject[] FXHead;
    //ANCHOR BIPED BONES for armor and weapon 
    public Transform headAnchor;
    public Transform jawAnchor;
    public Transform torsoAnchor;
    public Transform beltAnchor;
    public Transform shoulderRAnchor;
    public Transform shoulderLAnchor;
    public Transform armRAnchor;
    public Transform armLAnchor;
    public Transform legRAnchor;
    public Transform legLAnchor;
    public Transform weaponRAnchor;
    public Transform weaponLAnchor;
    public Transform FXAnchor;
    // Button next and back for armor/weapon/Fx 
  

    // this variable increase for each created prefab during the play mode (runtime)
    public int SavedPrefabNum = 0;
    public bool firstTime = true;

    public GameObject WaitingPanel;
    ////////////////////////////////////////////////////////   ______________    ____  ______////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////  / ___/_  __/   |  / __ \/_  __/////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////  \__ \ / / / /| | / /_/ / / /   ////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////// ___/ // / / ___ |/ _, _/ / /    ////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////____//_/ /_/  |_/_/ |_| /_/     ////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////                    			 ////////////////////////////////////////////////////////

    private Transform findInChildrensByName(string chName)
    {
        Transform[] chtransforms = transform.root.GetComponentsInChildren<Transform>();
        for(int i = 0; i < chtransforms.Length; i++)
        {
            //Debug.LogError(chtransforms[i].gameObject.transform.name + "" + chtransforms.Length);
            if (chtransforms[i].gameObject.transform.name == chName)
            {
                
                return chtransforms[i].gameObject.transform;
            }
            
        }
        return null;
        
    }
    void startLoad()
    {
        // this will allow in the future update more character race
        CharacterRace = "HumanMale";

        //  _____ _____  _______ _   _ ___ ___ 
        // |_   _| __\ \/ /_   _| | | | _ \ __|
        //   | | | _| >  <  | | | |_| |   / _| 
        //   |_| |___/_/\_\ |_|  \___/|_|_\___|

        CombineAll = atlasBase;
        skinFaceS = atlasBase;
        ////LOADING CHARACTER TEXTURE////
        //At start this part of the script put textures of the character in aray liste of texture 2d  
        // the script search in project folder
        //       /!\ need to have a proper nomenclature folder and texture 


        // AtlasBase Texture SkinFace
        atlasBaseSearchSkinFace = Resources.LoadAll("Character_Editor/Textures/Character/HumanMale/HumanMale_Color/Color" + colorNumber);//.Cast.<Texture2D>().ToArray();
        ///Debug.LogError(Resources.LoadAll("Character_Editor/Textures/Character/HumanMale/HumanMale_Color/Color" + colorNumber).Length);
        //AssetDatabase.FindAssets ("HumanMale_Color"+colorNumber+"_FaceSkin t:texture2D", ["Assets/Character_Editor/Textures/Character/HumanMale/HumanMale_Color/Color"+colorNumber+""]); //Search For Color0 Texture get all SkinFace
        atlasBaseSkinFace = new Texture2D[atlasBaseSearchSkinFace.Length];
        for (int a = 0; a < atlasBaseSearchSkinFace.Length; ++a)
        {
            atlasBaseSkinFace[a] = Resources.Load("Character_Editor/Textures/Character/HumanMale/HumanMale_Color/Color0/HumanMale_Color0_FaceSkin" + a + "") as Texture2D;
            //Debug.LogError(Resources.Load("Character_Editor/Textures/Character/HumanMale/HumanMale_Color/Color0/HumanMale_Color0_FaceSkin" + a ));
        }
        skinFaceQ = atlasBaseSkinFace.Length;

        // HeadAdd Texture in folder 
        headAddSearch = Resources.LoadAll("Character_Editor/Textures/CharacterOutfit/Head_add");
        //AssetDatabase.FindAssets ("headAdd t:texture2D", ["Character_Editor/Textures/CharacterOutfit/Head_add"]);								 //search texture by name for array Length
        headAdd = new Texture2D[headAddSearch.Length];                                                                                              //resize array
        for (int b = 0; b < headAddSearch.Length; ++b)
        {                                                                                              //fill with Texture2D
            headAdd[b] = Resources.Load("Character_Editor/Textures/CharacterOutfit/Head_add/headAdd" + b + "") as Texture2D;
        }
        headAddQ = headAdd.Length;

        // EyeBrow Texture in folder
        EyeBrowSearch = Resources.LoadAll("Character_Editor/Textures/Character/HumanMale/HumanMale_Eyebrow/Color0");
        //AssetDatabase.FindAssets ("EyeBrow t:texture2D", ["Character_Editor/Textures/Character/HumanMale/HumanMale_Eyebrow/Color0"]);								 //search texture by name for array Length
        EyeBrow = new Texture2D[EyeBrowSearch.Length];                                                                                              //resize array
        for (int c = 0; c < EyeBrowSearch.Length; ++c)
        {                                                                                              //fill with Texture2D
            EyeBrow[c] = Resources.Load("Character_Editor/Textures/Character/HumanMale/HumanMale_Eyebrow/Color0/EyeBrow" + c + "_Color0") as Texture2D;
        }
        EyeBrowQ = EyeBrow.Length;
        //texture Quantity  
        // Scars Texture in folder  
        ScarsSearch = Resources.LoadAll("Character_Editor/Textures/Character/HumanMale/HumanMale_Scars");
        //AssetDatabase.FindAssets ("Scars t:texture2D", ["Character_Editor/Textures/Character/HumanMale/HumanMale_Scars"]);								 //search texture by name for array Length
        Scars = new Texture2D[ScarsSearch.Length];                                                                                              //resize array
        for (int d = 0; d < ScarsSearch.Length; ++d)
        {                                                                                              //fill with Texture2D
            Scars[d] = Resources.Load("Character_Editor/Textures/Character/HumanMale/HumanMale_Scars/Scars" + d + "") as Texture2D;
        }
        ScarsQ = Scars.Length;

        // Beard Texture in folder  
        BeardSearch = Resources.LoadAll("Character_Editor/Textures/Character/HumanMale/HumanMale_Beard/Color0");
        //AssetDatabase.FindAssets ("Beard t:texture2D", ["Character_Editor/Textures/Character/HumanMale/HumanMale_Beard/Color0"]);								 //search texture by name for array Length
        Beard = new Texture2D[BeardSearch.Length];                                                                                              //resize array
        for (int e = 0; e < BeardSearch.Length; ++e)
        {                                                                                              //fill with Texture2D
            Beard[e] = Resources.Load("Character_Editor/Textures/Character/HumanMale/HumanMale_Beard/Color0/Beard" + e + "_Color0") as Texture2D;
        }
        BeardQ = Beard.Length;

        // HairSkull Texture in folder  
        HairSkullSearch = Resources.LoadAll("Character_Editor/Textures/Character/HumanMale/HumanMale_HairSkull/Color0");                  //search texture by name for array Length
        HairSkull = new Texture2D[HairSkullSearch.Length];                                                                                              //resize array
        for (int g = 0; g < HairSkullSearch.Length; ++g)
        {                                                                                              //fill with Texture2D
            HairSkull[g] = Resources.Load("Character_Editor/Textures/Character/HumanMale/HumanMale_HairSkull/Color0/HumanMale_HairSkull" + g + "_Color0") as Texture2D;
        }
        HairSkullQ = HairSkull.Length;

        // Eye Texture in folder 
        EyeSearch = Resources.LoadAll("Character_Editor/Textures/Character/HumanMale/HumanMale_Eye");                                 //search texture by name for array Length
        Eye = new Texture2D[EyeSearch.Length];                                                                                              //resize array
        for (int f = 0; f < EyeSearch.Length; ++f)
        {                                                                                              //fill with Texture2D
            Eye[f] = Resources.Load("Character_Editor/Textures/Character/HumanMale/HumanMale_Eye/Eye" + f + "") as Texture2D;
        }
        EyeQ = Eye.Length;

        // Pant Texture in folder 
        PantSearch = Resources.LoadAll("Character_Editor/Textures/CharacterOutfit/Pant");                         //search texture by name for array Length
        Pant = new Texture2D[PantSearch.Length];                                                                                            //resize array
        for (int i = 0; i < PantSearch.Length; ++i)
        {                                                                                              //fill with Texture2D
            Pant[i] = Resources.Load("Character_Editor/Textures/CharacterOutfit/Pant/Pant" + i + "") as Texture2D;
        }
        PantQ = Pant.Length;

        // Torso Texture in folder 
        TorsoSearch = Resources.LoadAll("Character_Editor/Textures/CharacterOutfit/Torso");                           //search texture by name for array Length
        Torso = new Texture2D[TorsoSearch.Length];                                                                                              //resize array
        for (int j = 0; j < TorsoSearch.Length; ++j)
        {                                                                                              //fill with Texture2D
            Torso[j] = Resources.Load("Character_Editor/Textures/CharacterOutfit/Torso/Torso" + j + "") as Texture2D;
        }
        TorsoQ = Torso.Length;

        // Shoe Texture in folder 
        ShoeSearch = Resources.LoadAll("Character_Editor/Textures/CharacterOutfit/Shoe");                     //search texture by name for array Length
        Shoe = new Texture2D[ShoeSearch.Length];                                                                                            //resize array
        for (int k = 0; k < ShoeSearch.Length; ++k)
        {                                                                                              //fill with Texture2D
            Shoe[k] = Resources.Load("Character_Editor/Textures/CharacterOutfit/Shoe/Shoe" + k + "") as Texture2D;
        }
        ShoeQ = Shoe.Length;                                                                                                                                     //texture Quantity 

        // Glove Texture in folder 
        GloveSearch = Resources.LoadAll("Character_Editor/Textures/CharacterOutfit/Glove");                       //search texture by name for array Length
        Glove = new Texture2D[GloveSearch.Length];                                                                                              //resize array
        for (int l = 0; l < GloveSearch.Length; ++l)
        {                                                                                              //fill with Texture2D
            Glove[l] = Resources.Load("Character_Editor/Textures/CharacterOutfit/Glove/Glove" + l + "") as Texture2D;
        }
        GloveQ = Glove.Length;

        // Belt Texture in folder 
        BeltSearch = Resources.LoadAll("Character_Editor/Textures/CharacterOutfit/Belt");                             //search texture by name for array Length
        Belt = new Texture2D[BeltSearch.Length];                                                                                            //resize array
        for (int m = 0; m < BeltSearch.Length; ++m)
        {                                                                                              //fill with Texture2D
            Belt[m] = Resources.Load("Character_Editor/Textures/CharacterOutfit/Belt/Belt" + m + "") as Texture2D;
        }
        BeltQ = Belt.Length;
        // Cloak Texture in folder 

        cloakSearch = Resources.LoadAll("Character_Editor/Textures/Armor/Cloak");                         //search texture by name for array Length
        cloakTex = new Texture2D[cloakSearch.Length];                                                                                           //resize array
        for (int cl = 0; cl < cloakSearch.Length; ++cl)
        {                                                                                              //fill with Texture2D
            cloakTex[cl] = Resources.Load("Character_Editor/Textures/Armor/Cloak/A_Cloak_" + cl + "") as Texture2D;
        }
        cloakQ = cloakTex.Length;
        for (int clo2 = 0; clo2 < cloak.Length; clo2++)
        {
            cloak[clo2].SetActive(false);
        }
        // robeLong Texture in folder 
        robeLongSearch = Resources.LoadAll("Character_Editor/Textures/CharacterOutfit/RobeLong");                             //search texture by name for array Length
        robeLongTex = new Texture2D[robeLongSearch.Length];                                                                                             //resize array
        for (int rl = 0; rl < robeLongSearch.Length; ++rl)
        {                                                                                              //fill with Texture2D
            robeLongTex[rl] = Resources.Load("Character_Editor/Textures/CharacterOutfit/RobeLong/RobeLong" + rl + "") as Texture2D;
        }
        robeLongQ = robeLongTex.Length;

        // robeShort Texture in folder 
        robeShortSearch = Resources.LoadAll("Character_Editor/Textures/CharacterOutfit/RobeShort");                           //search texture by name for array Length
        robeShortTex = new Texture2D[robeShortSearch.Length];                                                                                           //resize array
        for (int rsh = 0; rsh < robeShortSearch.Length; ++rsh)
        {                                                                                              //fill with Texture2D
            robeShortTex[rsh] = Resources.Load("Character_Editor/Textures/CharacterOutfit/RobeShort/RobeShort" + rsh + "") as Texture2D;
        }
        robeShortQ = robeShortTex.Length;


        // lunch the texturing loop in the start function 
        //the character model receive the default texture combined 
        // default are the 0 texture in here folder(most of them are empty transparent png, only the faceskin colorskin and the pant have pixels)                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       //texture Quantity 
        StartCoroutine( ColorSkinF() );
        StartCoroutine(SkinFaceCombineF() );

        //    _   ___ __  __  ___  ___ 
        //   /_\ | _ \  \/  |/ _ \| _ \
        //  / _ \|   / |\/| | (_) |   /
        // /_/ \_\_|_\_|  |_|\___/|_|_\


        //get biped part 
        //!\\ YOU SHOULD HAVE ONLY 1 BIPED WITH THE SAME NOMENCLATURE IN YOUR SCENE TO WORK PROPRELY

        headAnchor = findInChildrensByName("Bip01_Head");
        jawAnchor = findInChildrensByName("Bip01_Jaw");
        torsoAnchor = findInChildrensByName("Bip01_Spine3");
        beltAnchor = findInChildrensByName("Bip01_Pelvis");
        shoulderRAnchor = findInChildrensByName("Bip01_R_UpperArm");
        shoulderLAnchor = findInChildrensByName("Bip01_L_UpperArm");
        armRAnchor = findInChildrensByName("Bip01_R_Forearm");
        armLAnchor = findInChildrensByName("Bip01_L_Forearm");
        legRAnchor = findInChildrensByName("Bip01_R_Calf");
        legLAnchor = findInChildrensByName("Bip01_L_Calf");
        weaponRAnchor = findInChildrensByName("Bip01_R_Weapon");
        weaponLAnchor = findInChildrensByName("Bip01_L_Weapon");
        FXAnchor = findInChildrensByName("Bip01_Spine3");


        // Set the number of the selected item for each categorie
        headN = 0;
        hairModelN = 0;
        jawN = 0;
        eyeN = 0;
        torsoN = 0;
        torsoAddN = 0;
        beltN = 0;
        beltAddN = 0;
        shoulderRN = 0;
        shoulderLN = 0;
        armRN = 0;
        armLN = 0;
        legRN = 0;
        legLN = 0;
        FXN = 0;
        weaponRN = 0;
        weaponLN = 0;

        // Find All Armor Part GameObject

        AllArmor = FindObjectsOfType(typeof(GameObject)) as GameObject[];


        // Find Helm and store
        for (int obj = 0; obj < AllArmor.Length; obj++) { if (AllArmor[obj].name.Contains("A_Helm_" + CharacterRace) && AllArmor[obj].transform.root == transform.root) { headQ++; } }
        headArmor = new GameObject[headQ];
        for (int p = 0; p < headQ; ++p)
        {
            headArmor[p] = GameObject.Find("A_Helm_" + CharacterRace + "_" + p + "");
        }

        // Find HairModel and store
        for (int hm = 0; hm < AllArmor.Length; hm++) { if (AllArmor[hm].name.Contains("A_HairModel_" + CharacterRace) && AllArmor[hm].transform.root == transform.root) { hairModelQ++; } }
        hairModel = new GameObject[hairModelQ];
        for (int hmo = 0; hmo < hairModelQ; ++hmo)
        {
            hairModel[hmo] = GameObject.Find("A_HairModel_" + CharacterRace + "_" + hmo + "");
        }

        // Find JawModel and store
        for (int jw = 0; jw < AllArmor.Length; jw++) { if (AllArmor[jw].name.Contains("A_Jaw_" + CharacterRace) && AllArmor[jw].transform.root == transform.root) { jawQ++; } }
        jaw = new GameObject[jawQ];
        for (int jwx = 0; jwx < jawQ; ++jwx)
        {
            jaw[jwx] = GameObject.Find("A_Jaw_" + CharacterRace + "_" + jwx + "");
        }

        // Find TorsoArmor and store
        for (int to = 0; to < AllArmor.Length; to++) { if (AllArmor[to].name.Contains("A_TorsoArmor_" + CharacterRace) && AllArmor[to].transform.root == transform.root) { torsoQ++; } }
        torsoArmor = new GameObject[torsoQ];
        for (int q = 0; q < torsoQ; ++q)
        {
            torsoArmor[q] = GameObject.Find("A_TorsoArmor_" + CharacterRace + "_" + q + "");
        }

        for (int be = 0; be < AllArmor.Length; be++) { if (AllArmor[be].name.Contains("A_Belt_" + CharacterRace) && AllArmor[be].transform.root == transform.root) { beltQ++; } }
        beltArmor = new GameObject[beltQ];
        for (int r = 0; r < beltQ; ++r)
        {
            beltArmor[r] = GameObject.Find("A_Belt_" + CharacterRace + "_" + r + "");
        }
        //			foreach( var Helm in AllArmor){
        //	Debug.Log("trouvées");
        for (int toa = 0; toa < AllArmor.Length; toa++) { if (AllArmor[toa].name.Contains("A_TorsoAdd_" + CharacterRace) && AllArmor[toa].transform.root == transform.root) { torsoAddQ++; } }
        torsoAddArmor = new GameObject[torsoAddQ];
        for (int s = 0; s < torsoAddQ; ++s)
        {
            torsoAddArmor[s] = GameObject.Find("A_TorsoAdd_" + CharacterRace + "_" + s + "");
        }

        for (int eyx = 0; eyx < AllArmor.Length; eyx++) { if (AllArmor[eyx].name.Contains("A_EyeAdd_" + CharacterRace) && AllArmor[eyx].transform.root == transform.root) { eyeQ++; } }
        eyeAddArmor = new GameObject[eyeQ];
        for (int x = 0; x < eyeQ; ++x)
        {                                                                                              //fill with Texture2D
            eyeAddArmor[x] = GameObject.Find("A_EyeAdd_" + CharacterRace + "_" + x + "");
        }

        for (int shr = 0; shr < AllArmor.Length; shr++) { if (AllArmor[shr].name.Contains("A_Shoulder_R_" + CharacterRace) && AllArmor[shr].transform.root == transform.root) { shoulderRQ++; } }
        shoulderRArmor = new GameObject[shoulderRQ];
        for (int o = 0; o < shoulderRQ; ++o)
        {                                                                                              //fill with Texture2D
            shoulderRArmor[o] = GameObject.Find("A_Shoulder_R_" + CharacterRace + "_" + o + "");
        }

        for (int shl = 0; shl < AllArmor.Length; shl++) { if (AllArmor[shl].name.Contains("A_Shoulder_L_" + CharacterRace) && AllArmor[shl].transform.root == transform.root) { shoulderLQ++; } }
        shoulderLArmor = new GameObject[shoulderLQ];
        for (int n = 0; n < shoulderLQ; ++n)
        {                                                                                              //fill with Texture2D
            shoulderLArmor[n] = GameObject.Find("A_Shoulder_L_" + CharacterRace + "_" + n + "");
        }

        for (int arr = 0; arr < AllArmor.Length; arr++) { if (AllArmor[arr].name.Contains("A_Arm_R_" + CharacterRace) && AllArmor[arr].transform.root == transform.root) { armRQ++; } }
        armRArmor = new GameObject[armRQ];
        for (int u = 0; u < armRQ; ++u)
        {                                                                                              //fill with Texture2D
            armRArmor[u] = GameObject.Find("A_Arm_R_" + CharacterRace + "_" + u + "");
        }

        for (int arl = 0; arl < AllArmor.Length; arl++) { if (AllArmor[arl].name.Contains("A_Arm_L_" + CharacterRace) && AllArmor[arl].transform.root == transform.root) { armLQ++; } }
        armLArmor = new GameObject[armLQ];
        for (int t = 0; t < armLQ; ++t)
        {                                                                                              //fill with Texture2D
            armLArmor[t] = GameObject.Find("A_Arm_L_" + CharacterRace + "_" + t + "");
        }

        for (int lel = 0; lel < AllArmor.Length; lel++) { if (AllArmor[lel].name.Contains("A_Leg_L_" + CharacterRace) && AllArmor[lel].transform.root == transform.root) { legLQ++; } }
        legLArmor = new GameObject[legLQ];
        for (int v = 0; v < legLQ; ++v)
        {                                                                                              //fill with Texture2D
            legLArmor[v] = GameObject.Find("A_Leg_L_" + CharacterRace + "_" + v + "");
        }

        for (int ler = 0; ler < AllArmor.Length; ler++) { if (AllArmor[ler].name.Contains("A_Leg_R_" + CharacterRace) && AllArmor[ler].transform.root == transform.root) { legRQ++; } }
        legRArmor = new GameObject[legRQ];
        for (int w = 0; w < legRQ; ++w)
        {                                                                                              //fill with Texture2D
            legRArmor[w] = GameObject.Find("A_Leg_R_" + CharacterRace + "_" + w + "");
        }

        for (int wr = 0; wr < AllArmor.Length; wr++) { if (AllArmor[wr].name.Contains("W_R_") && AllArmor[wr].transform.root == transform.root) { weaponRQ++; } }
        weaponRArmor = new GameObject[weaponRQ];
        for (int wir = 0; wir < weaponRQ; ++wir)
        {                                                                                              //fill with Texture2D
            weaponRArmor[wir] = GameObject.Find("W_R_" + wir + "");
        }

        for (int wl = 0; wl < AllArmor.Length; wl++) { if (AllArmor[wl].name.Contains("W_L_") && AllArmor[wl].transform.root == transform.root) { weaponLQ++; } }
        weaponLArmor = new GameObject[weaponLQ];
        for (int wil = 0; wil < weaponLQ; ++wil)
        {                                                                                              //fill with Texture2D
            weaponLArmor[wil] = GameObject.Find("W_L_" + wil + "");
        }

        for (int bea = 0; bea < AllArmor.Length; bea++) { if (AllArmor[bea].name.Contains("A_BeltAdd_" + CharacterRace) && AllArmor[bea].transform.root == transform.root) { beltAddQ++; } }
        beltAddArmor = new GameObject[beltAddQ];
        for (int ra = 0; ra < beltAddQ; ++ra)
        {
            beltAddArmor[ra] = GameObject.Find("A_BeltAdd_" + CharacterRace + "_" + ra + "");
        }

        // Find FxTorso and store
        for (int fxt = 0; fxt < AllArmor.Length; fxt++) { if (AllArmor[fxt].name.Contains("A_FXTorso_") && AllArmor[fxt].transform.root == transform.root) { FXQ++; } }
        FXArmor = new GameObject[FXQ];
        for (int fxu = 0; fxu < FXQ; ++fxu)
        {
            FXArmor[fxu] = GameObject.Find("A_FXTorso_" + fxu + "");
        }

        // how much armor by categorie
        // Set the quantity number of item for each category by the array Length
        headQ = headArmor.Length;
        hairModelQ = hairModel.Length;
        jawQ = jaw.Length;
        eyeQ = eyeAddArmor.Length;
        torsoQ = torsoArmor.Length;
        torsoAddQ = torsoAddArmor.Length;
        beltQ = beltArmor.Length;
        beltAddQ = beltAddArmor.Length;
        shoulderRQ = shoulderRArmor.Length;
        shoulderLQ = shoulderLArmor.Length;
        armRQ = armRArmor.Length;
        armLQ = armLArmor.Length;
        legRQ = legRArmor.Length;
        legLQ = legLArmor.Length;
        weaponRQ = weaponRArmor.Length;
        weaponLQ = weaponLArmor.Length;
        FXQ = FXArmor.Length;

        // Set a selected item for each category(the selected item is the one who will take place on the model it is the displayed model)
        headArmorS = headArmor[headN];
        hairModelS = hairModel[hairModelN];
        jawS = jaw[jawN];
        eyeS = eyeAddArmor[eyeN];
        torsoArmorS = torsoArmor[torsoN];
        torsoAddArmorS = torsoAddArmor[torsoAddN];
        beltArmorS = beltArmor[beltN];
        beltAddArmorS = beltAddArmor[beltAddN];
        shoulderRArmorS = shoulderRArmor[shoulderRN];
        shoulderLArmorS = shoulderLArmor[shoulderLN];
        armRArmorS = armRArmor[armRN];
        armLArmorS = armLArmor[armLN];
        legRArmorS = legRArmor[legRN];
        legLArmorS = legLArmor[legLN];
        weaponRArmorS = weaponRArmor[weaponRN];
        weaponLArmorS = weaponLArmor[weaponLN];
        FXArmorS = FXArmor[FXN];

        loaded = true;
        //yield return 0;
    }
    // Function start 
    void Start()
    {
        
        if (!firstTime)
            return;
        startLoad();

    }
    [System.Serializable]
    public enum ButtonRole
    {
        Next,
        Back,
        Clear
    }
    public void Change_PilosityColor_Texture(int value)
    {
        WaitingPanel.SetActive(true);
        if (value != 0)
        {
            colorPilosityNumber += value;
            StartCoroutine(PilosityColor());
        }
        else
        {
            colorPilosityNumber = 0;
            StartCoroutine( PilosityColor());
        }

    }
    public void Change_SkinColor_Texture(int value)
    {
        WaitingPanel.SetActive(true);
        if (value != 0)
        {
            colorNumber+=value;
            StartCoroutine(ColorSkinF());
            //await Task.Factory.StartNew
        }
        else
        {
            colorNumber = 0;
            StartCoroutine(ColorSkinF());
        }

    }
    public void Change_FaceSkin_Texture(int value)
    {
        WaitingPanel.SetActive(true);
        if (value != 0)
        {
            skinFaceN += value;
            StartCoroutine(SkinFaceCombineF());
        }
        else
        {
            skinFaceN = 0;
            StartCoroutine(SkinFaceCombineF());
        }

    }
    public void Change_ShadowHead_Texture(int value)
    {
        WaitingPanel.SetActive(true);
        if (value != 0)
        {
            headAddN += value;
            StartCoroutine(HeadAddCombineF());
        }
        else
        {
            headAddN = 0;
            StartCoroutine(HeadAddCombineF());
        }

    }
    public void Change_EyeBrow_Texture(int value)
    {
        WaitingPanel.SetActive(true);
        if (value != 0)
        {
            EyeBrowN += value;
            StartCoroutine(EyeBrowCombineF());
        }
        else
        {
            EyeBrowN = 0;
            StartCoroutine(EyeBrowCombineF());
        }

    }
    public void Change_Scars_Texture(int value)
    {
        WaitingPanel.SetActive(true);
        if (value != 0)
        {
            ScarsN += value;
            StartCoroutine(ScarsCombineF());
        }
        else
        {
            ScarsN = 0;
            StartCoroutine(ScarsCombineF());
        }

    }
    public void Change_Beard_Texture(int value)
    {
        WaitingPanel.SetActive(true);
        if (value != 0)
        {
            BeardN += value;
            StartCoroutine(BeardCombineF());
        }
        else
        {
            BeardN = 0;
            StartCoroutine(BeardCombineF());
        }

    }
    public void Change_HairSkull_Texture(int value)
    {
        WaitingPanel.SetActive(true);
        if (value != 0)
        {
            HairSkullN += value;
            StartCoroutine( HairSkullCombineF());
        }
        else
        {
            HairSkullN = 0;
            StartCoroutine(HairSkullCombineF());
        }

    }
    public void Change_Eye_Texture(int value)
    {
        WaitingPanel.SetActive(true);
        if (value != 0)
        {
            EyeN += value; StartCoroutine(EyeCombineF());
        }
        else
        {
            EyeN = 0;
            StartCoroutine(EyeCombineF());
        }

    }
    public void Change_Pant_Texture(int value)
    {
        WaitingPanel.SetActive(true);
        if (value != 0)
        {
            PantN += value; StartCoroutine(PantCombineF());
        }
        else
        {
            PantN = 0;
            StartCoroutine(PantCombineF());
        }

    }
    public void Change_Torso_Texture(int value)
    {
        WaitingPanel.SetActive(true);
        if (value != 0)
        {
            TorsoN += value; StartCoroutine(TorsoCombineF());
        }
        else
        {
            TorsoN = 0;
            StartCoroutine(TorsoCombineF());
        }

    }
    public void Change_Shoe_Texture(int value)
    {
        WaitingPanel.SetActive(true);
        if (value != 0)
        {
            ShoeN += value; StartCoroutine(ShoeCombineF());
        }
        else
        {
            ShoeN = 0;
            StartCoroutine(ShoeCombineF());
        }

    }
    public void Change_Glove_Texture(int value)
    {
        WaitingPanel.SetActive(true);
        if (value != 0)
        {
            GloveN += value; StartCoroutine(GloveCombineF());
        }
        else
        {
            GloveN = 0;
            StartCoroutine(GloveCombineF());
        }

    }
    public void Change_Belt_Texture(int value)
    {
        WaitingPanel.SetActive(true);
        if (value != 0)
        {
            BeltN += value; StartCoroutine(BeltCombineF());
        }
        else
        {
            BeltN = 0;
            StartCoroutine(BeltCombineF());
        }

    }
    /// <summary>
    /// Clothes
    /// </summary>

    public void Change_HeadArmor_Model(int value)
    {
        if (value != 0)
        {
            headArmorS.transform.position = anchorHead.position; headArmorS.transform.parent = anchorHead; headN += value; HeadEquip(); ArmorpartEquip[0] = true; FBTexArmor();
        }
        else
        {
            headArmorS.transform.position = anchorHead.position; headArmorS.transform.parent = anchorHair; ArmorpartEquip[0] = false; equipedArmor[0] = null; FBTexArmor();
        }
    }
    public void Change_Hair_Model(int value)
    {
        if (value != 0)
        {
            hairModelS.transform.position = anchorHair.position; hairModelS.transform.parent = anchorHair; hairModelN += value; hairModelEquip(); ArmorpartEquip[1] = true; FBTexArmor();
        }
        else
        {
            hairModelS.transform.position = anchorHair.position; hairModelS.transform.parent = anchorHair; ArmorpartEquip[1] = false; equipedArmor[1] = null; FBTexArmor();
        }

    }
    public void Change_Jaw_Model(int value)
    {
        if (value != 0)
        {
            jawS.transform.position = anchorJaw.position; jawS.transform.parent = anchorJaw; jawN += value; JawEquip(); ArmorpartEquip[2] = true; FBTexArmor();
        }
        else
        {
            jawS.transform.position = anchorJaw.position; jawS.transform.parent = anchorJaw; ArmorpartEquip[2] = false; equipedArmor[2] = null; FBTexArmor();
        }
    }
    public void Change_Torso_Model(int value)
    {
        if (value != 0)
        {
            torsoArmorS.transform.position = anchorTorso.position; torsoArmorS.transform.parent = anchorTorso; torsoN += value; TorsoEquip(); ArmorpartEquip[3] = true; FBTexArmor();
        }
        else
        {
            torsoArmorS.transform.position = anchorTorso.position; torsoArmorS.transform.parent = anchorTorso; ArmorpartEquip[3] = false; equipedArmor[3] = null; FBTexArmor();
        }

    }
    public void Change_TorsoAdd_Model(int value)
    {
        if (value != 0)
        {
            torsoAddArmorS.transform.position = anchorTorso.position; torsoAddArmorS.transform.parent = anchorTorso; torsoAddN += value; TorsoAddEquip(); ArmorpartEquip[4] = true; FBTexArmor();
        }
        else
        {
            torsoAddArmorS.transform.position = anchorTorso.position; torsoAddArmorS.transform.parent = anchorTorso; ArmorpartEquip[4] = false; equipedArmor[4] = null; FBTexArmor();
        }

    }
    public void Change_Belt_Model(int value)
    {
        if (value != 0)
        {
            beltArmorS.transform.position = anchorBelt.position; beltArmorS.transform.parent = anchorBelt; beltN+=value; BeltEquip(); ArmorpartEquip[5] = true; FBTexArmor();
        }
        else
        {
            beltArmorS.transform.position = anchorBelt.position; beltArmorS.transform.parent = anchorBelt; ArmorpartEquip[5] = false; equipedArmor[5] = null; FBTexArmor();
        }


    }
    public void Change_BeltAdd_Model(int value)
    {
        if (value != 0)
        {
            beltAddArmorS.transform.position = anchorBelt.position; beltAddArmorS.transform.parent = anchorBelt; beltAddN += value; BeltAddEquip(); ArmorpartEquip[6] = true; FBTexArmor();
        }
        else
        {
            beltAddArmorS.transform.position = anchorBelt.position; beltAddArmorS.transform.parent = anchorBelt; ArmorpartEquip[6] = false; equipedArmor[6] = null; FBTexArmor();
        }
    }
    public void Change_ShoulderArmorR_Model(int value)
    {
        if (value != 0)
        {
            shoulderRArmorS.transform.position = anchorShoulderR.position; shoulderRArmorS.transform.parent = anchorShoulderR; shoulderRN+=value; ShoulderREquip(); ArmorpartEquip[7] = true; FBTexArmor();
        }
        else
        {
            shoulderRArmorS.transform.position = anchorShoulderR.position; shoulderRArmorS.transform.parent = anchorShoulderR; ArmorpartEquip[7] = false; equipedArmor[7] = null; FBTexArmor();
        }
    }
    public void Change_ShoulderArmorL_Model(int value)
    {
        if (value != 0)
        {
            shoulderLArmorS.transform.position = anchorShoulderL.position; shoulderLArmorS.transform.parent = anchorShoulderL; shoulderLN+=value; ShoulderLEquip(); ArmorpartEquip[8] = true; FBTexArmor();
        }
        else
        {
            shoulderLArmorS.transform.position = anchorShoulderL.position; shoulderLArmorS.transform.parent = anchorShoulderL; ArmorpartEquip[8] = false; equipedArmor[8] = null; FBTexArmor();
        }
    }

    public void Change_ArmArmorR_Model(int value)
    {
        if (value != 0)
        {
            armRArmorS.transform.position = anchorArmR.position; armRArmorS.transform.parent = anchorArmR; armRN+=value; ArmREquip(); ArmorpartEquip[9] = true; FBTexArmor();
        }
        else
        {
            armRArmorS.transform.position = anchorArmR.position; armRArmorS.transform.parent = anchorArmR; ArmorpartEquip[9] = false; equipedArmor[9] = null; FBTexArmor();
        }
    }
    public void Change_ArmArmorL_Model(int value)
    {
        if (value != 0)
        {
            armLArmorS.transform.position = anchorArmL.position; armLArmorS.transform.parent = anchorArmL; armLN+=value; ArmLEquip(); ArmorpartEquip[10] = true; FBTexArmor();
        }
        else
        {
            armLArmorS.transform.position = anchorArmL.position; armLArmorS.transform.parent = anchorArmL; ArmorpartEquip[10] = false; equipedArmor[10] = null; FBTexArmor();
        }
    }
    public void Change_LegArmorR_Model(int value)
    {
        if (value != 0)
        {
            legRArmorS.transform.position = anchorLegR.position; legRArmorS.transform.parent = anchorLegR; legRN += value; LegREquip(); ArmorpartEquip[11] = true; FBTexArmor();
        }
        else
        {
            legRArmorS.transform.position = anchorLegR.position; legRArmorS.transform.parent = anchorLegL; ArmorpartEquip[11] = false; equipedArmor[11] = null; FBTexArmor();
        }
    }
    public void Change_LegArmorL_Model(int value)
    {
        if (value != 0)
        {
            legLArmorS.transform.position = anchorLegL.position; legLArmorS.transform.parent = anchorLegL; legLN+=value; LegLEquip(); ArmorpartEquip[12] = true; FBTexArmor();
        }
        else
        {
            legLArmorS.transform.position = anchorLegL.position; legLArmorS.transform.parent = anchorLegL; ArmorpartEquip[12] = false; equipedArmor[12] = null; FBTexArmor();
        }
    }
    public void Change_WeaponR_Model(int value)
    {
        if (value != 0)
        {
            weaponRArmorS.transform.position = anchorWeaponR.position; weaponRArmorS.transform.parent = anchorWeaponR; weaponRN+=value; WeaponREquip(); ArmorpartEquip[13] = true; FBTexArmor();
        }
        else
        {
            weaponRArmorS.transform.position = anchorWeaponR.position; weaponRArmorS.transform.parent = anchorWeaponR; weaponRN = 0; ArmorpartEquip[13] = false; equipedArmor[13] = null; FBTexArmor();
        }
    }
    public void Change_WeaponL_Model(int value)
    {
        if (value != 0)
        {
            weaponLArmorS.transform.position = anchorWeaponL.position; weaponLArmorS.transform.parent = anchorWeaponL; weaponLN+=value; WeaponLEquip(); ArmorpartEquip[14] = true; FBTexArmor();
        }
        else
        {
            weaponLArmorS.transform.position = anchorWeaponL.position; weaponLArmorS.transform.parent = anchorWeaponL; weaponLN = 0; ArmorpartEquip[14] = false; equipedArmor[14] = null; FBTexArmor();
        }
    }
    public void Change_FxArmor_Model(int value)
    {
        if (value != 0)
        {
            FXArmorS.transform.position = anchorFX.position; FXArmorS.transform.parent = anchorFX; FXN+=value; FXEquip(); FBTexArmor();
        }
        else
        {
            FXArmorS.transform.position = anchorFX.position; FXArmorS.transform.parent = anchorFX; FBTexArmor();
        }
    }
    public void Change_FxEye_Model(int value)
    {
        if (value != 0)
        {
            eyeS.transform.position = anchorEye.position; eyeS.transform.parent = anchorEye; eyeN+=value; EyeEquip(); FBTexArmor();
        }
        else
        {
            eyeS.transform.position = anchorEye.position; eyeS.transform.parent = anchorEye; FBTexArmor();
        }
    }
    public void Change_Cloak_Model(int value)
    {
        if (value != 0)
        {
            cloakN+=value; CloakOn();
        }
        else
        {
            CloakOff();
        }
    }
    public void Change_RobeLong_Model(int value)
    {
        if (value != 0)
        {
            robeLongN+=value; RobeLongOn(); robeLongB = true; RobeLongCombine();
        }
        else
        {
            robeLongN = 0; RobeLongOff(); robeLongB = false; RobeLongCombine();
        }
    }
    public void Change_RobeShort_Model(int value)
    {
        if (value != 0)
        {
            robeShortN+=value; RobeShortOn(); robeShortB = true; RobeShortCombine();
        }
        else
        {
            robeShortN = 0; RobeShortOff(); robeShortB = false; RobeShortCombine();
        }
    }
    public void RandomCos()
    {
        //remove all armor part from the model

        headArmorS.transform.position = anchorHead.position; headArmorS.transform.parent = anchorHead;
        hairModelS.transform.position = anchorHair.position; hairModelS.transform.parent = anchorHair;
        jawS.transform.position = anchorJaw.position; jawS.transform.parent = anchorJaw;
        eyeS.transform.position = anchorEye.position; eyeS.transform.parent = anchorEye;
        torsoArmorS.transform.position = anchorTorso.position; torsoArmorS.transform.parent = anchorTorso;
        torsoAddArmorS.transform.position = anchorTorso.position; torsoAddArmorS.transform.parent = anchorTorso;
        beltArmorS.transform.position = anchorBelt.position; beltArmorS.transform.parent = anchorBelt;
        beltAddArmorS.transform.position = anchorBelt.position; beltAddArmorS.transform.parent = anchorBelt;
        shoulderRArmorS.transform.position = anchorShoulderR.position; shoulderRArmorS.transform.parent = anchorShoulderR;
        shoulderLArmorS.transform.position = anchorShoulderL.position; shoulderLArmorS.transform.parent = anchorShoulderL;
        armLArmorS.transform.position = anchorArmL.position; armLArmorS.transform.parent = anchorArmL;
        armRArmorS.transform.position = anchorArmR.position; armRArmorS.transform.parent = anchorArmR;
        legRArmorS.transform.position = anchorLegR.position; legRArmorS.transform.parent = anchorLegR;
        legLArmorS.transform.position = anchorLegL.position; legLArmorS.transform.parent = anchorLegL;
        weaponRArmorS.transform.position = anchorWeaponR.position; weaponRArmorS.transform.parent = anchorWeaponR;
        weaponLArmorS.transform.position = anchorWeaponL.position; weaponLArmorS.transform.parent = anchorWeaponL;
        FXArmorS.transform.position = anchorFX.position; FXArmorS.transform.parent = anchorFX;

        // Random texture Skin
        // set the random range on each category of texture
        // - 5 because that make more chance no item is added to the model (you can modify this number to modify the randomness)

        ScarsN = Random.Range(0, ScarsQ);
        EyeBrowN = Random.Range(0, EyeBrowQ);
        skinFaceN = Random.Range(0, skinFaceQ);
        colorNumber = Random.Range(0, 5);
        colorPilosityNumber = Random.Range(0, 4);
        BeardN = Random.Range(0, BeardQ);
        HairSkullN = Random.Range(0, HairSkullQ);
        headAddN = Random.Range(0, headAddQ);
        EyeN = Random.Range(0, EyeQ);
        PantN = Random.Range(0, PantQ);
        TorsoN = Random.Range(0, TorsoQ);
        ShoeN = Random.Range(0, ShoeQ);
        GloveN = Random.Range(0, GloveQ);
        BeltN = Random.Range(0, BeltQ);
        //robeLongN = Random.Range(-5, robeLongQ);
        //if (robeLongN >= 1) { robeLongB = true; RobeLongOn(); }
        //if (robeLongN <= 0) { robeLongN = 0; robeLongB = false; RobeLongOff(); }
       /// robeShortN = Random.Range(-5, robeShortQ);
       // if (robeShortN >= 1) { robeShortB = true; RobeShortOn(); }
       // if (robeShortN <= 0) { robeShortN = 0; robeShortB = false; RobeShortOff(); }

       // Debug.Log(ScarsN);
        //Random armor mesh
        // set the number of the selected item to be placed on the model

        hairModelN = Random.Range(-5, hairModelQ);
        headN = Random.Range(-5, headQ);
        jawN = Random.Range(-1, jawQ);
        eyeN = Random.Range(-20, eyeQ);
        torsoN = Random.Range(-5, torsoQ);
        torsoAddN = Random.Range(-5, torsoAddQ);
        beltN = Random.Range(-5, beltQ);
        beltAddN = Random.Range(-5, beltAddQ);
        shoulderRN = Random.Range(-5, shoulderRQ);
        shoulderLN = shoulderRN;
        armRN = Random.Range(-5, armRQ);
        armLN = armRN;
        legRN = Random.Range(-5, legRQ);
        legLN = legRN;
        weaponRN = Random.Range(-5, weaponRQ);
        weaponLN = Random.Range(-5, weaponLQ);
        //FXN = Random.Range(-5,FXQ); // enable it if you want FxTorso be part of the random


        //lunch pilosity function to remap the color on the mesh hair and the texture color
        PilosityColor();

        // set all the bool  to false (no item is equiped)
        ArmorpartEquip[0] = false;
        ArmorpartEquip[1] = false;
        ArmorpartEquip[2] = false;
        ArmorpartEquip[3] = false;
        ArmorpartEquip[4] = false;
        ArmorpartEquip[5] = false;
        ArmorpartEquip[6] = false;
        ArmorpartEquip[7] = false;
        ArmorpartEquip[8] = false;
        ArmorpartEquip[9] = false;
        ArmorpartEquip[10] = false;
        ArmorpartEquip[11] = false;
        ArmorpartEquip[12] = false;
        ArmorpartEquip[13] = false;
        ArmorpartEquip[14] = false;

        //lunch texture feedback armor function 
        FBTexArmor();

        // IF ITEM SELECTED IS DIFFERENT FROM 0 LUNCH EQUIP FUNCTION		OTHERWISE//set bool  of equiped item to false, remove item from model equiped armor array, lunch feedback texture armor function,remove armor part from the model
        if (headN >= 0) { HeadEquip(); ArmorpartEquip[0] = true; } else { ArmorpartEquip[0] = false; equipedArmor[0] = null; FBTexArmor(); headArmorS.transform.position = anchorHead.position; headArmorS.transform.parent = anchorHead; }
        if (hairModelN >= 0) { hairModelEquip(); ArmorpartEquip[1] = true; } else { ArmorpartEquip[1] = false; equipedArmor[1] = null; FBTexArmor(); hairModelS.transform.position = anchorHair.position; hairModelS.transform.parent = anchorHead; }
        if (jawN >= 0) { JawEquip(); ArmorpartEquip[2] = true; } else { ArmorpartEquip[2] = false; equipedArmor[2] = null; FBTexArmor(); jawS.transform.position = anchorJaw.position; jawS.transform.parent = anchorJaw; }
        if (torsoN >= 0) { TorsoEquip(); ArmorpartEquip[3] = true; } else { ArmorpartEquip[3] = false; equipedArmor[3] = null; FBTexArmor(); torsoArmorS.transform.position = anchorTorso.position; torsoArmorS.transform.parent = anchorTorso; }
        if (torsoAddN >= 0) { TorsoAddEquip(); ArmorpartEquip[4] = true; } else { ArmorpartEquip[4] = false; equipedArmor[4] = null; FBTexArmor(); torsoAddArmorS.transform.position = anchorTorso.position; torsoAddArmorS.transform.parent = anchorTorso; }
        if (beltN >= 0) { BeltEquip(); ArmorpartEquip[5] = true; } else { ArmorpartEquip[5] = false; equipedArmor[5] = null; FBTexArmor(); beltArmorS.transform.position = anchorBelt.position; beltArmorS.transform.parent = anchorBelt; }
        if (beltAddN >= 0) { BeltAddEquip(); ArmorpartEquip[6] = true; } else { ArmorpartEquip[6] = false; equipedArmor[6] = null; FBTexArmor(); beltAddArmorS.transform.position = anchorBelt.position; beltAddArmorS.transform.parent = anchorBelt; }
        if (armLN >= 0) { ArmLEquip(); ArmorpartEquip[10] = true; } else { ArmorpartEquip[10] = false; equipedArmor[10] = null; FBTexArmor(); armLArmorS.transform.position = anchorArmL.position; armLArmorS.transform.parent = anchorArmL; }
        if (armRN >= 0) { ArmREquip(); ArmorpartEquip[9] = true; } else { ArmorpartEquip[9] = false; equipedArmor[9] = null; FBTexArmor(); armRArmorS.transform.position = anchorArmR.position; armRArmorS.transform.parent = anchorArmR; }
        if (legRN >= 0) { LegREquip(); ArmorpartEquip[11] = true; } else { ArmorpartEquip[11] = false; equipedArmor[11] = null; FBTexArmor(); legRArmorS.transform.position = anchorLegR.position; legRArmorS.transform.parent = anchorLegR; }
        if (legLN >= 0) { LegLEquip(); ArmorpartEquip[12] = true; } else { ArmorpartEquip[12] = false; equipedArmor[12] = null; FBTexArmor(); legLArmorS.transform.position = anchorLegL.position; legLArmorS.transform.parent = anchorLegL; }
        if (shoulderRN >= 0) { ShoulderREquip(); ArmorpartEquip[7] = true; } else { ArmorpartEquip[7] = false; equipedArmor[7] = null; FBTexArmor(); shoulderRArmorS.transform.position = anchorShoulderR.position; shoulderRArmorS.transform.parent = anchorShoulderR; }
        if (shoulderLN >= 0) { ShoulderLEquip(); ArmorpartEquip[8] = true; } else { ArmorpartEquip[8] = false; equipedArmor[8] = null; FBTexArmor(); shoulderLArmorS.transform.position = anchorShoulderL.position; shoulderLArmorS.transform.parent = anchorShoulderL; }
        if (weaponLN >= 0) { WeaponLEquip(); ArmorpartEquip[14] = true; } else { ArmorpartEquip[14] = false; equipedArmor[14] = null; FBTexArmor(); weaponLArmorS.transform.position = anchorWeaponL.position; weaponLArmorS.transform.parent = anchorWeaponL; }
        if (weaponRN >= 0) { WeaponREquip(); ArmorpartEquip[13] = true; } else { ArmorpartEquip[13] = false; equipedArmor[13] = null; FBTexArmor(); weaponRArmorS.transform.position = anchorWeaponR.position; weaponRArmorS.transform.parent = anchorWeaponR; }

        //if(FXN>=0){FXEquip();} else {FXArmorS.transform.position = anchorFX.position;FXArmorS.transform.parent = anchorFX;} if you want activate the fx in the randomness
        if (eyeN >= 0) { EyeEquip(); } else { eyeS.transform.position = anchorEye.position; eyeS.transform.parent = anchorEye; }

        // lunch feedback texture armor
        FBTexArmor();
    }


        ////////////////////////////////////////////////////////   __  ______  ____  ___  ____________////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////  / / / / __ \/ __ \/   |/_  __/ ____/////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////// / / / / /_/ / / / / /| | / / / __/   ////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////// /_/ / ____/ /_/ / ___ |/ / / /___   ////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////\____/_/   /_____/_/  |_/_/ /_____/   ////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////                                      ////////////////////////////////////////////////////////
        void Update()
    {
        // On click screen
       /* if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //  _____ _____  _______ _   _ ___ ___ 
            // |_   _| __\ \/ /_   _| | | | _ \ __|
            //   | | | _| >  <  | | | |_| |   / _| 
            //   |_| |___/_/\_\ |_|  \___/|_|_\___|

            // if button clik lunch function texture 
            //Color Pilosity
            if (PilosityColorButtonNext.Raycast(ray, out hit, 300.0f)) { colorPilosityNumber++; PilosityColor(); } //
            if (PilosityColorButtonBack.Raycast(ray, out hit, 300.0f)) { colorPilosityNumber--; PilosityColor(); }  //	
            if (PilosityColorButtonClear.Raycast(ray, out hit, 300.0f)) { colorPilosityNumber = 0; PilosityColor(); }  //				

            //ColorSkin Texture Switch
            if (skinColorButtonNext.Raycast(ray, out hit, 300.0f)) { colorNumber++; ColorSkinF(); } //
            if (skinColorButtonBack.Raycast(ray, out hit, 300.0f)) { colorNumber--; ColorSkinF(); }  //	
            if (skinColorButtonClear.Raycast(ray, out hit, 300.0f)) { colorNumber = 0; ColorSkinF(); }  //
                                                                                                        //faceSkin Texture Switch
            if (faceSkinButtonNext.Raycast(ray, out hit, 300.0f)) { skinFaceN++; SkinFaceCombineF(); } //
            if (faceSkinButtonBack.Raycast(ray, out hit, 300.0f)) { skinFaceN--; SkinFaceCombineF(); }
            if (faceSkinButtonClear.Raycast(ray, out hit, 300.0f)) { skinFaceN = 0; SkinFaceCombineF(); }

            //headAdd Texture Switch	
            if (headAddButtonNext.Raycast(ray, out hit, 300.0f)) { headAddN++; HeadAddCombineF(); } //
            if (headAddButtonBack.Raycast(ray, out hit, 300.0f)) { headAddN--; HeadAddCombineF(); }
            if (headAddButtonClear.Raycast(ray, out hit, 300.0f)) { headAddN = 0; HeadAddCombineF(); }

            //EyeBrow Texture Switch	
            if (EyeBrowButtonNext.Raycast(ray, out hit, 300.0f)) { EyeBrowN++; EyeBrowCombineF(); } //
            if (EyeBrowButtonBack.Raycast(ray, out hit, 300.0f)) { EyeBrowN--; EyeBrowCombineF(); }
            if (EyeBrowButtonClear.Raycast(ray, out hit, 300.0f)) { EyeBrowN = 0; EyeBrowCombineF(); }

            //Scars Texture Switch	
            if (ScarsButtonNext.Raycast(ray, out hit, 300.0f)) { ScarsN++; ScarsCombineF(); } //
            if (ScarsButtonBack.Raycast(ray, out hit, 300.0f)) { ScarsN--; ScarsCombineF(); }
            if (ScarsButtonClear.Raycast(ray, out hit, 300.0f)) { ScarsN = 0; ScarsCombineF(); }
            //Beard Texture Switch	
            if (BeardButtonNext.Raycast(ray, out hit, 300.0f)) { BeardN++; BeardCombineF(); } //
            if (BeardButtonBack.Raycast(ray, out hit, 300.0f)) { BeardN--; BeardCombineF(); }
            if (BeardButtonClear.Raycast(ray, out hit, 300.0f)) { BeardN = 0; BeardCombineF(); }

            //HairSkull Texture Switch	
            if (HairSkullButtonNext.Raycast(ray, out hit, 300.0f)) { HairSkullN++; HairSkullCombineF(); } //
            if (HairSkullButtonBack.Raycast(ray, out hit, 300.0f)) { HairSkullN--; HairSkullCombineF(); }
            if (HairSkullButtonClear.Raycast(ray, out hit, 300.0f)) { HairSkullN = 0; HairSkullCombineF(); }
            //Eye Texture Switch	
            if (EyeButtonNext.Raycast(ray, out hit, 300.0f)) { EyeN++; EyeCombineF(); } //
            if (EyeButtonBack.Raycast(ray, out hit, 300.0f)) { EyeN--; EyeCombineF(); }
            if (EyeButtonClear.Raycast(ray, out hit, 300.0f)) { EyeN = 0; EyeCombineF(); }

            //Pant Texture Switch	
            if (PantButtonNext.Raycast(ray, out hit, 300.0f)) { PantN++; PantCombineF(); } //
            if (PantButtonBack.Raycast(ray, out hit, 300.0f)) { PantN--; PantCombineF(); }
            if (PantButtonClear.Raycast(ray, out hit, 300.0f)) { PantN = 0; PantCombineF(); }

            //Torso Texture Switch	
            if (TorsoButtonNext.Raycast(ray, out hit, 300.0f)) { TorsoN++; TorsoCombineF(); } //
            if (TorsoButtonBack.Raycast(ray, out hit, 300.0f)) { TorsoN--; TorsoCombineF(); }
            if (TorsoButtonClear.Raycast(ray, out hit, 300.0f)) { TorsoN = 0; TorsoCombineF(); }

            //Shoe Texture Switch	
            if (ShoeButtonNext.Raycast(ray, out hit, 300.0f)) { ShoeN++; ShoeCombineF(); } //
            if (ShoeButtonBack.Raycast(ray, out hit, 300.0f)) { ShoeN--; ShoeCombineF(); }
            if (ShoeButtonClear.Raycast(ray, out hit, 300.0f)) { ShoeN = 0; ShoeCombineF(); }

            //Glove Texture Switch	
            if (GloveButtonNext.Raycast(ray, out hit, 300.0f)) { GloveN++; GloveCombineF(); } //
            if (GloveButtonBack.Raycast(ray, out hit, 300.0f)) { GloveN--; GloveCombineF(); }
            if (GloveButtonClear.Raycast(ray, out hit, 300.0f)) { GloveN = 0; GloveCombineF(); }

            //Belt Texture Switch	
            if (BeltButtonNext.Raycast(ray, out hit, 300.0f)) { BeltN++; BeltCombineF(); } //
            if (BeltButtonBack.Raycast(ray, out hit, 300.0f)) { BeltN--; BeltCombineF(); }
            if (BeltButtonClear.Raycast(ray, out hit, 300.0f)) { BeltN = 0; BeltCombineF(); }

            // random tunique 
            if (RandomTuniqueButton.Raycast(ray, out hit, 300.0f))
            {
                randTunique = Random.Range(1, 11);
                PantN = randTunique;
                TorsoN = randTunique;
                ShoeN = randTunique;
                robeLongN = randTunique;
                robeShortN = randTunique;
                GloveN = randTunique;
                BeltN = randTunique;
                PantCombineF();
            }
            // Random Face
            if (RandomFaceButton.Raycast(ray, out hit, 300.0f))
            {
                ScarsN = Random.Range(0, ScarsQ);
                EyeBrowN = Random.Range(0, EyeBrowQ);
                skinFaceN = Random.Range(0, skinFaceQ);
                colorNumber = Random.Range(0, 5);
                colorPilosityNumber = Random.Range(0, 4);
                BeardN = Random.Range(0, BeardQ);
                HairSkullN = Random.Range(0, HairSkullQ);
                //headAddN =Random.Range(0,headAddQ);
                EyeN = Random.Range(0, EyeQ);
                PilosityColor();
            }
            // clear texture set all to default texture 0	
            if (clearAllButton.Raycast(ray, out hit, 300.0f) || clearTex1.Raycast(ray, out hit, 300.0f))
            {
                BeltN = 0;
                GloveN = 0;
                ShoeN = 0;
                TorsoN = 0;
                PantN = 0;
                EyeN = 0;
                HairSkullN = 0;
                BeardN = 0;
                ScarsN = 0;
                EyeBrowN = 0;
                headAddN = 0;
                skinFaceN = 0;
                colorNumber = 0;
                ColorSkinF();
            }




            //    _   ___ __  __  ___  ___ 
            //   /_\ | _ \  \/  |/ _ \| _ \
            //  / _ \|   / |\/| | (_) |   /
            // /_/ \_\_|_\_|  |_|\___/|_|_\


            // Unequip selected item from model;
            // Increment value for the next selected item ;
            // set the bool  to true if an item is equiped
            // Lunch equip the selected item function;

            //Head 0

            if (head_next.Raycast(ray, out hit, 300.0f)) { headArmorS.transform.position = anchorHead.position; headArmorS.transform.parent = anchorHead; headN++; HeadEquip(); ArmorpartEquip[0] = true; FBTexArmor(); }
            if (head_back.Raycast(ray, out hit, 300.0f)) { headArmorS.transform.position = anchorHead.position; headArmorS.transform.parent = anchorHead; headN--; HeadEquip(); ArmorpartEquip[0] = true; FBTexArmor(); }
            if (head_clear.Raycast(ray, out hit, 300.0f) || clearAllButton.Raycast(ray, out hit, 300.0f) || clearTex2.Raycast(ray, out hit, 300.0f)) { headArmorS.transform.position = anchorHead.position; headArmorS.transform.parent = anchorHair; ArmorpartEquip[0] = false; equipedArmor[0] = null; FBTexArmor(); }
            //HairModel 1
            if (hairModel_next.Raycast(ray, out hit, 300.0f)) { hairModelS.transform.position = anchorHair.position; hairModelS.transform.parent = anchorHair; hairModelN++; hairModelEquip(); ArmorpartEquip[1] = true; FBTexArmor(); }
            if (hairModel_back.Raycast(ray, out hit, 300.0f)) { hairModelS.transform.position = anchorHair.position; hairModelS.transform.parent = anchorHair; hairModelN--; hairModelEquip(); ArmorpartEquip[1] = true; FBTexArmor(); }
            if (hairModel_clear.Raycast(ray, out hit, 300.0f) || clearAllButton.Raycast(ray, out hit, 300.0f) || clearTex2.Raycast(ray, out hit, 300.0f)) { hairModelS.transform.position = anchorHair.position; hairModelS.transform.parent = anchorHair; ArmorpartEquip[1] = false; equipedArmor[1] = null; FBTexArmor(); }
            //jaw 2
            if (jaw_next.Raycast(ray, out hit, 300.0f)) { jawS.transform.position = anchorJaw.position; jawS.transform.parent = anchorJaw; jawN++; JawEquip(); ArmorpartEquip[2] = true; FBTexArmor(); }
            if (jaw_back.Raycast(ray, out hit, 300.0f)) { jawS.transform.position = anchorJaw.position; jawS.transform.parent = anchorJaw; jawN--; JawEquip(); ArmorpartEquip[2] = true; FBTexArmor(); }
            if (jaw_clear.Raycast(ray, out hit, 300.0f) || clearAllButton.Raycast(ray, out hit, 300.0f) || clearTex2.Raycast(ray, out hit, 300.0f)) { jawS.transform.position = anchorJaw.position; jawS.transform.parent = anchorJaw; ArmorpartEquip[2] = false; equipedArmor[2] = null; FBTexArmor(); }
            //Torso 3
            if (torso_next.Raycast(ray, out hit, 300.0f)) { torsoArmorS.transform.position = anchorTorso.position; torsoArmorS.transform.parent = anchorTorso; torsoN++; TorsoEquip(); ArmorpartEquip[3] = true; FBTexArmor(); }
            if (torso_back.Raycast(ray, out hit, 300.0f)) { torsoArmorS.transform.position = anchorTorso.position; torsoArmorS.transform.parent = anchorTorso; torsoN--; TorsoEquip(); ArmorpartEquip[3] = true; FBTexArmor(); }
            if (torso_clear.Raycast(ray, out hit, 300.0f) || clearAllButton.Raycast(ray, out hit, 300.0f) || clearTex2.Raycast(ray, out hit, 300.0f)) { torsoArmorS.transform.position = anchorTorso.position; torsoArmorS.transform.parent = anchorTorso; ArmorpartEquip[3] = false; equipedArmor[3] = null; FBTexArmor(); }
            //TorsoAdd 4
            if (torsoAdd_next.Raycast(ray, out hit, 300.0f)) { torsoAddArmorS.transform.position = anchorTorso.position; torsoAddArmorS.transform.parent = anchorTorso; torsoAddN++; TorsoAddEquip(); ArmorpartEquip[4] = true; FBTexArmor(); }
            if (torsoAdd_back.Raycast(ray, out hit, 300.0f)) { torsoAddArmorS.transform.position = anchorTorso.position; torsoAddArmorS.transform.parent = anchorTorso; torsoAddN--; TorsoAddEquip(); ArmorpartEquip[4] = true; FBTexArmor(); }
            if (torsoAdd_clear.Raycast(ray, out hit, 300.0f) || clearAllButton.Raycast(ray, out hit, 300.0f) || clearTex2.Raycast(ray, out hit, 300.0f)) { torsoAddArmorS.transform.position = anchorTorso.position; torsoAddArmorS.transform.parent = anchorTorso; ArmorpartEquip[4] = false; equipedArmor[4] = null; FBTexArmor(); }
            //Belt 5			
            if (belt_next.Raycast(ray, out hit, 300.0f)) { beltArmorS.transform.position = anchorBelt.position; beltArmorS.transform.parent = anchorBelt; beltN++; BeltEquip(); ArmorpartEquip[5] = true; FBTexArmor(); }
            if (belt_back.Raycast(ray, out hit, 300.0f)) { beltArmorS.transform.position = anchorBelt.position; beltArmorS.transform.parent = anchorBelt; beltN--; BeltEquip(); ArmorpartEquip[5] = true; FBTexArmor(); }
            if (belt_clear.Raycast(ray, out hit, 300.0f) || clearAllButton.Raycast(ray, out hit, 300.0f) || clearTex2.Raycast(ray, out hit, 300.0f)) { beltArmorS.transform.position = anchorBelt.position; beltArmorS.transform.parent = anchorBelt; ArmorpartEquip[5] = false; equipedArmor[5] = null; FBTexArmor(); }
            //BeltAdd 6		
            if (beltAdd_next.Raycast(ray, out hit, 300.0f)) { beltAddArmorS.transform.position = anchorBelt.position; beltAddArmorS.transform.parent = anchorBelt; beltAddN++; BeltAddEquip(); ArmorpartEquip[6] = true; FBTexArmor(); }
            if (beltAdd_back.Raycast(ray, out hit, 300.0f)) { beltAddArmorS.transform.position = anchorBelt.position; beltAddArmorS.transform.parent = anchorBelt; beltAddN--; BeltAddEquip(); ArmorpartEquip[6] = true; FBTexArmor(); }
            if (beltAdd_clear.Raycast(ray, out hit, 300.0f) || clearAllButton.Raycast(ray, out hit, 300.0f) || clearTex2.Raycast(ray, out hit, 300.0f)) { beltAddArmorS.transform.position = anchorBelt.position; beltAddArmorS.transform.parent = anchorBelt; ArmorpartEquip[6] = false; equipedArmor[6] = null; FBTexArmor(); }
            //ShoulderR 7  		
            if (shoulderR_next.Raycast(ray, out hit, 300.0f)) { shoulderRArmorS.transform.position = anchorShoulderR.position; shoulderRArmorS.transform.parent = anchorShoulderR; shoulderRN++; ShoulderREquip(); ArmorpartEquip[7] = true; FBTexArmor(); }
            if (shoulderR_back.Raycast(ray, out hit, 300.0f)) { shoulderRArmorS.transform.position = anchorShoulderR.position; shoulderRArmorS.transform.parent = anchorShoulderR; shoulderRN--; ShoulderREquip(); ArmorpartEquip[7] = true; FBTexArmor(); }
            if (shoulderR_clear.Raycast(ray, out hit, 300.0f) || clearAllButton.Raycast(ray, out hit, 300.0f) || clearTex2.Raycast(ray, out hit, 300.0f)) { shoulderRArmorS.transform.position = anchorShoulderR.position; shoulderRArmorS.transform.parent = anchorShoulderR; ArmorpartEquip[7] = false; equipedArmor[7] = null; FBTexArmor(); }
            //ShoulderL	8
            if (shoulderL_next.Raycast(ray, out hit, 300.0f)) { shoulderLArmorS.transform.position = anchorShoulderL.position; shoulderLArmorS.transform.parent = anchorShoulderL; shoulderLN++; ShoulderLEquip(); ArmorpartEquip[8] = true; FBTexArmor(); }
            if (shoulderL_back.Raycast(ray, out hit, 300.0f)) { shoulderLArmorS.transform.position = anchorShoulderL.position; shoulderLArmorS.transform.parent = anchorShoulderL; shoulderLN--; ShoulderLEquip(); ArmorpartEquip[8] = true; FBTexArmor(); }
            if (shoulderL_clear.Raycast(ray, out hit, 300.0f) || clearAllButton.Raycast(ray, out hit, 300.0f) || clearTex2.Raycast(ray, out hit, 300.0f)) { shoulderLArmorS.transform.position = anchorShoulderL.position; shoulderLArmorS.transform.parent = anchorShoulderL; ArmorpartEquip[8] = false; equipedArmor[8] = null; FBTexArmor(); }
            //ArmR 9		
            if (armR_next.Raycast(ray, out hit, 300.0f)) { armRArmorS.transform.position = anchorArmR.position; armRArmorS.transform.parent = anchorArmR; armRN++; ArmREquip(); ArmorpartEquip[9] = true; FBTexArmor(); }
            if (armR_back.Raycast(ray, out hit, 300.0f)) { armRArmorS.transform.position = anchorArmR.position; armRArmorS.transform.parent = anchorArmR; armRN--; ArmREquip(); ArmorpartEquip[9] = true; FBTexArmor(); }
            if (armR_clear.Raycast(ray, out hit, 300.0f) || clearAllButton.Raycast(ray, out hit, 300.0f) || clearTex2.Raycast(ray, out hit, 300.0f)) { armRArmorS.transform.position = anchorArmR.position; armRArmorS.transform.parent = anchorArmR; ArmorpartEquip[9] = false; equipedArmor[9] = null; FBTexArmor(); }
            //ArmL 10	
            if (armL_next.Raycast(ray, out hit, 300.0f)) { armLArmorS.transform.position = anchorArmL.position; armLArmorS.transform.parent = anchorArmL; armLN++; ArmLEquip(); ArmorpartEquip[10] = true; FBTexArmor(); }
            if (armL_back.Raycast(ray, out hit, 300.0f)) { armLArmorS.transform.position = anchorArmL.position; armLArmorS.transform.parent = anchorArmL; armLN--; ArmLEquip(); ArmorpartEquip[10] = true; FBTexArmor(); }
            if (armL_clear.Raycast(ray, out hit, 300.0f) || clearAllButton.Raycast(ray, out hit, 300.0f) || clearTex2.Raycast(ray, out hit, 300.0f)) { armLArmorS.transform.position = anchorArmL.position; armLArmorS.transform.parent = anchorArmL; ArmorpartEquip[10] = false; equipedArmor[10] = null; FBTexArmor(); }
            //LegR 11
            if (legR_next.Raycast(ray, out hit, 300.0f)) { legRArmorS.transform.position = anchorLegR.position; legRArmorS.transform.parent = anchorLegR; legRN++; LegREquip(); ArmorpartEquip[11] = true; FBTexArmor(); }
            if (legR_back.Raycast(ray, out hit, 300.0f)) { legRArmorS.transform.position = anchorLegR.position; legRArmorS.transform.parent = anchorLegR; legRN--; LegREquip(); ArmorpartEquip[11] = true; FBTexArmor(); }
            if (legR_clear.Raycast(ray, out hit, 300.0f) || clearAllButton.Raycast(ray, out hit, 300.0f) || clearTex2.Raycast(ray, out hit, 300.0f)) { legRArmorS.transform.position = anchorLegR.position; legRArmorS.transform.parent = anchorLegL; ArmorpartEquip[11] = false; equipedArmor[11] = null; FBTexArmor(); }
            // LegL 12
            if (legL_next.Raycast(ray, out hit, 300.0f)) { legLArmorS.transform.position = anchorLegL.position; legLArmorS.transform.parent = anchorLegL; legLN++; LegLEquip(); ArmorpartEquip[12] = true; FBTexArmor(); }
            if (legL_back.Raycast(ray, out hit, 300.0f)) { legLArmorS.transform.position = anchorLegL.position; legLArmorS.transform.parent = anchorLegL; legLN--; LegLEquip(); ArmorpartEquip[12] = true; FBTexArmor(); }
            if (legL_clear.Raycast(ray, out hit, 300.0f) || clearAllButton.Raycast(ray, out hit, 300.0f) || clearTex2.Raycast(ray, out hit, 300.0f)) { legLArmorS.transform.position = anchorLegL.position; legLArmorS.transform.parent = anchorLegL; ArmorpartEquip[12] = false; equipedArmor[12] = null; FBTexArmor(); }
            // WeaponR 13
            if (weaponR_next.Raycast(ray, out hit, 300.0f)) { weaponRArmorS.transform.position = anchorWeaponR.position; weaponRArmorS.transform.parent = anchorWeaponR; weaponRN++; WeaponREquip(); ArmorpartEquip[13] = true; FBTexArmor(); }
            if (weaponR_back.Raycast(ray, out hit, 300.0f)) { weaponRArmorS.transform.position = anchorWeaponR.position; weaponRArmorS.transform.parent = anchorWeaponR; weaponRN--; WeaponREquip(); ArmorpartEquip[13] = true; FBTexArmor(); }
            if (weaponR_clear.Raycast(ray, out hit, 300.0f) || clearAllButton.Raycast(ray, out hit, 300.0f) || clearTex2.Raycast(ray, out hit, 300.0f)) { weaponRArmorS.transform.position = anchorWeaponR.position; weaponRArmorS.transform.parent = anchorWeaponR; ArmorpartEquip[13] = false; equipedArmor[13] = null; FBTexArmor(); }
            // WeaponL	14
            if (weaponL_next.Raycast(ray, out hit, 300.0f)) { weaponLArmorS.transform.position = anchorWeaponL.position; weaponLArmorS.transform.parent = anchorWeaponL; weaponLN++; WeaponLEquip(); ArmorpartEquip[14] = true; FBTexArmor(); }
            if (weaponL_back.Raycast(ray, out hit, 300.0f)) { weaponLArmorS.transform.position = anchorWeaponL.position; weaponLArmorS.transform.parent = anchorWeaponL; weaponLN--; WeaponLEquip(); ArmorpartEquip[14] = true; FBTexArmor(); }
            if (weaponL_clear.Raycast(ray, out hit, 300.0f) || clearAllButton.Raycast(ray, out hit, 300.0f) || clearTex2.Raycast(ray, out hit, 300.0f)) { weaponLArmorS.transform.position = anchorWeaponL.position; weaponLArmorS.transform.parent = anchorWeaponL; ArmorpartEquip[14] = false; equipedArmor[14] = null; FBTexArmor(); }
            //FX
            if (FX_next.Raycast(ray, out hit, 300.0f)) { FXArmorS.transform.position = anchorFX.position; FXArmorS.transform.parent = anchorFX; FXN++; FXEquip(); FBTexArmor(); }
            if (FX_back.Raycast(ray, out hit, 300.0f)) { FXArmorS.transform.position = anchorFX.position; FXArmorS.transform.parent = anchorFX; FXN--; FXEquip(); FBTexArmor(); }
            if (FX_clear.Raycast(ray, out hit, 300.0f) || clearAllButton.Raycast(ray, out hit, 300.0f)) { FXArmorS.transform.position = anchorFX.position; FXArmorS.transform.parent = anchorFX; FBTexArmor(); }
            //EyeFx
            if (eye_next.Raycast(ray, out hit, 300.0f)) { eyeS.transform.position = anchorEye.position; eyeS.transform.parent = anchorEye; eyeN++; EyeEquip(); FBTexArmor(); }
            if (eye_back.Raycast(ray, out hit, 300.0f)) { eyeS.transform.position = anchorEye.position; eyeS.transform.parent = anchorEye; eyeN--; EyeEquip(); FBTexArmor(); }
            if (eye_clear.Raycast(ray, out hit, 300.0f) || clearAllButton.Raycast(ray, out hit, 300.0f)) { eyeS.transform.position = anchorEye.position; eyeS.transform.parent = anchorEye; FBTexArmor(); }
            //Cloak 
            if (cloak_next.Raycast(ray, out hit, 300.0f)) { cloakN++; CloakOn(); }
            if (cloak_back.Raycast(ray, out hit, 300.0f)) { cloakN--; CloakOn(); }
            if (cloak_clear.Raycast(ray, out hit, 300.0f) || clearAllButton.Raycast(ray, out hit, 300.0f)) { CloakOff(); }
            //RobeLong
            if (robeLong_next.Raycast(ray, out hit, 300.0f)) { robeLongN++; RobeLongOn(); robeLongB = true; RobeLongCombine(); }
            if (robeLong_back.Raycast(ray, out hit, 300.0f)) { robeLongN--; RobeLongOn(); robeLongB = true; RobeLongCombine(); }
            if (robeLong_clear.Raycast(ray, out hit, 300.0f) || clearAllButton.Raycast(ray, out hit, 300.0f)) { RobeLongOff(); robeLongB = false; RobeLongCombine(); }
            //RobeShort
            if (robeShort_next.Raycast(ray, out hit, 300.0f)) { robeShortN++; RobeShortOn(); robeShortB = true; RobeShortCombine(); }
            if (robeShort_back.Raycast(ray, out hit, 300.0f)) { robeShortN--; RobeShortOn(); robeShortB = true; RobeShortCombine(); }
            if (robeShort_clear.Raycast(ray, out hit, 300.0f) || clearAllButton.Raycast(ray, out hit, 300.0f)) { RobeShortOff(); robeShortB = false; RobeShortCombine(); }




            // RANDOM BUTTON 

            if (randomButton.Raycast(ray, out hit, 300.0f))
            {

                //remove all armor part from the model

                headArmorS.transform.position = anchorHead.position; headArmorS.transform.parent = anchorHead;
                hairModelS.transform.position = anchorHair.position; hairModelS.transform.parent = anchorHair;
                jawS.transform.position = anchorJaw.position; jawS.transform.parent = anchorJaw;
                eyeS.transform.position = anchorEye.position; eyeS.transform.parent = anchorEye;
                torsoArmorS.transform.position = anchorTorso.position; torsoArmorS.transform.parent = anchorTorso;
                torsoAddArmorS.transform.position = anchorTorso.position; torsoAddArmorS.transform.parent = anchorTorso;
                beltArmorS.transform.position = anchorBelt.position; beltArmorS.transform.parent = anchorBelt;
                beltAddArmorS.transform.position = anchorBelt.position; beltAddArmorS.transform.parent = anchorBelt;
                shoulderRArmorS.transform.position = anchorShoulderR.position; shoulderRArmorS.transform.parent = anchorShoulderR;
                shoulderLArmorS.transform.position = anchorShoulderL.position; shoulderLArmorS.transform.parent = anchorShoulderL;
                armLArmorS.transform.position = anchorArmL.position; armLArmorS.transform.parent = anchorArmL;
                armRArmorS.transform.position = anchorArmR.position; armRArmorS.transform.parent = anchorArmR;
                legRArmorS.transform.position = anchorLegR.position; legRArmorS.transform.parent = anchorLegR;
                legLArmorS.transform.position = anchorLegL.position; legLArmorS.transform.parent = anchorLegL;
                weaponRArmorS.transform.position = anchorWeaponR.position; weaponRArmorS.transform.parent = anchorWeaponR;
                weaponLArmorS.transform.position = anchorWeaponL.position; weaponLArmorS.transform.parent = anchorWeaponL;
                FXArmorS.transform.position = anchorFX.position; FXArmorS.transform.parent = anchorFX;

                // Random texture Skin
                // set the random range on each category of texture
                // - 5 because that make more chance no item is added to the model (you can modify this number to modify the randomness)

                ScarsN = Random.Range(0, ScarsQ);
                EyeBrowN = Random.Range(0, EyeBrowQ);
                skinFaceN = Random.Range(0, skinFaceQ);
                colorNumber = Random.Range(0, 5);
                colorPilosityNumber = Random.Range(0, 4);
                BeardN = Random.Range(0, BeardQ);
                HairSkullN = Random.Range(0, HairSkullQ);
                headAddN = Random.Range(0, headAddQ);
                EyeN = Random.Range(0, EyeQ);
                PantN = Random.Range(0, PantQ);
                TorsoN = Random.Range(0, TorsoQ);
                ShoeN = Random.Range(0, ShoeQ);
                GloveN = Random.Range(0, GloveQ);
                BeltN = Random.Range(0, BeltQ);
                robeLongN = Random.Range(-5, robeLongQ);
                if (robeLongN >= 1) { robeLongB = true; RobeLongOn(); }
                if (robeLongN <= 0) { robeLongN = 0; robeLongB = false; RobeLongOff(); }
                robeShortN = Random.Range(-5, robeShortQ);
                if (robeShortN >= 1) { robeShortB = true; RobeShortOn(); }
                if (robeShortN <= 0) { robeShortN = 0; robeShortB = false; RobeShortOff(); }

                Debug.Log(ScarsN);
                //Random armor mesh
                // set the number of the selected item to be placed on the model

                hairModelN = Random.Range(-5, hairModelQ);
                headN = Random.Range(-5, headQ);
                jawN = Random.Range(-1, jawQ);
                eyeN = Random.Range(-20, eyeQ);
                torsoN = Random.Range(-5, torsoQ);
                torsoAddN = Random.Range(-5, torsoAddQ);
                beltN = Random.Range(-5, beltQ);
                beltAddN = Random.Range(-5, beltAddQ);
                shoulderRN = Random.Range(-5, shoulderRQ);
                shoulderLN = shoulderRN;
                armRN = Random.Range(-5, armRQ);
                armLN = armRN;
                legRN = Random.Range(-5, legRQ);
                legLN = legRN;
                weaponRN = Random.Range(-5, weaponRQ);
                weaponLN = Random.Range(-5, weaponLQ);
                //FXN = Random.Range(-5,FXQ); // enable it if you want FxTorso be part of the random


                //lunch pilosity function to remap the color on the mesh hair and the texture color
                PilosityColor();

                // set all the bool  to false (no item is equiped)
                ArmorpartEquip[0] = false;
                ArmorpartEquip[1] = false;
                ArmorpartEquip[2] = false;
                ArmorpartEquip[3] = false;
                ArmorpartEquip[4] = false;
                ArmorpartEquip[5] = false;
                ArmorpartEquip[6] = false;
                ArmorpartEquip[7] = false;
                ArmorpartEquip[8] = false;
                ArmorpartEquip[9] = false;
                ArmorpartEquip[10] = false;
                ArmorpartEquip[11] = false;
                ArmorpartEquip[12] = false;
                ArmorpartEquip[13] = false;
                ArmorpartEquip[14] = false;

                //lunch texture feedback armor function 
                FBTexArmor();

                // IF ITEM SELECTED IS DIFFERENT FROM 0 LUNCH EQUIP FUNCTION		OTHERWISE//set bool  of equiped item to false, remove item from model equiped armor array, lunch feedback texture armor function,remove armor part from the model
                if (headN >= 0) { HeadEquip(); ArmorpartEquip[0] = true; } else { ArmorpartEquip[0] = false; equipedArmor[0] = null; FBTexArmor(); headArmorS.transform.position = anchorHead.position; headArmorS.transform.parent = anchorHead; }
                if (hairModelN >= 0) { hairModelEquip(); ArmorpartEquip[1] = true; } else { ArmorpartEquip[1] = false; equipedArmor[1] = null; FBTexArmor(); hairModelS.transform.position = anchorHair.position; hairModelS.transform.parent = anchorHead; }
                if (jawN >= 0) { JawEquip(); ArmorpartEquip[2] = true; } else { ArmorpartEquip[2] = false; equipedArmor[2] = null; FBTexArmor(); jawS.transform.position = anchorJaw.position; jawS.transform.parent = anchorJaw; }
                if (torsoN >= 0) { TorsoEquip(); ArmorpartEquip[3] = true; } else { ArmorpartEquip[3] = false; equipedArmor[3] = null; FBTexArmor(); torsoArmorS.transform.position = anchorTorso.position; torsoArmorS.transform.parent = anchorTorso; }
                if (torsoAddN >= 0) { TorsoAddEquip(); ArmorpartEquip[4] = true; } else { ArmorpartEquip[4] = false; equipedArmor[4] = null; FBTexArmor(); torsoAddArmorS.transform.position = anchorTorso.position; torsoAddArmorS.transform.parent = anchorTorso; }
                if (beltN >= 0) { BeltEquip(); ArmorpartEquip[5] = true; } else { ArmorpartEquip[5] = false; equipedArmor[5] = null; FBTexArmor(); beltArmorS.transform.position = anchorBelt.position; beltArmorS.transform.parent = anchorBelt; }
                if (beltAddN >= 0) { BeltAddEquip(); ArmorpartEquip[6] = true; } else { ArmorpartEquip[6] = false; equipedArmor[6] = null; FBTexArmor(); beltAddArmorS.transform.position = anchorBelt.position; beltAddArmorS.transform.parent = anchorBelt; }
                if (armLN >= 0) { ArmLEquip(); ArmorpartEquip[10] = true; } else { ArmorpartEquip[10] = false; equipedArmor[10] = null; FBTexArmor(); armLArmorS.transform.position = anchorArmL.position; armLArmorS.transform.parent = anchorArmL; }
                if (armRN >= 0) { ArmREquip(); ArmorpartEquip[9] = true; } else { ArmorpartEquip[9] = false; equipedArmor[9] = null; FBTexArmor(); armRArmorS.transform.position = anchorArmR.position; armRArmorS.transform.parent = anchorArmR; }
                if (legRN >= 0) { LegREquip(); ArmorpartEquip[11] = true; } else { ArmorpartEquip[11] = false; equipedArmor[11] = null; FBTexArmor(); legRArmorS.transform.position = anchorLegR.position; legRArmorS.transform.parent = anchorLegR; }
                if (legLN >= 0) { LegLEquip(); ArmorpartEquip[12] = true; } else { ArmorpartEquip[12] = false; equipedArmor[12] = null; FBTexArmor(); legLArmorS.transform.position = anchorLegL.position; legLArmorS.transform.parent = anchorLegL; }
                if (shoulderRN >= 0) { ShoulderREquip(); ArmorpartEquip[7] = true; } else { ArmorpartEquip[7] = false; equipedArmor[7] = null; FBTexArmor(); shoulderRArmorS.transform.position = anchorShoulderR.position; shoulderRArmorS.transform.parent = anchorShoulderR; }
                if (shoulderLN >= 0) { ShoulderLEquip(); ArmorpartEquip[8] = true; } else { ArmorpartEquip[8] = false; equipedArmor[8] = null; FBTexArmor(); shoulderLArmorS.transform.position = anchorShoulderL.position; shoulderLArmorS.transform.parent = anchorShoulderL; }
                if (weaponLN >= 0) { WeaponLEquip(); ArmorpartEquip[14] = true; } else { ArmorpartEquip[14] = false; equipedArmor[14] = null; FBTexArmor(); weaponLArmorS.transform.position = anchorWeaponL.position; weaponLArmorS.transform.parent = anchorWeaponL; }
                if (weaponRN >= 0) { WeaponREquip(); ArmorpartEquip[13] = true; } else { ArmorpartEquip[13] = false; equipedArmor[13] = null; FBTexArmor(); weaponRArmorS.transform.position = anchorWeaponR.position; weaponRArmorS.transform.parent = anchorWeaponR; }

                //if(FXN>=0){FXEquip();} else {FXArmorS.transform.position = anchorFX.position;FXArmorS.transform.parent = anchorFX;} if you want activate the fx in the randomness
                if (eyeN >= 0) { EyeEquip(); } else { eyeS.transform.position = anchorEye.position; eyeS.transform.parent = anchorEye; }

                // lunch feedback texture armor
                FBTexArmor();
            }





            if (randomButtonTex1.Raycast(ray, out hit, 300.0f))
            {
                // random texture skin

                ScarsN = Random.Range(0, ScarsQ);
                EyeBrowN = Random.Range(0, EyeBrowQ);
                skinFaceN = Random.Range(0, skinFaceQ);
                colorNumber = Random.Range(0, 5);
                colorPilosityNumber = Random.Range(0, 3);
                BeardN = Random.Range(0, BeardQ);
                HairSkullN = Random.Range(0, HairSkullQ);
                //headAddN =Random.Range(0,headAddQ);
                EyeN = Random.Range(0, EyeQ);
                PantN = Random.Range(0, PantQ);
                TorsoN = Random.Range(0, TorsoQ);
                ShoeN = Random.Range(0, ShoeQ);
                GloveN = Random.Range(0, GloveQ);
                BeltN = Random.Range(0, BeltQ);

                robeLongN = Random.Range(-5, robeLongQ);
                if (robeLongN >= 1) { robeLongB = true; RobeLongOn(); }
                if (robeLongN <= 0) { robeLongN = 0; robeLongB = false; RobeLongOff(); }
                robeShortN = Random.Range(-5, robeShortQ);
                if (robeShortN >= 1) { robeShortB = true; RobeShortOn(); }
                if (robeShortN <= 0) { robeShortN = 0; robeShortB = false; RobeShortOff(); }

                PilosityColor();

            }

            //RANDOM BUTTON //Randomly add stuff to the character
            if (randomButtonTex2.Raycast(ray, out hit, 300.0f))
            {



                //remove all armor part

                headArmorS.transform.position = anchorHead.position; headArmorS.transform.parent = anchorHead;
                hairModelS.transform.position = anchorHead.position; hairModelS.transform.parent = anchorHead;
                jawS.transform.position = anchorJaw.position; jawS.transform.parent = anchorJaw;
                eyeS.transform.position = anchorEye.position; eyeS.transform.parent = anchorEye;
                torsoArmorS.transform.position = anchorTorso.position; torsoArmorS.transform.parent = anchorTorso;
                torsoAddArmorS.transform.position = anchorTorso.position; torsoAddArmorS.transform.parent = anchorTorso;
                beltArmorS.transform.position = anchorBelt.position; beltArmorS.transform.parent = anchorBelt;
                beltAddArmorS.transform.position = anchorBelt.position; beltAddArmorS.transform.parent = anchorBelt;
                shoulderRArmorS.transform.position = anchorShoulderR.position; shoulderRArmorS.transform.parent = anchorShoulderR;
                shoulderLArmorS.transform.position = anchorShoulderL.position; shoulderLArmorS.transform.parent = anchorShoulderL;
                armLArmorS.transform.position = anchorArmL.position; armLArmorS.transform.parent = anchorArmL;
                armRArmorS.transform.position = anchorArmR.position; armRArmorS.transform.parent = anchorArmR;
                legRArmorS.transform.position = anchorLegR.position; legRArmorS.transform.parent = anchorLegR;
                legLArmorS.transform.position = anchorLegL.position; legLArmorS.transform.parent = anchorLegL;
                weaponRArmorS.transform.position = anchorWeaponR.position; weaponRArmorS.transform.parent = anchorWeaponR;
                weaponLArmorS.transform.position = anchorWeaponL.position; weaponLArmorS.transform.parent = anchorWeaponL;
                FXArmorS.transform.position = anchorFX.position; FXArmorS.transform.parent = anchorFX;

                // - 5 because that make more chance no item is added to the model (you can modify this number to modify the randomness)

                //Random mesh armor

                hairModelN = Random.Range(-5, hairModelQ);

                if (hairModelN > -1) { headN = -1; }
                else
                {
                    headN = Random.Range(-5, headQ);
                }


                jawN = Random.Range(-1, jawQ);
                eyeN = Random.Range(-20, eyeQ);
                torsoN = Random.Range(-5, torsoQ);
                torsoAddN = Random.Range(-5, torsoAddQ);
                beltN = Random.Range(-5, beltQ);
                beltAddN = Random.Range(-5, beltAddQ);
                shoulderRN = Random.Range(-5, shoulderRQ);
                shoulderLN = shoulderRN;
                armRN = Random.Range(-5, armRQ);
                armLN = armRN;
                legRN = Random.Range(-5, legRQ);
                legLN = legRN;
                weaponRN = Random.Range(-5, weaponRQ);
                weaponLN = Random.Range(-5, weaponLQ);
                //FXN = Random.Range(-5,FXQ);


                ArmorpartEquip[0] = false;
                ArmorpartEquip[1] = false;
                ArmorpartEquip[2] = false;
                ArmorpartEquip[3] = false;
                ArmorpartEquip[4] = false;
                ArmorpartEquip[5] = false;
                ArmorpartEquip[6] = false;
                ArmorpartEquip[7] = false;
                ArmorpartEquip[8] = false;
                ArmorpartEquip[9] = false;
                ArmorpartEquip[10] = false;
                ArmorpartEquip[11] = false;
                ArmorpartEquip[12] = false;
                ArmorpartEquip[13] = false;
                ArmorpartEquip[14] = false;


                FBTexArmor();

                if (headN >= 0) { HeadEquip(); ArmorpartEquip[0] = true; } else { ArmorpartEquip[0] = false; equipedArmor[0] = null; FBTexArmor(); headArmorS.transform.position = anchorHead.position; headArmorS.transform.parent = anchorHead; }
                if (hairModelN >= 0) { hairModelEquip(); ArmorpartEquip[1] = true; } else { ArmorpartEquip[1] = false; equipedArmor[1] = null; FBTexArmor(); hairModelS.transform.position = anchorHead.position; hairModelS.transform.parent = anchorHead; }
                if (jawN >= 0) { JawEquip(); ArmorpartEquip[2] = true; } else { ArmorpartEquip[2] = false; equipedArmor[2] = null; FBTexArmor(); jawS.transform.position = anchorJaw.position; jawS.transform.parent = anchorJaw; }
                if (torsoN >= 0) { TorsoEquip(); ArmorpartEquip[3] = true; } else { ArmorpartEquip[3] = false; equipedArmor[3] = null; FBTexArmor(); torsoArmorS.transform.position = anchorTorso.position; torsoArmorS.transform.parent = anchorTorso; }
                if (torsoAddN >= 0) { TorsoAddEquip(); ArmorpartEquip[4] = true; } else { ArmorpartEquip[4] = false; equipedArmor[4] = null; FBTexArmor(); torsoAddArmorS.transform.position = anchorTorso.position; torsoAddArmorS.transform.parent = anchorTorso; }
                if (beltN >= 0) { BeltEquip(); ArmorpartEquip[5] = true; } else { ArmorpartEquip[5] = false; equipedArmor[5] = null; FBTexArmor(); beltArmorS.transform.position = anchorBelt.position; beltArmorS.transform.parent = anchorBelt; }
                if (beltAddN >= 0) { BeltAddEquip(); ArmorpartEquip[6] = true; } else { ArmorpartEquip[6] = false; equipedArmor[6] = null; FBTexArmor(); beltAddArmorS.transform.position = anchorBelt.position; beltAddArmorS.transform.parent = anchorBelt; }
                if (armLN >= 0) { ArmLEquip(); ArmorpartEquip[10] = true; } else { ArmorpartEquip[10] = false; equipedArmor[10] = null; FBTexArmor(); armLArmorS.transform.position = anchorArmL.position; armLArmorS.transform.parent = anchorArmL; }
                if (armRN >= 0) { ArmREquip(); ArmorpartEquip[9] = true; } else { ArmorpartEquip[9] = false; equipedArmor[9] = null; FBTexArmor(); armRArmorS.transform.position = anchorArmR.position; armRArmorS.transform.parent = anchorArmR; }
                if (legRN >= 0) { LegREquip(); ArmorpartEquip[11] = true; } else { ArmorpartEquip[11] = false; equipedArmor[11] = null; FBTexArmor(); legRArmorS.transform.position = anchorLegR.position; legRArmorS.transform.parent = anchorLegR; }
                if (legLN >= 0) { LegLEquip(); ArmorpartEquip[12] = true; } else { ArmorpartEquip[12] = false; equipedArmor[12] = null; FBTexArmor(); legLArmorS.transform.position = anchorLegL.position; legLArmorS.transform.parent = anchorLegL; }
                if (shoulderRN >= 0) { ShoulderREquip(); ArmorpartEquip[7] = true; } else { ArmorpartEquip[7] = false; equipedArmor[7] = null; FBTexArmor(); shoulderRArmorS.transform.position = anchorShoulderR.position; shoulderRArmorS.transform.parent = anchorShoulderR; }
                if (shoulderLN >= 0) { ShoulderLEquip(); ArmorpartEquip[8] = true; } else { ArmorpartEquip[8] = false; equipedArmor[8] = null; FBTexArmor(); shoulderLArmorS.transform.position = anchorShoulderL.position; shoulderLArmorS.transform.parent = anchorShoulderL; }
                if (weaponLN >= 0) { WeaponLEquip(); ArmorpartEquip[14] = true; } else { ArmorpartEquip[14] = false; equipedArmor[14] = null; FBTexArmor(); weaponLArmorS.transform.position = anchorWeaponL.position; weaponLArmorS.transform.parent = anchorWeaponL; }
                if (weaponRN >= 0) { WeaponREquip(); ArmorpartEquip[13] = true; } else { ArmorpartEquip[13] = false; equipedArmor[13] = null; FBTexArmor(); weaponRArmorS.transform.position = anchorWeaponR.position; weaponRArmorS.transform.parent = anchorWeaponR; }

                //if(FXN>=0){FXEquip();} else {FXArmorS.transform.position = anchorFX.position;FXArmorS.transform.parent = anchorFX;}
                if (eyeN >= 0) { EyeEquip(); } else { eyeS.transform.position = anchorHead.position; eyeS.transform.parent = anchorHead; }

                FBTexArmor();
            }


            //	create prefab
            //if (savePrefabButton.Raycast (ray, out hit, 300.0f)){MakePrefab();}

        }
        */
    }
    public void randomAll()
    {
        headArmorS.transform.position = anchorHead.position; headArmorS.transform.parent = anchorHead;
        hairModelS.transform.position = anchorHair.position; hairModelS.transform.parent = anchorHair;
        jawS.transform.position = anchorJaw.position; jawS.transform.parent = anchorJaw;
        eyeS.transform.position = anchorEye.position; eyeS.transform.parent = anchorEye;
        torsoArmorS.transform.position = anchorTorso.position; torsoArmorS.transform.parent = anchorTorso;
        torsoAddArmorS.transform.position = anchorTorso.position; torsoAddArmorS.transform.parent = anchorTorso;
        beltArmorS.transform.position = anchorBelt.position; beltArmorS.transform.parent = anchorBelt;
        beltAddArmorS.transform.position = anchorBelt.position; beltAddArmorS.transform.parent = anchorBelt;
        shoulderRArmorS.transform.position = anchorShoulderR.position; shoulderRArmorS.transform.parent = anchorShoulderR;
        shoulderLArmorS.transform.position = anchorShoulderL.position; shoulderLArmorS.transform.parent = anchorShoulderL;
        armLArmorS.transform.position = anchorArmL.position; armLArmorS.transform.parent = anchorArmL;
        armRArmorS.transform.position = anchorArmR.position; armRArmorS.transform.parent = anchorArmR;
        legRArmorS.transform.position = anchorLegR.position; legRArmorS.transform.parent = anchorLegR;
        legLArmorS.transform.position = anchorLegL.position; legLArmorS.transform.parent = anchorLegL;
        weaponRArmorS.transform.position = anchorWeaponR.position; weaponRArmorS.transform.parent = anchorWeaponR;
        weaponLArmorS.transform.position = anchorWeaponL.position; weaponLArmorS.transform.parent = anchorWeaponL;
        FXArmorS.transform.position = anchorFX.position; FXArmorS.transform.parent = anchorFX;
        
        // Random texture Skin
        // set the random range on each category of texture
        // - 5 because that make more chance no item is added to the model (you can modify this number to modify the randomness)

        ScarsN = Random.Range(0, ScarsQ);
        EyeBrowN = Random.Range(0, EyeBrowQ);
        skinFaceN = Random.Range(0, skinFaceQ);
        colorNumber = Random.Range(0, 5);
        colorPilosityNumber = Random.Range(0, 4);
        BeardN = Random.Range(0, BeardQ);
        HairSkullN = Random.Range(0, HairSkullQ);
        headAddN = Random.Range(0, headAddQ);
        EyeN = Random.Range(0, EyeQ);
        PantN = Random.Range(0, PantQ);
        TorsoN = Random.Range(0, TorsoQ);
        ShoeN = Random.Range(0, ShoeQ);
        GloveN = Random.Range(0, GloveQ);
        BeltN = Random.Range(0, BeltQ);
        robeLongN = Random.Range(-5, robeLongQ);
        if (robeLongN >= 1) { robeLongB = true; RobeLongOn(); }
        if (robeLongN <= 0) { robeLongN = 0; robeLongB = false; RobeLongOff(); }
        robeShortN = Random.Range(-5, robeShortQ);
        if (robeShortN >= 1) { robeShortB = true; RobeShortOn(); }
        if (robeShortN <= 0) { robeShortN = 0; robeShortB = false; RobeShortOff(); }

      //  Debug.Log(ScarsN);
        //Random armor mesh
        // set the number of the selected item to be placed on the model

        hairModelN = Random.Range(-5, hairModelQ);
        headN = Random.Range(-5, headQ);
        jawN = Random.Range(-1, jawQ);
        eyeN = Random.Range(-20, eyeQ);
        torsoN = Random.Range(-5, torsoQ);
        torsoAddN = Random.Range(-5, torsoAddQ);
        beltN = Random.Range(-5, beltQ);
        beltAddN = Random.Range(-5, beltAddQ);
        shoulderRN = Random.Range(-5, shoulderRQ);
        shoulderLN = shoulderRN;
        armRN = Random.Range(-5, armRQ);
        armLN = armRN;
        legRN = Random.Range(-5, legRQ);
        legLN = legRN;
        weaponRN = Random.Range(-5, weaponRQ);
        weaponLN = Random.Range(-5, weaponLQ);
        FXN = Random.Range(-5,FXQ); // enable it if you want FxTorso be part of the random


        //lunch pilosity function to remap the color on the mesh hair and the texture color
        PilosityColor();

        // set all the bool  to false (no item is equiped)
        ArmorpartEquip[0] = false;
        ArmorpartEquip[1] = false;
        ArmorpartEquip[2] = false;
        ArmorpartEquip[3] = false;
        ArmorpartEquip[4] = false;
        ArmorpartEquip[5] = false;
        ArmorpartEquip[6] = false;
        ArmorpartEquip[7] = false;
        ArmorpartEquip[8] = false;
        ArmorpartEquip[9] = false;
        ArmorpartEquip[10] = false;
        ArmorpartEquip[11] = false;
        ArmorpartEquip[12] = false;
        ArmorpartEquip[13] = false;
        ArmorpartEquip[14] = false;

        //lunch texture feedback armor function 
        FBTexArmor();

        // IF ITEM SELECTED IS DIFFERENT FROM 0 LUNCH EQUIP FUNCTION		OTHERWISE//set bool  of equiped item to false, remove item from model equiped armor array, lunch feedback texture armor function,remove armor part from the model
        if (headN >= 0) { HeadEquip(); ArmorpartEquip[0] = true; } else { ArmorpartEquip[0] = false; equipedArmor[0] = null; FBTexArmor(); headArmorS.transform.position = anchorHead.position; headArmorS.transform.parent = anchorHead; }
        if (hairModelN >= 0) { hairModelEquip(); ArmorpartEquip[1] = true; } else { ArmorpartEquip[1] = false; equipedArmor[1] = null; FBTexArmor(); hairModelS.transform.position = anchorHair.position; hairModelS.transform.parent = anchorHead; }
        if (jawN >= 0) { JawEquip(); ArmorpartEquip[2] = true; } else { ArmorpartEquip[2] = false; equipedArmor[2] = null; FBTexArmor(); jawS.transform.position = anchorJaw.position; jawS.transform.parent = anchorJaw; }
        if (torsoN >= 0) { TorsoEquip(); ArmorpartEquip[3] = true; } else { ArmorpartEquip[3] = false; equipedArmor[3] = null; FBTexArmor(); torsoArmorS.transform.position = anchorTorso.position; torsoArmorS.transform.parent = anchorTorso; }
        if (torsoAddN >= 0) { TorsoAddEquip(); ArmorpartEquip[4] = true; } else { ArmorpartEquip[4] = false; equipedArmor[4] = null; FBTexArmor(); torsoAddArmorS.transform.position = anchorTorso.position; torsoAddArmorS.transform.parent = anchorTorso; }
        if (beltN >= 0) { BeltEquip(); ArmorpartEquip[5] = true; } else { ArmorpartEquip[5] = false; equipedArmor[5] = null; FBTexArmor(); beltArmorS.transform.position = anchorBelt.position; beltArmorS.transform.parent = anchorBelt; }
        if (beltAddN >= 0) { BeltAddEquip(); ArmorpartEquip[6] = true; } else { ArmorpartEquip[6] = false; equipedArmor[6] = null; FBTexArmor(); beltAddArmorS.transform.position = anchorBelt.position; beltAddArmorS.transform.parent = anchorBelt; }
        if (armLN >= 0) { ArmLEquip(); ArmorpartEquip[10] = true; } else { ArmorpartEquip[10] = false; equipedArmor[10] = null; FBTexArmor(); armLArmorS.transform.position = anchorArmL.position; armLArmorS.transform.parent = anchorArmL; }
        if (armRN >= 0) { ArmREquip(); ArmorpartEquip[9] = true; } else { ArmorpartEquip[9] = false; equipedArmor[9] = null; FBTexArmor(); armRArmorS.transform.position = anchorArmR.position; armRArmorS.transform.parent = anchorArmR; }
        if (legRN >= 0) { LegREquip(); ArmorpartEquip[11] = true; } else { ArmorpartEquip[11] = false; equipedArmor[11] = null; FBTexArmor(); legRArmorS.transform.position = anchorLegR.position; legRArmorS.transform.parent = anchorLegR; }
        if (legLN >= 0) { LegLEquip(); ArmorpartEquip[12] = true; } else { ArmorpartEquip[12] = false; equipedArmor[12] = null; FBTexArmor(); legLArmorS.transform.position = anchorLegL.position; legLArmorS.transform.parent = anchorLegL; }
        if (shoulderRN >= 0) { ShoulderREquip(); ArmorpartEquip[7] = true; } else { ArmorpartEquip[7] = false; equipedArmor[7] = null; FBTexArmor(); shoulderRArmorS.transform.position = anchorShoulderR.position; shoulderRArmorS.transform.parent = anchorShoulderR; }
        if (shoulderLN >= 0) { ShoulderLEquip(); ArmorpartEquip[8] = true; } else { ArmorpartEquip[8] = false; equipedArmor[8] = null; FBTexArmor(); shoulderLArmorS.transform.position = anchorShoulderL.position; shoulderLArmorS.transform.parent = anchorShoulderL; }
        if (weaponLN >= 0) { WeaponLEquip(); ArmorpartEquip[14] = true; } else { ArmorpartEquip[14] = false; equipedArmor[14] = null; FBTexArmor(); weaponLArmorS.transform.position = anchorWeaponL.position; weaponLArmorS.transform.parent = anchorWeaponL; }
        if (weaponRN >= 0) { WeaponREquip(); ArmorpartEquip[13] = true; } else { ArmorpartEquip[13] = false; equipedArmor[13] = null; FBTexArmor(); weaponRArmorS.transform.position = anchorWeaponR.position; weaponRArmorS.transform.parent = anchorWeaponR; }

        if(FXN>=0){FXEquip();} else {FXArmorS.transform.position = anchorFX.position;FXArmorS.transform.parent = anchorFX;} //if you want activate the fx in the randomness
        if (eyeN >= 0) { EyeEquip(); } else { eyeS.transform.position = anchorEye.position; eyeS.transform.parent = anchorEye; }

        // lunch feedback texture armor
        FBTexArmor();
        
    }
    ////////////////////////////////////////////////////////////////////  _____________  __________  ______  ______
    //////////////////////////////////////////////////////////////////// /_  __/ ____/ |/ /_  __/ / / / __ \/ ____/////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////  / / / __/  |   / / / / / / / /_/ / __/   ////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////// / / / /___ /   | / / / /_/ / _, _/ /___   ////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////_/ /_____//_/|_|/_/  \____/_/ |_/_____/   ////////////////////////////////////////////////////////////////////

    // this function reload color texture in folder for matching color hair 
    
    IEnumerator PilosityColor()
    {
        
        if (colorPilosityNumber <= -1) { colorPilosityNumber = 3; } //check color number
        if (colorPilosityNumber >= 4) { colorPilosityNumber = 0; }  //fix color number if max
        if (colorPilosityNumber >= 0 && colorPilosityNumber <= 3)
        { //if color number match 

            // EyeBrow Texture in folder 	
            EyeBrow = new Texture2D[EyeBrowSearch.Length];                                                                                              //resize array
            for (int cP = 0; cP < EyeBrowSearch.Length; ++cP)
            {                                                                                              //fill with Texture2D
                EyeBrow[cP] = Resources.Load("Character_Editor/Textures/Character/HumanMale/HumanMale_Eyebrow/Color" + colorPilosityNumber + "/EyeBrow" + cP + "_Color" + colorPilosityNumber + "") as Texture2D;
            }
            EyeBrowQ = EyeBrow.Length;
            // Beard Texture in folder  
            Beard = new Texture2D[BeardSearch.Length];                                                                                              //resize array
            for (int eP = 0; eP < BeardSearch.Length; ++eP)
            {                                                                                              //fill with Texture2D
                Beard[eP] = Resources.Load("Character_Editor/Textures/Character/HumanMale/HumanMale_Beard/Color" + colorPilosityNumber + "/Beard" + eP + "_Color" + colorPilosityNumber + "") as Texture2D;
            }
            BeardQ = Beard.Length;
            // HairSkull Texture in folder  
            HairSkull = new Texture2D[HairSkullSearch.Length];                                                                                              //resize array
            for (int gP = 0; gP < HairSkullSearch.Length; ++gP)
            {                                                                                              //fill with Texture2D
                HairSkull[gP] = Resources.Load("Character_Editor/Textures/Character/HumanMale/HumanMale_HairSkull/Color" + colorPilosityNumber + "/HumanMale_HairSkull" + gP + "_Color" + colorPilosityNumber + "") as Texture2D;
            }
            HairSkullQ = HairSkull.Length;

            ColorSkinF();
            if (ArmorpartEquip[1] == true) { hairModelEquip(); }
            if (ArmorpartEquip[2] == true) { JawEquip(); }
        }
        yield return 0;

    }
    public void LoadPlayerCos(int NrScarsT, int NrEyeBrowT, int NrSkinFaceT, int NrColorNumberT, int NrColorPilosityT, int NrBeardT, int NrHairSkullT, int NrHeadAddT, int NrEyeT, int NrPantT, int NrTorsoT, int NrShoeT, int NrGloveT, int NrBeltT, int NrRobeLongT, int NrRobeShortT, int NrHairM, int NrHeadM, int NrJawM, int NrEyeM, int NrTorsoM, int NrTorsoAddM, int NrBeltM, int NrBeltAddM, int NrShoulderRM, int NrShoulderLM, int NrArmRM, int NrArmLM, int NrLegRM, int NrLegLM, int NrWeaponRM, int NrWeaponLM)
    {
        CharacterRace = "HumanMale";
        
        CombineAll = atlasBase;
        skinFaceS = atlasBase;
        ////LOADING CHARACTER TEXTURE////
        //At start this part of the script put textures of the character in aray liste of texture 2d  
        // the script search in project folder
        //       /!\ need to have a proper nomenclature folder and texture 


        // AtlasBase Texture SkinFace
        atlasBaseSearchSkinFace = Resources.LoadAll("Character_Editor/Textures/Character/HumanMale/HumanMale_Color/Color" + colorNumber);
        atlasBaseSkinFace = new Texture2D[atlasBaseSearchSkinFace.Length];
        for (int a = 0; a < atlasBaseSearchSkinFace.Length; ++a)
        {
            atlasBaseSkinFace[a] = Resources.Load("Character_Editor/Textures/Character/HumanMale/HumanMale_Color/Color0/HumanMale_Color0_FaceSkin" + a + "") as Texture2D;
            
        }
        skinFaceQ = atlasBaseSkinFace.Length;

        // HeadAdd Texture in folder 
        headAddSearch = Resources.LoadAll("Character_Editor/Textures/CharacterOutfit/Head_add");
        
        headAdd = new Texture2D[headAddSearch.Length];                                                                                              //resize array
        for (int b = 0; b < headAddSearch.Length; ++b)
        {                                                                                              //fill with Texture2D
            headAdd[b] = Resources.Load("Character_Editor/Textures/CharacterOutfit/Head_add/headAdd" + b + "") as Texture2D;
        }
        headAddQ = headAdd.Length;

        // EyeBrow Texture in folder
        EyeBrowSearch = Resources.LoadAll("Character_Editor/Textures/Character/HumanMale/HumanMale_Eyebrow/Color0");
        //AssetDatabase.FindAssets ("EyeBrow t:texture2D", ["Character_Editor/Textures/Character/HumanMale/HumanMale_Eyebrow/Color0"]);								 //search texture by name for array Length
        EyeBrow = new Texture2D[EyeBrowSearch.Length];                                                                                              //resize array
        for (int c = 0; c < EyeBrowSearch.Length; ++c)
        {                                                                                              //fill with Texture2D
            EyeBrow[c] = Resources.Load("Character_Editor/Textures/Character/HumanMale/HumanMale_Eyebrow/Color0/EyeBrow" + c + "_Color0") as Texture2D;
        }
        EyeBrowQ = EyeBrow.Length;
        //texture Quantity  
        // Scars Texture in folder  
        ScarsSearch = Resources.LoadAll("Character_Editor/Textures/Character/HumanMale/HumanMale_Scars");
        //AssetDatabase.FindAssets ("Scars t:texture2D", ["Character_Editor/Textures/Character/HumanMale/HumanMale_Scars"]);								 //search texture by name for array Length
        Scars = new Texture2D[ScarsSearch.Length];                                                                                              //resize array
        for (int d = 0; d < ScarsSearch.Length; ++d)
        {                                                                                              //fill with Texture2D
            Scars[d] = Resources.Load("Character_Editor/Textures/Character/HumanMale/HumanMale_Scars/Scars" + d + "") as Texture2D;
        }
        ScarsQ = Scars.Length;

        // Beard Texture in folder  
        BeardSearch = Resources.LoadAll("Character_Editor/Textures/Character/HumanMale/HumanMale_Beard/Color0");
        //AssetDatabase.FindAssets ("Beard t:texture2D", ["Character_Editor/Textures/Character/HumanMale/HumanMale_Beard/Color0"]);								 //search texture by name for array Length
        Beard = new Texture2D[BeardSearch.Length];                                                                                              //resize array
        for (int e = 0; e < BeardSearch.Length; ++e)
        {                                                                                              //fill with Texture2D
            Beard[e] = Resources.Load("Character_Editor/Textures/Character/HumanMale/HumanMale_Beard/Color0/Beard" + e + "_Color0") as Texture2D;
        }
        BeardQ = Beard.Length;

        // HairSkull Texture in folder  
        HairSkullSearch = Resources.LoadAll("Character_Editor/Textures/Character/HumanMale/HumanMale_HairSkull/Color0");                  //search texture by name for array Length
        HairSkull = new Texture2D[HairSkullSearch.Length];                                                                                              //resize array
        for (int g = 0; g < HairSkullSearch.Length; ++g)
        {                                                                                              //fill with Texture2D
            HairSkull[g] = Resources.Load("Character_Editor/Textures/Character/HumanMale/HumanMale_HairSkull/Color0/HumanMale_HairSkull" + g + "_Color0") as Texture2D;
        }
        HairSkullQ = HairSkull.Length;

        // Eye Texture in folder 
        EyeSearch = Resources.LoadAll("Character_Editor/Textures/Character/HumanMale/HumanMale_Eye");                                 //search texture by name for array Length
        Eye = new Texture2D[EyeSearch.Length];                                                                                              //resize array
        for (int f = 0; f < EyeSearch.Length; ++f)
        {                                                                                              //fill with Texture2D
            Eye[f] = Resources.Load("Character_Editor/Textures/Character/HumanMale/HumanMale_Eye/Eye" + f + "") as Texture2D;
        }
        EyeQ = Eye.Length;

        // Pant Texture in folder 
        PantSearch = Resources.LoadAll("Character_Editor/Textures/CharacterOutfit/Pant");                         //search texture by name for array Length
        Pant = new Texture2D[PantSearch.Length];                                                                                            //resize array
        for (int i = 0; i < PantSearch.Length; ++i)
        {                                                                                              //fill with Texture2D
            Pant[i] = Resources.Load("Character_Editor/Textures/CharacterOutfit/Pant/Pant" + i + "") as Texture2D;
        }
        PantQ = Pant.Length;

        // Torso Texture in folder 
        TorsoSearch = Resources.LoadAll("Character_Editor/Textures/CharacterOutfit/Torso");                           //search texture by name for array Length
        Torso = new Texture2D[TorsoSearch.Length];                                                                                              //resize array
        for (int j = 0; j < TorsoSearch.Length; ++j)
        {                                                                                              //fill with Texture2D
            Torso[j] = Resources.Load("Character_Editor/Textures/CharacterOutfit/Torso/Torso" + j + "") as Texture2D;
        }
        TorsoQ = Torso.Length;

        // Shoe Texture in folder 
        ShoeSearch = Resources.LoadAll("Character_Editor/Textures/CharacterOutfit/Shoe");                     //search texture by name for array Length
        Shoe = new Texture2D[ShoeSearch.Length];                                                                                            //resize array
        for (int k = 0; k < ShoeSearch.Length; ++k)
        {                                                                                              //fill with Texture2D
            Shoe[k] = Resources.Load("Character_Editor/Textures/CharacterOutfit/Shoe/Shoe" + k + "") as Texture2D;
        }
        ShoeQ = Shoe.Length;                                                                                                                                     //texture Quantity 

        // Glove Texture in folder 
        GloveSearch = Resources.LoadAll("Character_Editor/Textures/CharacterOutfit/Glove");                       //search texture by name for array Length
        Glove = new Texture2D[GloveSearch.Length];                                                                                              //resize array
        for (int l = 0; l < GloveSearch.Length; ++l)
        {                                                                                              //fill with Texture2D
            Glove[l] = Resources.Load("Character_Editor/Textures/CharacterOutfit/Glove/Glove" + l + "") as Texture2D;
        }
        GloveQ = Glove.Length;

        // Belt Texture in folder 
        BeltSearch = Resources.LoadAll("Character_Editor/Textures/CharacterOutfit/Belt");                             //search texture by name for array Length
        Belt = new Texture2D[BeltSearch.Length];                                                                                            //resize array
        for (int m = 0; m < BeltSearch.Length; ++m)
        {                                                                                              //fill with Texture2D
            Belt[m] = Resources.Load("Character_Editor/Textures/CharacterOutfit/Belt/Belt" + m + "") as Texture2D;
        }
        BeltQ = Belt.Length;
        // Cloak Texture in folder 

        cloakSearch = Resources.LoadAll("Character_Editor/Textures/Armor/Cloak");                         //search texture by name for array Length
        cloakTex = new Texture2D[cloakSearch.Length];                                                                                           //resize array
        for (int cl = 0; cl < cloakSearch.Length; ++cl)
        {                                                                                              //fill with Texture2D
            cloakTex[cl] = Resources.Load("Character_Editor/Textures/Armor/Cloak/A_Cloak_" + cl + "") as Texture2D;
        }
        cloakQ = cloakTex.Length;
        for (int clo2 = 0; clo2 < cloak.Length; clo2++)
        {
            cloak[clo2].SetActive(false);
        }
        // robeLong Texture in folder 
        robeLongSearch = Resources.LoadAll("Character_Editor/Textures/CharacterOutfit/RobeLong");                             //search texture by name for array Length
        robeLongTex = new Texture2D[robeLongSearch.Length];                                                                                             //resize array
        for (int rl = 0; rl < robeLongSearch.Length; ++rl)
        {                                                                                              //fill with Texture2D
            robeLongTex[rl] = Resources.Load("Character_Editor/Textures/CharacterOutfit/RobeLong/RobeLong" + rl + "") as Texture2D;
        }
        robeLongQ = robeLongTex.Length;

        // robeShort Texture in folder 
        robeShortSearch = Resources.LoadAll("Character_Editor/Textures/CharacterOutfit/RobeShort");                           //search texture by name for array Length
        robeShortTex = new Texture2D[robeShortSearch.Length];                                                                                           //resize array
        for (int rsh = 0; rsh < robeShortSearch.Length; ++rsh)
        {                                                                                              //fill with Texture2D
            robeShortTex[rsh] = Resources.Load("Character_Editor/Textures/CharacterOutfit/RobeShort/RobeShort" + rsh + "") as Texture2D;
        }
        robeShortQ = robeShortTex.Length;


        // lunch the texturing loop in the start function 
        //the character model receive the default texture combined 
        // default are the 0 texture in here folder(most of them are empty transparent png, only the faceskin colorskin and the pant have pixels)                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       //texture Quantity 
       /// ColorSkinF();
       // SkinFaceCombineF();

        //    _   ___ __  __  ___  ___ 
        //   /_\ | _ \  \/  |/ _ \| _ \
        //  / _ \|   / |\/| | (_) |   /
        // /_/ \_\_|_\_|  |_|\___/|_|_\


        //get biped part 
        //!\\ YOU SHOULD HAVE ONLY 1 BIPED WITH THE SAME NOMENCLATURE IN YOUR SCENE TO WORK PROPRELY

        headAnchor = findInChildrensByName("Bip01_Head");
        jawAnchor = findInChildrensByName("Bip01_Jaw");
        torsoAnchor = findInChildrensByName("Bip01_Spine3");
        beltAnchor = findInChildrensByName("Bip01_Pelvis");
        shoulderRAnchor = findInChildrensByName("Bip01_R_UpperArm");
        shoulderLAnchor = findInChildrensByName("Bip01_L_UpperArm");
        armRAnchor = findInChildrensByName("Bip01_R_Forearm");
        armLAnchor = findInChildrensByName("Bip01_L_Forearm");
        legRAnchor = findInChildrensByName("Bip01_R_Calf");
        legLAnchor = findInChildrensByName("Bip01_L_Calf");
        weaponRAnchor = findInChildrensByName("Bip01_R_Weapon");
        weaponLAnchor = findInChildrensByName("Bip01_L_Weapon");
        FXAnchor = findInChildrensByName("Bip01_Spine3");


        // Set the number of the selected item for each categorie
        headN = 0;
        hairModelN = 0;
        jawN = 0;
        eyeN = 0;
        torsoN = 0;
        torsoAddN = 0;
        beltN = 0;
        beltAddN = 0;
        shoulderRN = 0;
        shoulderLN = 0;
        armRN = 0;
        armLN = 0;
        legRN = 0;
        legLN = 0;
        FXN = 0;
        weaponRN = 0;
        weaponLN = 0;

        // Find All Armor Part GameObject

        AllArmor = FindObjectsOfType(typeof(GameObject)) as GameObject[];


        // Find Helm and store
        for (int obj = 0; obj < AllArmor.Length; obj++) { if (AllArmor[obj].name.Contains("A_Helm_" + CharacterRace)) { headQ++; } }
        headArmor = new GameObject[headQ];
        for (int p = 0; p < headQ; ++p)
        {
            headArmor[p] = GameObject.Find("A_Helm_" + CharacterRace + "_" + p + "");
        }

        // Find HairModel and store
        for (int hm = 0; hm < AllArmor.Length; hm++) { if (AllArmor[hm].name.Contains("A_HairModel_" + CharacterRace)) { hairModelQ++; } }
        hairModel = new GameObject[hairModelQ];
        for (int hmo = 0; hmo < hairModelQ; ++hmo)
        {
            hairModel[hmo] = GameObject.Find("A_HairModel_" + CharacterRace + "_" + hmo + "");
        }

        // Find JawModel and store
        for (int jw = 0; jw < AllArmor.Length; jw++) { if (AllArmor[jw].name.Contains("A_Jaw_" + CharacterRace)) { jawQ++; } }
        jaw = new GameObject[jawQ];
        for (int jwx = 0; jwx < jawQ; ++jwx)
        {
            jaw[jwx] = GameObject.Find("A_Jaw_" + CharacterRace + "_" + jwx + "");
        }

        // Find TorsoArmor and store
        for (int to = 0; to < AllArmor.Length; to++) { if (AllArmor[to].name.Contains("A_TorsoArmor_" + CharacterRace)) { torsoQ++; } }
        torsoArmor = new GameObject[torsoQ];
        for (int q = 0; q < torsoQ; ++q)
        {
            torsoArmor[q] = GameObject.Find("A_TorsoArmor_" + CharacterRace + "_" + q + "");
        }

        for (int be = 0; be < AllArmor.Length; be++) { if (AllArmor[be].name.Contains("A_Belt_" + CharacterRace)) { beltQ++; } }
        beltArmor = new GameObject[beltQ];
        for (int r = 0; r < beltQ; ++r)
        {
            beltArmor[r] = GameObject.Find("A_Belt_" + CharacterRace + "_" + r + "");
        }
        //			foreach( var Helm in AllArmor){
        //	Debug.Log("trouvées");
        for (int toa = 0; toa < AllArmor.Length; toa++) { if (AllArmor[toa].name.Contains("A_TorsoAdd_" + CharacterRace)) { torsoAddQ++; } }
        torsoAddArmor = new GameObject[torsoAddQ];
        for (int s = 0; s < torsoAddQ; ++s)
        {
            torsoAddArmor[s] = GameObject.Find("A_TorsoAdd_" + CharacterRace + "_" + s + "");
        }

        for (int eyx = 0; eyx < AllArmor.Length; eyx++) { if (AllArmor[eyx].name.Contains("A_EyeAdd_" + CharacterRace)) { eyeQ++; } }
        eyeAddArmor = new GameObject[eyeQ];
        for (int x = 0; x < eyeQ; ++x)
        {                                                                                              //fill with Texture2D
            eyeAddArmor[x] = GameObject.Find("A_EyeAdd_" + CharacterRace + "_" + x + "");
        }

        for (int shr = 0; shr < AllArmor.Length; shr++) { if (AllArmor[shr].name.Contains("A_Shoulder_R_" + CharacterRace)) { shoulderRQ++; } }
        shoulderRArmor = new GameObject[shoulderRQ];
        for (int o = 0; o < shoulderRQ; ++o)
        {                                                                                              //fill with Texture2D
            shoulderRArmor[o] = GameObject.Find("A_Shoulder_R_" + CharacterRace + "_" + o + "");
        }

        for (int shl = 0; shl < AllArmor.Length; shl++) { if (AllArmor[shl].name.Contains("A_Shoulder_L_" + CharacterRace)) { shoulderLQ++; } }
        shoulderLArmor = new GameObject[shoulderLQ];
        for (int n = 0; n < shoulderLQ; ++n)
        {                                                                                              //fill with Texture2D
            shoulderLArmor[n] = GameObject.Find("A_Shoulder_L_" + CharacterRace + "_" + n + "");
        }

        for (int arr = 0; arr < AllArmor.Length; arr++) { if (AllArmor[arr].name.Contains("A_Arm_R_" + CharacterRace)) { armRQ++; } }
        armRArmor = new GameObject[armRQ];
        for (int u = 0; u < armRQ; ++u)
        {                                                                                              //fill with Texture2D
            armRArmor[u] = GameObject.Find("A_Arm_R_" + CharacterRace + "_" + u + "");
        }

        for (int arl = 0; arl < AllArmor.Length; arl++) { if (AllArmor[arl].name.Contains("A_Arm_L_" + CharacterRace)) { armLQ++; } }
        armLArmor = new GameObject[armLQ];
        for (int t = 0; t < armLQ; ++t)
        {                                                                                              //fill with Texture2D
            armLArmor[t] = GameObject.Find("A_Arm_L_" + CharacterRace + "_" + t + "");
        }

        for (int lel = 0; lel < AllArmor.Length; lel++) { if (AllArmor[lel].name.Contains("A_Leg_L_" + CharacterRace)) { legLQ++; } }
        legLArmor = new GameObject[legLQ];
        for (int v = 0; v < legLQ; ++v)
        {                                                                                              //fill with Texture2D
            legLArmor[v] = GameObject.Find("A_Leg_L_" + CharacterRace + "_" + v + "");
        }

        for (int ler = 0; ler < AllArmor.Length; ler++) { if (AllArmor[ler].name.Contains("A_Leg_R_" + CharacterRace)) { legRQ++; } }
        legRArmor = new GameObject[legRQ];
        for (int w = 0; w < legRQ; ++w)
        {                                                                                              //fill with Texture2D
            legRArmor[w] = GameObject.Find("A_Leg_R_" + CharacterRace + "_" + w + "");
        }

        for (int wr = 0; wr < AllArmor.Length; wr++) { if (AllArmor[wr].name.Contains("W_R_")) { weaponRQ++; } }
        weaponRArmor = new GameObject[weaponRQ];
        for (int wir = 0; wir < weaponRQ; ++wir)
        {                                                                                              //fill with Texture2D
            weaponRArmor[wir] = GameObject.Find("W_R_" + wir + "");
        }

        for (int wl = 0; wl < AllArmor.Length; wl++) { if (AllArmor[wl].name.Contains("W_L_")) { weaponLQ++; } }
        weaponLArmor = new GameObject[weaponLQ];
        for (int wil = 0; wil < weaponLQ; ++wil)
        {                                                                                              //fill with Texture2D
            weaponLArmor[wil] = GameObject.Find("W_L_" + wil + "");
        }

        for (int bea = 0; bea < AllArmor.Length; bea++) { if (AllArmor[bea].name.Contains("A_BeltAdd_" + CharacterRace)) { beltAddQ++; } }
        beltAddArmor = new GameObject[beltAddQ];
        for (int ra = 0; ra < beltAddQ; ++ra)
        {
            beltAddArmor[ra] = GameObject.Find("A_BeltAdd_" + CharacterRace + "_" + ra + "");
        }

        // Find FxTorso and store
        for (int fxt = 0; fxt < AllArmor.Length; fxt++) { if (AllArmor[fxt].name.Contains("A_FXTorso_")) { FXQ++; } }
        FXArmor = new GameObject[FXQ];
        for (int fxu = 0; fxu < FXQ; ++fxu)
        {
            FXArmor[fxu] = GameObject.Find("A_FXTorso_" + fxu + "");
        }

        // how much armor by categorie
        // Set the quantity number of item for each category by the array Length
        headQ = headArmor.Length;
        hairModelQ = hairModel.Length;
        jawQ = jaw.Length;
        eyeQ = eyeAddArmor.Length;
        torsoQ = torsoArmor.Length;
        torsoAddQ = torsoAddArmor.Length;
        beltQ = beltArmor.Length;
        beltAddQ = beltAddArmor.Length;
        shoulderRQ = shoulderRArmor.Length;
        shoulderLQ = shoulderLArmor.Length;
        armRQ = armRArmor.Length;
        armLQ = armLArmor.Length;
        legRQ = legRArmor.Length;
        legLQ = legLArmor.Length;
        weaponRQ = weaponRArmor.Length;
        weaponLQ = weaponLArmor.Length;
        FXQ = FXArmor.Length;

        // Set a selected item for each category(the selected item is the one who will take place on the model it is the displayed model)
        headArmorS = headArmor[headN];
        hairModelS = hairModel[hairModelN];
        jawS = jaw[jawN];
        eyeS = eyeAddArmor[eyeN];
        torsoArmorS = torsoArmor[torsoN];
        torsoAddArmorS = torsoAddArmor[torsoAddN];
        beltArmorS = beltArmor[beltN];
        beltAddArmorS = beltAddArmor[beltAddN];
        shoulderRArmorS = shoulderRArmor[shoulderRN];
        shoulderLArmorS = shoulderLArmor[shoulderLN];
        armRArmorS = armRArmor[armRN];
        armLArmorS = armLArmor[armLN];
        legRArmorS = legRArmor[legRN];
        legLArmorS = legLArmor[legLN];
        weaponRArmorS = weaponRArmor[weaponRN];
        weaponLArmorS = weaponLArmor[weaponLN];
        FXArmorS = FXArmor[FXN];



        /////////////////
        ScarsN = NrScarsT;
        EyeBrowN = NrEyeBrowT;
        skinFaceN = NrSkinFaceT;
        colorNumber = NrColorNumberT;
        colorPilosityNumber = NrColorPilosityT;
        BeardN = NrBeardT;
        HairSkullN = NrHairSkullT;
        headAddN = NrHeadAddT;
        EyeN = NrEyeT;
        PantN = NrPantT;
        TorsoN = NrTorsoT;
        ShoeN = NrShoeT;
        GloveN = NrGloveT;
        BeltN = NrBeltT;
        robeLongN = NrRobeLongT;
        if (robeLongN >= 1) { robeLongB = true; RobeLongOn(); }
        if (robeLongN <= 0) { robeLongN = 0; robeLongB = false; RobeLongOff(); }
        robeShortN = NrRobeShortT;
        if (robeShortN >= 1) { robeShortB = true; RobeShortOn(); }
        if (robeShortN <= 0) { robeShortN = 0; robeShortB = false; RobeShortOff(); }


        //Random armor mesh
        // set the number of the selected item to be placed on the model

        hairModelN = NrHairM;
        headN = NrHeadM;
        jawN = NrJawM;
        eyeN = NrEyeM;
        torsoN = NrTorsoM;
        torsoAddN = NrTorsoAddM;
        beltN = NrBeltM;
        beltAddN = NrBeltAddM;
        shoulderRN = NrShoulderRM;
        shoulderLN = NrShoulderLM;
        armRN = NrArmRM;
        armLN = NrArmLM;
        legRN = NrLegRM;
        legLN = NrLegLM;
        weaponRN = NrWeaponRM;
        weaponLN = NrWeaponLM;
        //FXN = Random.Range(-5,FXQ); // enable it if you want FxTorso be part of the random


        //lunch pilosity function to remap the color on the mesh hair and the texture color
        //PilosityColor();

        // set all the bool  to false (no item is equiped)
        ArmorpartEquip[0] = false;
        ArmorpartEquip[1] = false;
        ArmorpartEquip[2] = false;
        ArmorpartEquip[3] = false;
        ArmorpartEquip[4] = false;
        ArmorpartEquip[5] = false;
        ArmorpartEquip[6] = false;
        ArmorpartEquip[7] = false;
        ArmorpartEquip[8] = false;
        ArmorpartEquip[9] = false;
        ArmorpartEquip[10] = false;
        ArmorpartEquip[11] = false;
        ArmorpartEquip[12] = false;
        ArmorpartEquip[13] = false;
        ArmorpartEquip[14] = false;

        //lunch texture feedback armor function 
       // FBTexArmor();

        // IF ITEM SELECTED IS DIFFERENT FROM 0 LUNCH EQUIP FUNCTION		OTHERWISE//set bool  of equiped item to false, remove item from model equiped armor array, lunch feedback texture armor function,remove armor part from the model
        if (headN > 0) { HeadEquip(); ArmorpartEquip[0] = true; } else { ArmorpartEquip[0] = false; equipedArmor[0] = null; FBTexArmor(); headArmorS.transform.position = anchorHead.position; headArmorS.transform.parent = anchorHead; }
        if (hairModelN > 0) { hairModelEquip(); ArmorpartEquip[1] = true; } else { ArmorpartEquip[1] = false; equipedArmor[1] = null; FBTexArmor(); hairModelS.transform.position = anchorHair.position; hairModelS.transform.parent = anchorHead; }
        if (jawN > 0) { JawEquip(); ArmorpartEquip[2] = true; } else { ArmorpartEquip[2] = false; equipedArmor[2] = null; FBTexArmor(); jawS.transform.position = anchorJaw.position; jawS.transform.parent = anchorJaw; }
        if (torsoN > 0) { TorsoEquip(); ArmorpartEquip[3] = true; } else { ArmorpartEquip[3] = false; equipedArmor[3] = null; FBTexArmor(); torsoArmorS.transform.position = anchorTorso.position; torsoArmorS.transform.parent = anchorTorso; }
        if (torsoAddN > 0) { TorsoAddEquip(); ArmorpartEquip[4] = true; } else { ArmorpartEquip[4] = false; equipedArmor[4] = null; FBTexArmor(); torsoAddArmorS.transform.position = anchorTorso.position; torsoAddArmorS.transform.parent = anchorTorso; }
        if (beltN > 0) { BeltEquip(); ArmorpartEquip[5] = true; } else { ArmorpartEquip[5] = false; equipedArmor[5] = null; FBTexArmor(); beltArmorS.transform.position = anchorBelt.position; beltArmorS.transform.parent = anchorBelt; }
        if (beltAddN > 0) { BeltAddEquip(); ArmorpartEquip[6] = true; } else { ArmorpartEquip[6] = false; equipedArmor[6] = null; FBTexArmor(); beltAddArmorS.transform.position = anchorBelt.position; beltAddArmorS.transform.parent = anchorBelt; }
        if (armLN > 0) { ArmLEquip(); ArmorpartEquip[10] = true; } else { ArmorpartEquip[10] = false; equipedArmor[10] = null; FBTexArmor(); armLArmorS.transform.position = anchorArmL.position; armLArmorS.transform.parent = anchorArmL; }
        if (armRN > 0) { ArmREquip(); ArmorpartEquip[9] = true; } else { ArmorpartEquip[9] = false; equipedArmor[9] = null; FBTexArmor(); armRArmorS.transform.position = anchorArmR.position; armRArmorS.transform.parent = anchorArmR; }
        if (legRN > 0) { LegREquip(); ArmorpartEquip[11] = true; } else { ArmorpartEquip[11] = false; equipedArmor[11] = null; FBTexArmor(); legRArmorS.transform.position = anchorLegR.position; legRArmorS.transform.parent = anchorLegR; }
        if (legLN > 0) { LegLEquip(); ArmorpartEquip[12] = true; } else { ArmorpartEquip[12] = false; equipedArmor[12] = null; FBTexArmor(); legLArmorS.transform.position = anchorLegL.position; legLArmorS.transform.parent = anchorLegL; }
        if (shoulderRN > 0) { ShoulderREquip(); ArmorpartEquip[7] = true; } else { ArmorpartEquip[7] = false; equipedArmor[7] = null; FBTexArmor(); shoulderRArmorS.transform.position = anchorShoulderR.position; shoulderRArmorS.transform.parent = anchorShoulderR; }
        if (shoulderLN > 0) { ShoulderLEquip(); ArmorpartEquip[8] = true; } else { ArmorpartEquip[8] = false; equipedArmor[8] = null; FBTexArmor(); shoulderLArmorS.transform.position = anchorShoulderL.position; shoulderLArmorS.transform.parent = anchorShoulderL; }
        if (weaponLN > 0) { WeaponLEquip(); ArmorpartEquip[14] = true; } else { ArmorpartEquip[14] = false; equipedArmor[14] = null; FBTexArmor(); weaponLArmorS.transform.position = anchorWeaponL.position; weaponLArmorS.transform.parent = anchorWeaponL; }
        if (weaponRN > 0) { WeaponREquip(); ArmorpartEquip[13] = true; } else { ArmorpartEquip[13] = false; equipedArmor[13] = null; FBTexArmor(); weaponRArmorS.transform.position = anchorWeaponR.position; weaponRArmorS.transform.parent = anchorWeaponR; }

        //if(FXN>=0){FXEquip();} else {FXArmorS.transform.position = anchorFX.position;FXArmorS.transform.parent = anchorFX;} if you want activate the fx in the randomness
        if (eyeN > 0) { EyeEquip(); } else { eyeS.transform.position = anchorEye.position; eyeS.transform.parent = anchorEye; }

        // lunch feedback texture armor
        FBTexArmor();
        StartCoroutine(ColorSkinF());
        // Destroy(gameObject);
    }
    // those function texture are a cascade of function, from color skin to belt every texture are aplied   // each time you lunch a function it start the following texure function
    void loadPlayer(int NrScarsTex, int NrEyeBrowTex, int NrSkinFaceTex, int NrColorNumberTex, int NrColorPilosityTex, int NrBeardTex, int NrHairSkullTex, int NrHeadAddTex, int NrEyeTex, int NrPantTex, int NrTexorsoTex, int NrShoeTex, int NrGloveTex, int NrBeltTex, int NrRobeLongTex, int NrRobeShortTex, int NrHairModel, int NrHeadModel, int NrJawModel, int NrEyeModel, int NrTexorsoModel, int NrTexorsoAddModel, int NrBeltModel, int NrBeltAddModel, int NrShoulderRModel, int NrShoulderLModel, int NrArmRModel, int NrArmLModel, int NrLegRModel, int NrLegLModel, int NrWeaponRModel, int NrWeaponLModel)
    {








        ////////////////////////////////////////////////////////////////////////////


        //remove all armor part from the model

        headArmorS.transform.position = anchorHead.position; headArmorS.transform.parent = anchorHead;
        hairModelS.transform.position = anchorHair.position; hairModelS.transform.parent = anchorHair;
        jawS.transform.position = anchorJaw.position; jawS.transform.parent = anchorJaw;
        eyeS.transform.position = anchorEye.position; eyeS.transform.parent = anchorEye;
        torsoArmorS.transform.position = anchorTorso.position; torsoArmorS.transform.parent = anchorTorso;
        torsoAddArmorS.transform.position = anchorTorso.position; torsoAddArmorS.transform.parent = anchorTorso;
        beltArmorS.transform.position = anchorBelt.position; beltArmorS.transform.parent = anchorBelt;
        beltAddArmorS.transform.position = anchorBelt.position; beltAddArmorS.transform.parent = anchorBelt;
        shoulderRArmorS.transform.position = anchorShoulderR.position; shoulderRArmorS.transform.parent = anchorShoulderR;
        shoulderLArmorS.transform.position = anchorShoulderL.position; shoulderLArmorS.transform.parent = anchorShoulderL;
        armLArmorS.transform.position = anchorArmL.position; armLArmorS.transform.parent = anchorArmL;
        armRArmorS.transform.position = anchorArmR.position; armRArmorS.transform.parent = anchorArmR;
        legRArmorS.transform.position = anchorLegR.position; legRArmorS.transform.parent = anchorLegR;
        legLArmorS.transform.position = anchorLegL.position; legLArmorS.transform.parent = anchorLegL;
        weaponRArmorS.transform.position = anchorWeaponR.position; weaponRArmorS.transform.parent = anchorWeaponR;
        weaponLArmorS.transform.position = anchorWeaponL.position; weaponLArmorS.transform.parent = anchorWeaponL;
        FXArmorS.transform.position = anchorFX.position; FXArmorS.transform.parent = anchorFX;

        // Random texture Skin
        // set the random range on each category of texture
        // - 5 because that make more chance no item is added to the model (you can modify this number to modify the randomness)
        BeltN = NrBeltTex;
        GloveN = NrGloveTex;
        ShoeN = NrShoeTex;
        TorsoN = NrTexorsoTex;
        PantN = NrPantTex;
        EyeN = NrEyeTex;
        HairSkullN = NrHairSkullTex;
        BeardN = NrBeardTex;
        ScarsN = NrScarsTex;
        EyeBrowN = NrEyeBrowTex;
        headAddN = NrHeadAddTex;
        skinFaceN = NrSkinFaceTex ;
        colorNumber = NrColorNumberTex;

        ////////////

        colorPilosityNumber = NrColorPilosityTex;



        robeLongN = NrRobeLongTex;
        if (robeLongN >= 1) { robeLongB = true; RobeLongOn(); }
        if (robeLongN <= 0) { robeLongN = 0; robeLongB = false; RobeLongOff(); }
        robeShortN = NrRobeShortTex;
        if (robeShortN >= 1) { robeShortB = true; RobeShortOn(); }
        if (robeShortN <= 0) { robeShortN = 0; robeShortB = false; RobeShortOff(); }

        Debug.Log(ScarsN);
        //Random armor mesh
        // set the number of the selected item to be placed on the model

        hairModelN = NrHairModel;
        headN = NrHeadModel;
        jawN = NrJawModel;
        eyeN = NrEyeModel;
        torsoN = NrTexorsoModel;
        torsoAddN = NrTexorsoAddModel;
        beltN = NrBeltModel;
        beltAddN = NrBeltAddModel;
        shoulderRN = NrShoulderRModel;
        shoulderLN = NrShoulderLModel;
        armRN = NrArmRModel;
        armLN = NrArmLModel;
        legRN = NrLegRModel;
        legLN = NrLegLModel;
        weaponRN = NrWeaponRModel;
        weaponLN = NrWeaponLModel;
        //FXN = Random.Range(-5,FXQ); // enable it if you want FxTorso be part of the random


        //lunch pilosity function to remap the color on the mesh hair and the texture color
        PilosityColor();

        // set all the bool  to false (no item is equiped)
        ArmorpartEquip[0] = false;
        ArmorpartEquip[1] = false;
        ArmorpartEquip[2] = false;
        ArmorpartEquip[3] = false;
        ArmorpartEquip[4] = false;
        ArmorpartEquip[5] = false;
        ArmorpartEquip[6] = false;
        ArmorpartEquip[7] = false;
        ArmorpartEquip[8] = false;
        ArmorpartEquip[9] = false;
        ArmorpartEquip[10] = false;
        ArmorpartEquip[11] = false;
        ArmorpartEquip[12] = false;
        ArmorpartEquip[13] = false;
        ArmorpartEquip[14] = false;

        //lunch texture feedback armor function 
        FBTexArmor();

        // IF ITEM SELECTED IS DIFFERENT FROM 0 LUNCH EQUIP FUNCTION		OTHERWISE//set bool  of equiped item to false, remove item from model equiped armor array, lunch feedback texture armor function,remove armor part from the model
        if (headN >= 0) { HeadEquip(); ArmorpartEquip[0] = true; } else { ArmorpartEquip[0] = false; equipedArmor[0] = null; FBTexArmor(); headArmorS.transform.position = anchorHead.position; headArmorS.transform.parent = anchorHead; }
        if (hairModelN >= 0) { hairModelEquip(); ArmorpartEquip[1] = true; } else { ArmorpartEquip[1] = false; equipedArmor[1] = null; FBTexArmor(); hairModelS.transform.position = anchorHair.position; hairModelS.transform.parent = anchorHead; }
        if (jawN >= 0) { JawEquip(); ArmorpartEquip[2] = true; } else { ArmorpartEquip[2] = false; equipedArmor[2] = null; FBTexArmor(); jawS.transform.position = anchorJaw.position; jawS.transform.parent = anchorJaw; }
        if (torsoN >= 0) { TorsoEquip(); ArmorpartEquip[3] = true; } else { ArmorpartEquip[3] = false; equipedArmor[3] = null; FBTexArmor(); torsoArmorS.transform.position = anchorTorso.position; torsoArmorS.transform.parent = anchorTorso; }
        if (torsoAddN >= 0) { TorsoAddEquip(); ArmorpartEquip[4] = true; } else { ArmorpartEquip[4] = false; equipedArmor[4] = null; FBTexArmor(); torsoAddArmorS.transform.position = anchorTorso.position; torsoAddArmorS.transform.parent = anchorTorso; }
        if (beltN >= 0) { BeltEquip(); ArmorpartEquip[5] = true; } else { ArmorpartEquip[5] = false; equipedArmor[5] = null; FBTexArmor(); beltArmorS.transform.position = anchorBelt.position; beltArmorS.transform.parent = anchorBelt; }
        if (beltAddN >= 0) { BeltAddEquip(); ArmorpartEquip[6] = true; } else { ArmorpartEquip[6] = false; equipedArmor[6] = null; FBTexArmor(); beltAddArmorS.transform.position = anchorBelt.position; beltAddArmorS.transform.parent = anchorBelt; }
        if (armLN >= 0) { ArmLEquip(); ArmorpartEquip[10] = true; } else { ArmorpartEquip[10] = false; equipedArmor[10] = null; FBTexArmor(); armLArmorS.transform.position = anchorArmL.position; armLArmorS.transform.parent = anchorArmL; }
        if (armRN >= 0) { ArmREquip(); ArmorpartEquip[9] = true; } else { ArmorpartEquip[9] = false; equipedArmor[9] = null; FBTexArmor(); armRArmorS.transform.position = anchorArmR.position; armRArmorS.transform.parent = anchorArmR; }
        if (legRN >= 0) { LegREquip(); ArmorpartEquip[11] = true; } else { ArmorpartEquip[11] = false; equipedArmor[11] = null; FBTexArmor(); legRArmorS.transform.position = anchorLegR.position; legRArmorS.transform.parent = anchorLegR; }
        if (legLN >= 0) { LegLEquip(); ArmorpartEquip[12] = true; } else { ArmorpartEquip[12] = false; equipedArmor[12] = null; FBTexArmor(); legLArmorS.transform.position = anchorLegL.position; legLArmorS.transform.parent = anchorLegL; }
        if (shoulderRN >= 0) { ShoulderREquip(); ArmorpartEquip[7] = true; } else { ArmorpartEquip[7] = false; equipedArmor[7] = null; FBTexArmor(); shoulderRArmorS.transform.position = anchorShoulderR.position; shoulderRArmorS.transform.parent = anchorShoulderR; }
        if (shoulderLN >= 0) { ShoulderLEquip(); ArmorpartEquip[8] = true; } else { ArmorpartEquip[8] = false; equipedArmor[8] = null; FBTexArmor(); shoulderLArmorS.transform.position = anchorShoulderL.position; shoulderLArmorS.transform.parent = anchorShoulderL; }
        if (weaponLN >= 0) { WeaponLEquip(); ArmorpartEquip[14] = true; } else { ArmorpartEquip[14] = false; equipedArmor[14] = null; FBTexArmor(); weaponLArmorS.transform.position = anchorWeaponL.position; weaponLArmorS.transform.parent = anchorWeaponL; }
        if (weaponRN >= 0) { WeaponREquip(); ArmorpartEquip[13] = true; } else { ArmorpartEquip[13] = false; equipedArmor[13] = null; FBTexArmor(); weaponRArmorS.transform.position = anchorWeaponR.position; weaponRArmorS.transform.parent = anchorWeaponR; }

        //if(FXN>=0){FXEquip();} else {FXArmorS.transform.position = anchorFX.position;FXArmorS.transform.parent = anchorFX;} if you want activate the fx in the randomness
        if (eyeN >= 0) { EyeEquip(); } else { eyeS.transform.position = anchorEye.position; eyeS.transform.parent = anchorEye; }

        // lunch feedback texture armor
        FBTexArmor();



        ////////////////////////////////////////////////////////////////////////////
    }
    IEnumerator ColorSkinF()
    {
        
        yield return null;
        if (colorNumber <= -1) { colorNumber = 5; }
        if (colorNumber >= 6) { colorNumber = 0; }
        if (colorNumber >= 0 && colorNumber <= 5)
        {

            atlasBaseSkinFace = new Texture2D[atlasBaseSearchSkinFace.Length];
            for (int a = 0; a < atlasBaseSearchSkinFace.Length; ++a)
            {
                atlasBaseSkinFace[a] = Resources.Load(
                "Character_Editor/Textures/Character/HumanMale/HumanMale_Color/Color" + colorNumber + "/HumanMale_Color" + colorNumber + "_FaceSkin" + a + "") as Texture2D;
            }
            skinFaceQ = atlasBaseSkinFace.Length;

            skinFaceS = atlasBaseSkinFace[skinFaceN];
            atlasBase = skinFaceS;
          //  Debug.LogError(atlasBase.width + "-" + atlasBase.height);
            ColorSkinCombine = new Texture2D(atlasBase.width, atlasBase.height);
            ColorSkinCombine.Apply();
            //StartCoroutine(SkinFaceCombineF());
           StartCoroutine( SkinFaceCombineF());
        }
        
    }

    IEnumerator SkinFaceCombineF()
    {
        yield return null;
        if (skinFaceN <= -1) { skinFaceN = skinFaceQ - 1; }
        if (skinFaceN >= skinFaceQ) { skinFaceN = 0; }
        if (skinFaceN >= 0 && skinFaceN <= skinFaceQ - 1)
        {

            skinFaceS = atlasBaseSkinFace[skinFaceN];
            atlasBase = skinFaceS;
            CombineAll = atlasBase;
            CombineAll.Apply();
            StartCoroutine(EyeBrowCombineF());
        }
        
    }

    IEnumerator EyeBrowCombineF()
    {
        yield return null;
        if (EyeBrowN <= -1) { EyeBrowN = EyeBrowQ - 1; }
        if (EyeBrowN >= EyeBrowQ) { EyeBrowN = 0; }
        if (EyeBrowN >= 0 && EyeBrowN <= EyeBrowQ - 1)
        {
            atlasBase = skinFaceS;
            Color[] pixelAtlasBase = atlasBase.GetPixels();           // array of color pixel //full atlas
            Color[] pixelBaseHead = atlasBase.GetPixels(384, 0, 640, 384);          // texture head base baseHead.GetPixels32();
            Color32[] pixelEyeBrow = EyeBrow[EyeBrowN].GetPixels32();   // Selected EyeBrow texture 
            for (int p = 0; p < pixelBaseHead.Length; ++p)
            {       //replace all pixel in head
                if (pixelEyeBrow[p].a != pixelBaseHead[p].a && pixelEyeBrow[p].a != 0)
                {                     // apply color for transparent pixel 
                    pixelBaseHead[p] = Color.Lerp(pixelBaseHead[p], pixelEyeBrow[p], Time.fixedDeltaTime * pixelEyeBrow[p].a);
                }
            }

            EyeBrowCombine = new Texture2D(atlasBase.width, atlasBase.height);
            EyeBrowCombine.SetPixels(pixelAtlasBase);
            EyeBrowCombine.SetPixels(384, 0, 640, 384, pixelBaseHead);
            EyeBrowCombine.Apply();
            StartCoroutine(ScarsCombineF());
        }
    }

    IEnumerator ScarsCombineF()
    {
        yield return null;
        if (ScarsN <= -1) { ScarsN = ScarsQ - 1; }
        if (ScarsN >= ScarsQ) { ScarsN = 0; }
        if (ScarsN >= 0 && ScarsN <= ScarsQ - 1)
        {
            atlasBase = EyeBrowCombine;
            Color[] pixelAtlasBase = atlasBase.GetPixels();           // array of color pixel //full atlas
            Color[] pixelBaseHead = atlasBase.GetPixels(384, 0, 640, 384);          // texture head base baseHead.GetPixels32();
            Color32[] pixelScars = Scars[ScarsN].GetPixels32();   // Selected Scars texture 
            for (int p = 0; p < pixelBaseHead.Length; ++p)
            {       //replace all pixel in head
                if (pixelScars[p].a != pixelBaseHead[p].a && pixelScars[p].a != 0)
                {                     // apply color for transparent pixel 
                    pixelBaseHead[p] = Color.Lerp(pixelBaseHead[p], pixelScars[p], Time.fixedDeltaTime * pixelScars[p].a);
                }
            }

            ScarsCombine = new Texture2D(atlasBase.width, atlasBase.height);
            ScarsCombine.SetPixels(pixelAtlasBase);
            ScarsCombine.SetPixels(384, 0, 640, 384, pixelBaseHead);
            ScarsCombine.Apply();
            StartCoroutine(BeardCombineF());

        }
    }
    IEnumerator BeardCombineF()
    {
        yield return null;
        if (BeardN <= -1) { BeardN = BeardQ - 1; }
        if (BeardN >= BeardQ) { BeardN = 0; }
        if (BeardN >= 0 && BeardN <= BeardQ - 1)
        {

            atlasBase = ScarsCombine;
            Color[] pixelAtlasBase = atlasBase.GetPixels();           // array of color pixel //full atlas
            Color[] pixelBaseHead = atlasBase.GetPixels(384, 0, 640, 384);          // texture head base baseHead.GetPixels32();
            Color32[] pixelBeard = Beard[BeardN].GetPixels32();   // Selected Beard texture 
            for (int p = 0; p < pixelBaseHead.Length; ++p)
            {       //replace all pixel in head
                if (pixelBeard[p].a != pixelBaseHead[p].a && pixelBeard[p].a != 0)
                {                     // apply color for transparent pixel 
                    pixelBaseHead[p] = Color.Lerp(pixelBaseHead[p], pixelBeard[p], Time.fixedDeltaTime * pixelBeard[p].a);
                }
            }

            BeardCombine = new Texture2D(atlasBase.width, atlasBase.height);
            BeardCombine.SetPixels(pixelAtlasBase);
            BeardCombine.SetPixels(384, 0, 640, 384, pixelBaseHead);

            BeardCombine.Apply();
            StartCoroutine(HairSkullCombineF());
        }
    }
    IEnumerator HairSkullCombineF()
    {
        yield return null;
        if (HairSkullN <= -1) { HairSkullN = HairSkullQ - 1; }
        if (HairSkullN >= HairSkullQ) { HairSkullN = 0; }
        if (HairSkullN >= 0 && HairSkullN <= HairSkullQ - 1)
        {

            atlasBase = BeardCombine;
            Color[] pixelAtlasBase = atlasBase.GetPixels();           // array of color pixel //full atlas
            Color[] pixelBaseHead = atlasBase.GetPixels(384, 0, 640, 384);          // texture head base baseHead.GetPixels32();
            Color32[] pixelHairSkull = HairSkull[HairSkullN].GetPixels32();   // Selected HairSkull texture 
            for (int p = 0; p < pixelBaseHead.Length; ++p)
            {       //replace all pixel in head
                if (pixelHairSkull[p].a != pixelBaseHead[p].a && pixelHairSkull[p].a != 0)
                {                     // apply color for transparent pixel 
                    pixelBaseHead[p] = Color.Lerp(pixelBaseHead[p], pixelHairSkull[p], Time.fixedDeltaTime * pixelHairSkull[p].a);
                }
            }

            HairSkullCombine = new Texture2D(atlasBase.width, atlasBase.height);
            HairSkullCombine.SetPixels(pixelAtlasBase);
            HairSkullCombine.SetPixels(384, 0, 640, 384, pixelBaseHead);

            HairSkullCombine.Apply();
            StartCoroutine(HeadAddCombineF());
        }
    }

    IEnumerator HeadAddCombineF()
    {
        yield return null;
        if (headAddN <= -1) { headAddN = headAddQ - 1; }
        if (headAddN >= headAddQ) { headAddN = 0; }
        if (headAddN >= 0 && headAddN <= headAddQ - 1)
        {

            atlasBase = HairSkullCombine;
            Color[] pixelAtlasBase = atlasBase.GetPixels();           // array of color pixel //full atlas
            Color[] pixelBaseHead = atlasBase.GetPixels(384, 0, 640, 384);          // texture head base baseHead.GetPixels32();
            Color32[] pixelHeadAdd = headAdd[headAddN].GetPixels32();   // Selected headAdd texture 
            for (int p = 0; p < pixelBaseHead.Length; ++p)
            {       //replace all pixel in head
                if (pixelHeadAdd[p].a != pixelBaseHead[p].a && pixelHeadAdd[p].a != 0)
                {                     // apply color for transparent pixel 
                    pixelBaseHead[p] = Color.Lerp(pixelBaseHead[p], pixelHeadAdd[p], Time.fixedDeltaTime * pixelHeadAdd[p].a);
                }
            }


            HeadAddCombine = new Texture2D(atlasBase.width, atlasBase.height);
            HeadAddCombine.SetPixels(pixelAtlasBase);
            HeadAddCombine.SetPixels(384, 0, 640, 384, pixelBaseHead);

            HeadAddCombine.Apply();
            StartCoroutine(EyeCombineF());

        }
    }
    IEnumerator EyeCombineF()
    {
        yield return null;
        if (EyeN <= -1) { EyeN = EyeQ - 1; }
        if (EyeN >= EyeQ) { EyeN = 0; }
        if (EyeN >= 0 && EyeN <= EyeQ - 1)
        {

            atlasBase = HeadAddCombine;

            Color[] pixelAtlasBase = atlasBase.GetPixels();           // array of color pixel //full atlas		 
            Color[] pixelEye = Eye[EyeN].GetPixels();                           // Selected Eye texture 

            EyeCombine = new Texture2D(atlasBase.width, atlasBase.height);
            EyeCombine.SetPixels(pixelAtlasBase);
            EyeCombine.SetPixels(960, 0, 64, 64, pixelEye);

            EyeCombine.Apply();
            StartCoroutine(PantCombineF());
        }
    }

    IEnumerator PantCombineF()
    {
        yield return null;
        if (PantN <= -1) { PantN = PantQ - 1; }
        if (PantN >= PantQ) { PantN = 0; }
        if (PantN >= 0 && PantN <= PantQ - 1)
        {

            atlasBase = EyeCombine;
            Color[] pixelAtlasBase = atlasBase.GetPixels();           // array of color pixel //full atlas
            Color[] pixelBaseHead = atlasBase.GetPixels(0, 0, 512, 576);        // texture head base baseHead.GetPixels32();
            Color32[] pixelPant = Pant[PantN].GetPixels32();                           // Selected Pant texture 
            for (int p = 0; p < pixelBaseHead.Length; ++p)
            {       //replace all pixel in head
                if (pixelPant[p].a != pixelBaseHead[p].a && pixelPant[p].a != 0)
                {                     // apply color for transparent pixel 
                    pixelBaseHead[p] = Color.Lerp(pixelBaseHead[p], pixelPant[p], Time.fixedDeltaTime * pixelPant[p].a);
                }
            }

            PantCombine = new Texture2D(atlasBase.width, atlasBase.height);
            PantCombine.SetPixels(pixelAtlasBase);
            PantCombine.SetPixels(0, 0, 512, 576, pixelBaseHead);

            PantCombine.Apply();
            StartCoroutine(TorsoCombineF());
        }
    }
    IEnumerator TorsoCombineF()
    {
        yield return null;
        if (TorsoN <= -1) { TorsoN = TorsoQ - 1; }
        if (TorsoN >= TorsoQ) { TorsoN = 0; }
        if (TorsoN >= 0 && TorsoN <= TorsoQ - 1)
        {

            atlasBase = PantCombine;
            Color[] pixelAtlasBase = atlasBase.GetPixels();           // array of color pixel //full atlas
            Color[] pixelBaseHead = atlasBase.GetPixels(0, 512, 1024, 512);         // texture head base baseHead.GetPixels32();
            Color32[] pixelTorso = Torso[TorsoN].GetPixels32();                           // Selected Torso texture 
            for (int p = 0; p < pixelBaseHead.Length; ++p)
            {       //replace all pixel in head
                if (pixelTorso[p].a != pixelBaseHead[p].a && pixelTorso[p].a != 0)
                {                     // apply color for transparent pixel 
                    pixelBaseHead[p] = Color.Lerp(pixelBaseHead[p], pixelTorso[p], Time.fixedDeltaTime * pixelTorso[p].a);
                }
            }

            TorsoCombine = new Texture2D(atlasBase.width, atlasBase.height);
            TorsoCombine.SetPixels(pixelAtlasBase);
            TorsoCombine.SetPixels(0, 512, 1024, 512, pixelBaseHead);

            TorsoCombine.Apply();
            StartCoroutine(ShoeCombineF());
        }
    }
    IEnumerator ShoeCombineF()
    {
        yield return null;
        if (ShoeN <= -1) { ShoeN = ShoeQ - 1; }
        if (ShoeN >= ShoeQ) { ShoeN = 0; }
        if (ShoeN >= 0 && ShoeN <= ShoeQ - 1)
        {

            atlasBase = TorsoCombine;
            Color[] pixelAtlasBase = atlasBase.GetPixels();           // array of color pixel //full atlas
            Color[] pixelBaseHead = atlasBase.GetPixels(0, 0, 384, 448);        // texture head base baseHead.GetPixels32();
            Color32[] pixelShoe = Shoe[ShoeN].GetPixels32();                           // Selected Shoe texture 
            for (int p = 0; p < pixelBaseHead.Length; ++p)
            {       //replace all pixel in head
                if (pixelShoe[p].a != pixelBaseHead[p].a && pixelShoe[p].a != 0)
                {                     // apply color for transparent pixel 
                    pixelBaseHead[p] = Color.Lerp(pixelBaseHead[p], pixelShoe[p], Time.fixedDeltaTime * pixelShoe[p].a);
                }
            }

            ShoeCombine = new Texture2D(atlasBase.width, atlasBase.height);
            ShoeCombine.SetPixels(pixelAtlasBase);
            ShoeCombine.SetPixels(0, 0, 384, 448, pixelBaseHead);
            ShoeCombine.Apply();
            StartCoroutine(GloveCombineF());
        }
    }
    IEnumerator GloveCombineF()
    {
        yield return null;
        if (GloveN <= -1) { GloveN = GloveQ - 1; }
        if (GloveN >= GloveQ) { GloveN = 0; }
        if (GloveN >= 0 && GloveN <= GloveQ - 1)
        {

            atlasBase = ShoeCombine;
            Color[] pixelAtlasBase = atlasBase.GetPixels();           // array of color pixel //full atlas
            Color[] pixelBaseHead = atlasBase.GetPixels(512, 384, 512, 448);        // texture head base baseHead.GetPixels32();
            Color32[] pixelGlove = Glove[GloveN].GetPixels32();                           // Selected Glove texture 
            for (int p = 0; p < pixelBaseHead.Length; ++p)
            {       //replace all pixel in head 
                if (pixelGlove[p].a != pixelBaseHead[p].a && pixelGlove[p].a != 0)
                {                     // apply color for transparent pixel 
                    pixelBaseHead[p] = Color.Lerp(pixelBaseHead[p], pixelGlove[p], Time.fixedDeltaTime * pixelGlove[p].a);
                }
            }

            GloveCombine = new Texture2D(atlasBase.width, atlasBase.height);
            GloveCombine.SetPixels(pixelAtlasBase);
            GloveCombine.SetPixels(512, 384, 512, 448, pixelBaseHead);

            GloveCombine.Apply();
            StartCoroutine(RobeLongCombine());
        }
    }

    IEnumerator RobeLongCombine()
    {
        yield return null;
        if (robeLongB == true)
        {
            if (robeLongN <= -1) { robeLongN = robeLongQ - 1; }
            if (robeLongN >= robeLongQ) { robeLongN = 1; }
            if (robeLongN == 0) { robeLongN++; }
            if (robeLongN >= 1 && robeLongN <= robeLongQ - 1)
            {

                atlasBase = GloveCombine;
                Color[] pixelAtlasBase = atlasBase.GetPixels();           // array of color pixel //full atlas
                Color[] pixelBaseHead = atlasBase.GetPixels(0, 0, 512, 576);        // texture head base baseHead.GetPixels32();
                Color32[] pixelRobeLong = robeLongTex[robeLongN].GetPixels32();                           // Selected Pant texture 
                for (int p = 0; p < pixelBaseHead.Length; ++p)
                {       //replace all pixel in head
                    if (pixelRobeLong[p].a != pixelBaseHead[p].a && pixelRobeLong[p].a != 0)
                    {                     // apply color for transparent pixel 
                        pixelBaseHead[p] = Color.Lerp(pixelBaseHead[p], pixelRobeLong[p], Time.fixedDeltaTime * pixelRobeLong[p].a);
                    }
                }

                robeLongCombine = new Texture2D(atlasBase.width, atlasBase.height);
                robeLongCombine.SetPixels(pixelAtlasBase);
                robeLongCombine.SetPixels(0, 0, 512, 576, pixelBaseHead);

                robeLongCombine.Apply();
                StartCoroutine(RobeShortCombine());
            }

        }
        else
        {
            atlasBase = GloveCombine;
            Color[] pixelAtlasBase1 = atlasBase.GetPixels();           // array of color pixel //full atlas
            Color[] pixelBaseHead1 = atlasBase.GetPixels(0, 0, 512, 576);           // texture head base baseHead.GetPixels32();
            Color32[] pixelRobeLong1 = robeLongTex[0].GetPixels32();                           // Selected Pant texture 
            for (int p1 = 0; p1 < pixelBaseHead1.Length; ++p1)
            {       //replace all pixel in head
                if (pixelRobeLong1[p1].a != pixelBaseHead1[p1].a && pixelRobeLong1[p1].a != 0)
                {                     // apply color for transparent pixel 
                    pixelBaseHead1[p1] = Color.Lerp(pixelBaseHead1[p1], pixelRobeLong1[p1], Time.fixedDeltaTime * pixelRobeLong1[p1].a);
                }
            }

            robeLongCombine = new Texture2D(atlasBase.width, atlasBase.height);
            robeLongCombine.SetPixels(pixelAtlasBase1);
            robeLongCombine.SetPixels(0, 0, 512, 576, pixelBaseHead1);

            robeLongCombine.Apply();
            StartCoroutine(RobeShortCombine());
        }

    }//
    IEnumerator RobeShortCombine()
    {
        yield return null;
        if (robeShortB == true)
        {
            if (robeShortN <= -1) { robeShortN = robeShortQ - 1; }
            if (robeShortN >= robeShortQ) { robeShortN = 1; }
            if (robeShortN == 0) { robeShortN++; }
            if (robeShortN >= 1 && robeShortN <= robeShortQ - 1)
            {

                atlasBase = robeLongCombine;
                Color[] pixelAtlasBase = atlasBase.GetPixels();           // array of color pixel //full atlas
                Color[] pixelBaseHead = atlasBase.GetPixels(0, 0, 512, 576);        // texture head base baseHead.GetPixels32();
                Color32[] pixelrobeShort = robeShortTex[robeShortN].GetPixels32();                           // Selected Pant texture 
                for (int p = 0; p < pixelBaseHead.Length; ++p)
                {       //replace all pixel in head
                    if (pixelrobeShort[p].a != pixelBaseHead[p].a && pixelrobeShort[p].a != 0)
                    {                     // apply color for transparent pixel 
                        pixelBaseHead[p] = Color.Lerp(pixelBaseHead[p], pixelrobeShort[p], Time.fixedDeltaTime * pixelrobeShort[p].a);
                    }
                }

                robeShortCombine = new Texture2D(atlasBase.width, atlasBase.height);
                robeShortCombine.SetPixels(pixelAtlasBase);
                robeShortCombine.SetPixels(0, 0, 512, 576, pixelBaseHead);

                robeShortCombine.Apply();
                StartCoroutine(BeltCombineF());

            }


        }
        else
        {
            atlasBase = robeLongCombine;
            Color[] pixelAtlasBase1 = atlasBase.GetPixels();           // array of color pixel //full atlas
            Color[] pixelBaseHead1 = atlasBase.GetPixels(0, 0, 512, 576);           // texture head base baseHead.GetPixels32();
            Color32[] pixelrobeShort1 = robeShortTex[0].GetPixels32();                           // Selected Pant texture 
            for (int p1 = 0; p1 < pixelBaseHead1.Length; ++p1)
            {       //replace all pixel in head
                if (pixelrobeShort1[p1].a != pixelBaseHead1[p1].a && pixelrobeShort1[p1].a != 0)
                {                     // apply color for transparent pixel 
                    pixelBaseHead1[p1] = Color.Lerp(pixelBaseHead1[p1], pixelrobeShort1[p1], Time.fixedDeltaTime * pixelrobeShort1[p1].a);
                }
            }

            robeShortCombine = new Texture2D(atlasBase.width, atlasBase.height);
            robeShortCombine.SetPixels(pixelAtlasBase1);
            robeShortCombine.SetPixels(0, 0, 512, 576, pixelBaseHead1);

            robeShortCombine.Apply();
            StartCoroutine(BeltCombineF());
        }


    }

    IEnumerator BeltCombineF()
    {
        yield return null;
        if (BeltN <= -1) { BeltN = BeltQ - 1; }
        if (BeltN >= BeltQ) { BeltN = 0; }
        if (BeltN >= 0 && BeltN <= BeltQ - 1)
        {

            atlasBase = robeShortCombine;
            Color[] pixelAtlasBase = atlasBase.GetPixels();           // array of color pixel //full atlas
            Color[] pixelBaseHead = atlasBase.GetPixels(0, 512, 512, 256);          // texture head base baseHead.GetPixels32();
            Color32[] pixelBelt = Belt[BeltN].GetPixels32();                           // Selected Belt texture 
            for (int p = 0; p < pixelBaseHead.Length; ++p)
            {       //replace all pixel in head
                if (pixelBelt[p].a != pixelBaseHead[p].a && pixelBelt[p].a != 0)
                {                     // apply color for transparent pixel 
                    pixelBaseHead[p] = Color.Lerp(pixelBaseHead[p], pixelBelt[p], Time.fixedDeltaTime * pixelBelt[p].a);
                }
            }

            BeltCombine = new Texture2D(atlasBase.width, atlasBase.height);
            BeltCombine.SetPixels(pixelAtlasBase);
            BeltCombine.SetPixels(0, 512, 512, 256, pixelBaseHead);

            BeltCombine.Apply();
            CombineAll = BeltCombine;
            for (int rendN = 0; rendN < ModelRenderers.Length; rendN++)
            {
                ModelRenderers[rendN].material.mainTexture = BeltCombine;
            }
          //  planeRend.material.mainTexture = BeltCombine;
            CombineAll = BeltCombine;
        }
        //Debug.LogError(";");
        WaitingPanel.SetActive(false);
    }
    ////////////////////////////////////////////////////////////////////    ___    ____  __  _______  ____ 
    ////////////////////////////////////////////////////////////////////   /   |  / __ \/  |/  / __ \/ __ \////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////  / /| | / /_/ / /|_/ / / / / /_/ /////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////// / ___ |/ _, _/ /  / / /_/ / _, _/ ////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////_/  |_/_/ |_/_/  /_/\____/_/ |_| //////////////////////////////////////////////////////////////////// 

    // all these function equip the selected item on the bone, based on the categorie
    void HeadEquip()
    {
        // fix item number 
        if (headN < 0) { headN = headQ - 1; }
        if (headN > headQ - 1) { headN = 0; }
        // Equip head item base on is number
        if (headN >= 0 && headN <= headQ)
        {
            headArmorS = headArmor[headN];
            equipedArmor[0] = headArmorS;
            headArmor[headN].transform.position = headAnchor.position;
            headArmor[headN].transform.rotation = headAnchor.rotation;
            headArmor[headN].transform.parent = headAnchor;
        }
    }
    void hairModelEquip()
    {
        // fix item number 
        if (hairModelN < 0) { hairModelN = hairModelQ - 1; }
        if (hairModelN > hairModelQ - 1) { hairModelN = 0; }
        // Equip hairModel item base on is number

        //if(headN >= 1) {hairModelN = 0;}		          //remove hair if helm equiped

        if (hairModelN >= 0 && hairModelN <= hairModelQ)
        {
            hairModelS = hairModel[hairModelN];
            equipedArmor[1] = hairModelS;
            hairModel[hairModelN].transform.position = headAnchor.position;
            hairModel[hairModelN].transform.rotation = headAnchor.rotation;
            hairModel[hairModelN].transform.parent = headAnchor;
            //get the colorPilosity texture for hair model and match texture skin colorpilosity
            // 4 BECAUSE THERRE IS 4 COLOR FOR NOW !!!
            hairTex = new Texture2D[4];                                                                                             //resize array
            for (int ht = 0; ht < 4; ++ht)
            {                                                                                              //fill with Texture2D
                hairTex[ht] = Resources.Load("Character_Editor/Textures/Armor/HairModel/" + hairModelN + "/A_HumanMale_HairModel_" + hairModelN + "_Color_" + ht + "") as Texture2D;
            }
            hairTexQ = hairTex.Length;
            lodHairGet = hairModel[hairModelN].transform.GetComponentsInChildren<Renderer>();
            for (int LODhair = 0; LODhair < lodHairGet.Length; LODhair++)
            {
                lodHairGet[LODhair].GetComponent<Renderer>().material.mainTexture = hairTex[colorPilosityNumber];
            }
        }
    }
    void JawEquip()
    {
        // fix item number 
        if (jawN < 0) { jawN = jawQ - 1; }
        if (jawN > jawQ - 1) { jawN = 0; }
        // Equip jaw item base on is number
        if (jawN >= 0 && jawN <= jawQ - 1)
        {
            jawS = jaw[jawN];
            equipedArmor[2] = jawS;
            jaw[jawN].transform.position = jawAnchor.position;
            jaw[jawN].transform.rotation = jawAnchor.rotation;
            jaw[jawN].transform.parent = jawAnchor;

            //get the colorPilosity texture for hair model and match texture skin colorpilosity
            // 4 BECAUSE THERRE IS 4 COLOR FOR NOW !!!
            jawTex = new Texture2D[4];                                                                                              //resize array
            for (int jt = 0; jt < 4; ++jt)
            {                                                                                              //fill with Texture2D
                jawTex[jt] = Resources.Load("Character_Editor/Textures/Armor/Jaw/" + jawN + "/A_HumanMale_BeardModel_" + jawN + "_Color_" + jt + "") as Texture2D;
            }
            jawTexQ = jawTex.Length;
            lodJawGet = jaw[jawN].transform.GetComponentsInChildren<Renderer>();
            for (int LODjaw = 0; LODjaw < lodJawGet.Length; LODjaw++)
            {
                lodJawGet[LODjaw].GetComponent<Renderer>().material.mainTexture = jawTex[colorPilosityNumber];
            }
        }
    }
    void EyeEquip()
    {
        // fix item number 
        if (eyeN < 0) { eyeN = eyeQ - 1; }
        if (eyeN > eyeQ - 1) { eyeN = 0; }
        // Equip eye item base on is number
        if (eyeN >= 0 && eyeN <= eyeQ - 1)
        {
            eyeS = eyeAddArmor[eyeN];
            eyeAddArmor[eyeN].transform.position = headAnchor.position;
            eyeAddArmor[eyeN].transform.rotation = headAnchor.rotation;
            eyeAddArmor[eyeN].transform.parent = headAnchor;
        }
    }
    void TorsoEquip()
    {
        // fix item number 
        if (torsoN < 0) { torsoN = torsoQ - 1; }
        if (torsoN > torsoQ - 1) { torsoN = 0; }
        // Equip torso item base on is number
        if (torsoN >= 0 && torsoN <= torsoQ - 1)
        {
            torsoArmorS = torsoArmor[torsoN];
            equipedArmor[3] = torsoArmorS;
            torsoArmor[torsoN].transform.position = torsoAnchor.position;
            torsoArmor[torsoN].transform.rotation = torsoAnchor.rotation;
            torsoArmor[torsoN].transform.parent = torsoAnchor;
        }
    }
    void TorsoAddEquip()
    {
        // fix item number 
        if (torsoAddN < 0) { torsoAddN = torsoAddQ - 1; }
        if (torsoAddN > torsoAddQ - 1) { torsoAddN = 0; }
        // Equip torso item base on is number
        if (torsoAddN >= 0 && torsoAddN <= torsoAddQ)
        {
            torsoAddArmorS = torsoAddArmor[torsoAddN];
            equipedArmor[4] = torsoAddArmorS;
            torsoAddArmor[torsoAddN].transform.position = torsoAnchor.position;
            torsoAddArmor[torsoAddN].transform.rotation = torsoAnchor.rotation;
            torsoAddArmor[torsoAddN].transform.parent = torsoAnchor;
        }
    }
    void BeltEquip()
    {
        // fix item number 
        if (beltN < 0) { beltN = beltQ - 1; }
        if (beltN > beltQ - 1) { beltN = 0; }
        // Equip belt item base on is number
        if (beltN >= 0 && beltN <= beltQ)
        {
            beltArmorS = beltArmor[beltN];
            equipedArmor[5] = beltArmorS;
            beltArmor[beltN].transform.position = beltAnchor.position;
            beltArmor[beltN].transform.rotation = beltAnchor.rotation;
            beltArmor[beltN].transform.parent = beltAnchor;
        }
    }
    void BeltAddEquip()
    {
        // fix item number 
        if (beltAddN < 0) { beltAddN = beltAddQ - 1; }
        if (beltAddN > beltAddQ - 1) { beltAddN = 0; }
        // Equip belt item base on is number
        if (beltAddN >= 0 && beltAddN <= beltAddQ - 1)
        {
            beltAddArmorS = beltAddArmor[beltAddN];
            equipedArmor[6] = beltAddArmorS;
            beltAddArmor[beltAddN].transform.position = beltAnchor.position;
            beltAddArmor[beltAddN].transform.rotation = beltAnchor.rotation;
            beltAddArmor[beltAddN].transform.parent = beltAnchor;
        }
    }
    void ShoulderREquip()
    {
        // fix item number 
        if (shoulderRN < 0) { shoulderRN = shoulderRQ - 1; }
        if (shoulderRN > shoulderRQ - 1) { shoulderRN = 0; }
        // Equip shoulderR item base on is number
        if (shoulderRN >= 0 && shoulderRN <= shoulderRQ - 1)
        {
            shoulderRArmorS = shoulderRArmor[shoulderRN];
            equipedArmor[7] = shoulderRArmorS;
            shoulderRArmor[shoulderRN].transform.position = shoulderRAnchor.position;
            shoulderRArmor[shoulderRN].transform.rotation = shoulderRAnchor.rotation;
            shoulderRArmor[shoulderRN].transform.parent = shoulderRAnchor;
        }
    }
    void ShoulderLEquip()
    {
        // fix item number 
        if (shoulderLN < 0) { shoulderLN = shoulderLQ - 1; }
        if (shoulderLN > shoulderLQ - 1) { shoulderLN = 0; }
        // Equip shoulderL item base on is number
        if (shoulderLN >= 0 && shoulderLN <= shoulderLQ - 1)
        {
            shoulderLArmorS = shoulderLArmor[shoulderLN];
            equipedArmor[8] = shoulderLArmorS;
            shoulderLArmor[shoulderLN].transform.position = shoulderLAnchor.position;
            shoulderLArmor[shoulderLN].transform.rotation = shoulderLAnchor.rotation;
            shoulderLArmor[shoulderLN].transform.parent = shoulderLAnchor;
        }
    }
    void ArmREquip()
    {
        // fix item number 
        if (armRN < 0) { armRN = armRQ - 1; }
        if (armRN > armRQ - 1) { armRN = 0; }
        // Equip armR item base on is number
        if (armRN >= 0 && armRN <= armRQ - 1)
        {
            armRArmorS = armRArmor[armRN];
            equipedArmor[9] = armRArmorS;
            armRArmor[armRN].transform.position = armRAnchor.position;
            armRArmor[armRN].transform.rotation = armRAnchor.rotation;
            armRArmor[armRN].transform.parent = armRAnchor;
        }
    }
    void ArmLEquip()
    {
        // fix item number 
        if (armLN < 0) { armLN = armLQ - 1; }
        if (armLN > armLQ - 1) { armLN = 0; }
        // Equip armL item base on is number
        if (armLN >= 0 && armLN <= armLQ - 1)
        {
            armLArmorS = armLArmor[armLN];
            equipedArmor[10] = armLArmorS;
            armLArmor[armLN].transform.position = armLAnchor.position;
            armLArmor[armLN].transform.rotation = armLAnchor.rotation;
            armLArmor[armLN].transform.parent = armLAnchor;
        }
    }
    void LegREquip()
    {
        // fix item number 
        if (legRN < 0) { legRN = legRQ - 1; }
        if (legRN > legRQ - 1) { legRN = 0; }
        // Equip legR item base on is number
        if (legRN >= 0 && legRN <= legRQ - 1)
        {
            legRArmorS = legRArmor[legRN];
            equipedArmor[11] = legRArmorS;
            legRArmor[legRN].transform.position = legRAnchor.position;
            legRArmor[legRN].transform.rotation = legRAnchor.rotation;
            legRArmor[legRN].transform.parent = legRAnchor;
        }
    }
    void LegLEquip()
    {
        // fix item number 
        if (legLN < 0) { legLN = legLQ - 1; }
        if (legLN > legLQ - 1) { legLN = 0; }
        // Equip legL item base on is number
        if (legLN >= 0 && legLN <= legLQ - 1)
        {
            legLArmorS = legLArmor[legLN];
            equipedArmor[12] = legLArmorS;
            legLArmor[legLN].transform.position = legLAnchor.position;
            legLArmor[legLN].transform.rotation = legLAnchor.rotation;
            legLArmor[legLN].transform.parent = legLAnchor;
        }
    }
    void WeaponREquip()
    {
        // fix item number 
        if (weaponRN <= 0) { weaponRN = weaponRQ - 1; }
        if (weaponRN >= weaponRQ) { weaponRN = 1; }
        // Equip weaponR item base on is number
        if (weaponRN >= 0 && weaponRN <= weaponRQ - 1)
        {
            weaponRArmorS = weaponRArmor[weaponRN];
            equipedArmor[13] = weaponRArmorS;
            weaponRArmor[weaponRN].transform.position = weaponRAnchor.position;
            weaponRArmor[weaponRN].transform.rotation = weaponRAnchor.rotation;
            weaponRArmor[weaponRN].transform.parent = weaponRAnchor;
            //weaponRArmorSTexture = weaponRArmor[weaponRN].GetComponent.<Renderer>().material.mainTexture as Texture2D;
            if(gameObject.transform.root.Find("Weapons"))
            gameObject.transform.root.Find("Weapons").GetComponent<ActivateWeapons>().weapons[0] = weaponRArmor[weaponRN].gameObject;

        }
    }
    void WeaponLEquip()
    {
        // fix item number 
        if (weaponLN <= 0) { weaponLN = weaponLQ - 1; }
        if (weaponLN >= weaponLQ) { weaponLN = 1; }
        // Equip weaponL item base on is number
        if (weaponLN >= 0 && weaponLN <= weaponLQ - 1)
        {
            weaponLArmorS = weaponLArmor[weaponLN];
            equipedArmor[14] = weaponLArmorS;
            weaponLArmor[weaponLN].transform.position = weaponLAnchor.position;
            weaponLArmor[weaponLN].transform.rotation = weaponLAnchor.rotation;
            weaponLArmor[weaponLN].transform.parent = weaponLAnchor;
            if (gameObject.transform.root.Find("Weapons"))
            {
                gameObject.transform.root.Find("Weapons").GetComponent<ActivateWeapons>().weapons[1] = weaponLArmor[weaponLN].gameObject;
                
            }
        }
    }
    void FXEquip()
    {
        // fix item number 
        if (FXN <= 0) { FXN = FXQ - 1; }
        if (FXN >= FXQ) { FXN = 1; }
        // Equip FX item base on is number
        if (FXN >= 0 && FXN <= FXQ - 1)
        {
            FXArmorS = FXArmor[FXN];
            FXArmor[FXN].transform.position = FXAnchor.position;
            FXArmor[FXN].transform.rotation = FXAnchor.rotation;
            FXArmor[FXN].transform.parent = FXAnchor;
        }
    }


    void CloakOn()
    {
        if (cloakN <= 0) { cloakN = cloakQ - 1; }
        if (cloakN >= cloakQ) { cloakN = 0; }
        if (cloakN >= 0 && cloakN <= cloakQ - 1)
        {
            for (int clo = 0; clo < cloak.Length; clo++)
            {
                cloak[clo].SetActive(true);
                cloak[clo].transform.GetComponent<Renderer>().material.mainTexture = cloakTex[cloakN];
            }
        }

    }
    void CloakOff()
    {
        for (int clo1 = 0; clo1 < cloak.Length; clo1++)
        {
            cloak[clo1].SetActive(false);
        }

    }

    void RobeLongOn()
    {
        if (robeLongN <= 0) { robeLongN = robeLongQ - 1; }
        if (robeLongN >= robeLongQ) { robeLongN = 0; }
        if (robeLongN >= 0 && robeLongN <= robeLongQ - 1)
        {
            for (int rl1 = 0; rl1 < LongRobe.Length; rl1++)
            {
                LongRobe[rl1].SetActive(true);
            }
        }

    }
    void RobeLongOff()
    {
        for (int rl2 = 0; rl2 < LongRobe.Length; rl2++)
        {
            LongRobe[rl2].SetActive(false);
        }

    }

    void RobeShortOn()
    {
        if (robeShortN <= 0) { robeShortN = robeShortQ - 1; }
        if (robeShortN >= robeShortQ) { robeShortN = 0; }
        if (robeShortN >= 0 && robeShortN <= robeShortQ - 1)
        {
            for (int rl1 = 0; rl1 < ShortRobe.Length; rl1++)
            {
                ShortRobe[rl1].SetActive(true);
            }
        }

    }
    void RobeShortOff()
    {
        for (int rl2 = 0; rl2 < ShortRobe.Length; rl2++)
        {
            ShortRobe[rl2].SetActive(false);
        }

    }






    //Armor texture render

    //Update FeedBack Texture Armor
    // this function give a feedback on the armor texture to be exported on the save function
    void FBTexArmor()
    {
        AllArmorsPartQ = 0;
        for (int fbtxa = 0; fbtxa < ArmorpartEquip.Length; fbtxa++)
        {
            if (ArmorpartEquip[fbtxa] == true)
            {
                AllArmorsPartQ++;
            }
        }

        if (AllArmorsPartQ == 0)
        {
           // planeArmor512.SetActive(false);
          //  planeArmor1024.SetActive(false);
          //  planeArmor2048.SetActive(false);
        }

        if (AllArmorsPartQ == 1)
        {
          //  planeArmor512.SetActive(true);
          //  planeArmor1024.SetActive(false);
           // planeArmor2048.SetActive(false);
            for (int texA1 = 0; texA1 < equipedArmor.Length; texA1++)
            {
                if (equipedArmor[texA1] != null)
                {
                    MatArmor = equipedArmor[texA1].GetComponentInChildren<Renderer>().material;
                   // planeArmor512.transform.GetComponent<Renderer>().material = MatArmor;
                }
            }
        }

        if (AllArmorsPartQ == 2 || AllArmorsPartQ == 3 || AllArmorsPartQ == 4)
        {
            MatItemNumber = 0;
         //   planeArmor512.SetActive(false);
          //  //planeArmor1024.SetActive(true);
           // //planeArmor2048.SetActive(false);
            //reset all texture mat
            //for(int rez1= 0; rez1 <= AllArmorsPartQ; rez1++){

            //	}
            for (int texA2 = 0; texA2 < equipedArmor.Length; texA2++)
            {
                if (equipedArmor[texA2] != null)
                {
                    MatItemNumber++;

                    for (int itn = 0; itn <= MatItemNumber; itn++)
                    {
                        MatArmorPart[itn] = equipedArmor[texA2].GetComponentInChildren<Renderer>().material;
                        if (MatItemNumber == 1)
                        {
                            //planeArmor1024Tex[0].transform.GetComponent<Renderer>().material = MatArmorPart[itn];
                            //planeArmor1024Tex[1].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor1024Tex[2].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor1024Tex[3].transform.GetComponent<Renderer>().material = NoneMat;
                        }
                        if (MatItemNumber == 2)
                        {
                            //planeArmor1024Tex[1].transform.GetComponent<Renderer>().material = MatArmorPart[itn];
                            //planeArmor1024Tex[2].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor1024Tex[3].transform.GetComponent<Renderer>().material = NoneMat;
                        }
                        if (MatItemNumber == 3)
                        {
                            //planeArmor1024Tex[2].transform.GetComponent<Renderer>().material = MatArmorPart[itn];
                            //planeArmor1024Tex[3].transform.GetComponent<Renderer>().material = NoneMat;
                        }
                        if (MatItemNumber == 4)
                        {
                            //planeArmor1024Tex[3].transform.GetComponent<Renderer>().material = MatArmorPart[itn];
                        }
                    }
                }
            }

        }

        if (AllArmorsPartQ > 4)
        {
            MatItemNumber = 0;
            //planeArmor512.SetActive(false);
            //planeArmor1024.SetActive(false);
            //planeArmor2048.SetActive(true);
            for (int texA3 = 0; texA3 < equipedArmor.Length; texA3++)
            {
                if (equipedArmor[texA3] != null)
                {
                    MatItemNumber++;
                    for (int itn1 = 0; itn1 <= MatItemNumber; itn1++)
                    {
                        MatArmorPart[itn1] = equipedArmor[texA3].GetComponentInChildren<Renderer>().material;
                        if (MatItemNumber == 1)
                        {
                            //planeArmor2048Tex[0].transform.GetComponent<Renderer>().material = MatArmorPart[itn1];
                        }
                        if (MatItemNumber == 2)
                        {
                            //planeArmor2048Tex[1].transform.GetComponent<Renderer>().material = MatArmorPart[itn1];
                            //planeArmor2048Tex[2].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[3].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[4].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[5].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[6].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[7].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[8].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[9].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[10].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[11].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[12].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[13].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[14].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[15].transform.GetComponent<Renderer>().material = NoneMat;
                        }
                        if (MatItemNumber == 3)
                        {
                            //planeArmor2048Tex[2].transform.GetComponent<Renderer>().material = MatArmorPart[itn1];
                            //planeArmor2048Tex[3].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[4].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[5].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[6].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[7].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[8].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[9].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[10].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[11].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[12].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[13].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[14].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[15].transform.GetComponent<Renderer>().material = NoneMat;
                        }
                        if (MatItemNumber == 4)
                        {
                            //planeArmor2048Tex[3].transform.GetComponent<Renderer>().material = MatArmorPart[itn1];
                            //planeArmor2048Tex[4].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[5].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[6].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[7].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[8].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[9].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[10].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[11].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[12].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[13].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[14].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[15].transform.GetComponent<Renderer>().material = NoneMat;
                        }
                        if (MatItemNumber == 5)
                        {
                            //planeArmor2048Tex[4].transform.GetComponent<Renderer>().material = MatArmorPart[itn1];
                            //planeArmor2048Tex[5].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[6].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[7].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[8].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[9].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[10].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[11].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[12].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[13].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[14].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[15].transform.GetComponent<Renderer>().material = NoneMat;
                        }
                        if (MatItemNumber == 6)
                        {
                            //planeArmor2048Tex[5].transform.GetComponent<Renderer>().material = MatArmorPart[itn1];
                            //planeArmor2048Tex[6].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[7].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[8].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[9].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[10].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[11].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[12].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[13].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[14].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[15].transform.GetComponent<Renderer>().material = NoneMat;
                        }
                        if (MatItemNumber == 7)
                        {
                            //planeArmor2048Tex[6].transform.GetComponent<Renderer>().material = MatArmorPart[itn1];
                            //planeArmor2048Tex[7].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[8].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[9].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[10].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[11].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[12].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[13].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[14].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[15].transform.GetComponent<Renderer>().material = NoneMat;
                        }
                        if (MatItemNumber == 8)
                        {
                            //planeArmor2048Tex[7].transform.GetComponent<Renderer>().material = MatArmorPart[itn1];
                            //planeArmor2048Tex[8].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[9].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[10].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[11].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[12].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[13].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[14].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[15].transform.GetComponent<Renderer>().material = NoneMat;
                        }
                        if (MatItemNumber == 9)
                        {
                            //planeArmor2048Tex[8].transform.GetComponent<Renderer>().material = MatArmorPart[itn1];
                            //planeArmor2048Tex[9].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[10].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[11].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[12].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[13].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[14].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[15].transform.GetComponent<Renderer>().material = NoneMat;
                        }
                        if (MatItemNumber == 10)
                        {
                            //planeArmor2048Tex[9].transform.GetComponent<Renderer>().material = MatArmorPart[itn1];
                            //planeArmor2048Tex[10].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[11].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[12].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[13].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[14].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[15].transform.GetComponent<Renderer>().material = NoneMat;
                        }
                        if (MatItemNumber == 11)
                        {
                            //planeArmor2048Tex[10].transform.GetComponent<Renderer>().material = MatArmorPart[itn1];
                            //planeArmor2048Tex[11].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[12].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[13].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[14].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[15].transform.GetComponent<Renderer>().material = NoneMat;
                        }
                        if (MatItemNumber == 12)
                        {
                            //planeArmor2048Tex[11].transform.GetComponent<Renderer>().material = MatArmorPart[itn1];
                            //planeArmor2048Tex[12].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[13].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[14].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[15].transform.GetComponent<Renderer>().material = NoneMat;
                        }
                        if (MatItemNumber == 13)
                        {
                            //planeArmor2048Tex[12].transform.GetComponent<Renderer>().material = MatArmorPart[itn1];
                            //planeArmor2048Tex[13].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[14].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[15].transform.GetComponent<Renderer>().material = NoneMat;
                        }
                        if (MatItemNumber == 14)
                        {
                            //planeArmor2048Tex[13].transform.GetComponent<Renderer>().material = MatArmorPart[itn1];
                            //planeArmor2048Tex[14].transform.GetComponent<Renderer>().material = NoneMat;
                            //planeArmor2048Tex[15].transform.GetComponent<Renderer>().material = NoneMat;
                        }
                        if (MatItemNumber == 15)
                        {
                            //planeArmor2048Tex[14].transform.GetComponent<Renderer>().material = MatArmorPart[itn1];
                            //planeArmor2048Tex[15].transform.GetComponent<Renderer>().material = NoneMat;
                        }
                        if (MatItemNumber == 16)
                        {
                            //planeArmor2048Tex[15].transform.GetComponent<Renderer>().material = MatArmorPart[itn1];
                        }


                    }
                }
            }
        }

    }
    /*
   // SAVE FUNCTION 

   void  MakePrefab (){

           //create a new folder to receive the New hierachy folder for the new character under new character folder 
       for(int foldHuman=0; foldHuman<50; foldHuman++){
           if(AssetDatabase.IsValidFolder("Assets/Character_Editor/NewCharacter/HumanMale"+ SavedPrefabNum +"")== true){SavedPrefabNum ++;}
           }

       int folder= AssetDatabase.CreateFolder("Assets/Character_Editor/NewCharacter", "HumanMale"+ SavedPrefabNum +"");

   //if pack armor button ON
       int folder1= AssetDatabase.CreateFolder("Assets/Character_Editor/NewCharacter/HumanMale"+ SavedPrefabNum +"", "Mesh");
       // create material for armor in folder
       int materialArmor= new Material (Shader.Find("Unlit/Texture"));
       AssetDatabase.CreateAsset(materialArmor, "Assets/Character_Editor/NewCharacter/HumanMale"+ SavedPrefabNum +"/HumanMale"+ SavedPrefabNum +"ArmorMat.mat");
   //


       AssetDatabase.Refresh();
       // get the quantity of equiped armor part by bool  true or false = AllArmorsPartQ
       for(int y= 0; y < ArmorpartEquip.Length; y++){
           if(ArmorpartEquip[y] == true){
           AllArmorsPartQ++;
           }
       }


       // if only 1 armor part are equiped on the character // no need to switch and replace uw but mesh and texture will be exported 
           if(AllArmorsPartQ == 1 ){
               TextureArmor = new Texture2D(512, 512); 
               for(int truc1= 0; truc1 < equipedArmor.Length; truc1++){
                   if(equipedArmor[truc1] != null){
                       TextureArmor = equipedArmor[truc1].GetComponentInChildren.<Renderer>().material.mainTexture as Texture2D;
                       armorsParts = new MeshFilter[3];	                                                                           // set the array Length for LOD inside the item
                       armorsParts = equipedArmor[truc1].GetComponentsInChildren.<MeshFilter>();                                       //get the meshfilter of LOD and store in array
                           for(int LODAr1= 0; LODAr1<armorsParts.Length; LODAr1++){		                                             //check for LOD inside the item the array is determined with 3 level 						
                               if(armorsParts[LODAr1] != null){ 
                                   armorsParts[LODAr1].GetComponent.<Renderer>().material = materialArmor;
                                   Mesh m1 = new Mesh ();																	   //create new mesh to save in new created folder
                                   m1 = armorsParts[LODAr1].mesh;																   //assigne the selected LOD Mesh with new UV"s to the new mesh to be exported
                                   AssetDatabase.CreateAsset(m1, "Assets/Character_Editor/NewCharacter/HumanMale"+ SavedPrefabNum +"/Mesh/"+armorsParts[LODAr1].name+"_New"+LODAr1+SavedPrefabNum+".asset");//exporte asset to new project folder	
                               }
                           }
                    }
               }
           }


       // if only 2 armor part are equiped on the character 	
       if(AllArmorsPartQ == 2 || AllArmorsPartQ == 3 || AllArmorsPartQ == 4){		
           TextureArmor = new Texture2D(1024, 1024); 																				//resize the texture for armor that will be exported in this case of only 2 equiped armor part 1024/1024
           for(int Ar2= 0; Ar2 < equipedArmor.Length; Ar2++){                                                                     // look for equiped armor part mesh filter for resizing UW
               if(equipedArmor[Ar2] != null){																						
                   itemNumber++;																									// increment the item (armor part selection)
                   TextureArmorPart[Ar2] = equipedArmor[Ar2].GetComponentInChildren.<Renderer>().material.mainTexture as Texture2D;// get the texture of this selected armor part
                   armorsParts = new MeshFilter[3];	                                                                           // set the array Length for LOD inside the item
                   armorsParts = equipedArmor[Ar2].GetComponentsInChildren.<MeshFilter>();                                       //get the meshfilter of LOD and store in array

                   for(int LODAr2= 0; LODAr2<armorsParts.Length; LODAr2++){		                                             //check for LOD inside the item the array is determined with 3 level 						
                       if(armorsParts[LODAr2] != null){ 									                                    // if there is a LOD inside item
                           armorsParts[LODAr2].GetComponent.<Renderer>().material = materialArmor;	                                           //assigne the new created material in new folder to the LOD to be exported
                           Vector2[] uvs = armorsParts[LODAr2].GetComponent.<MeshFilter>().mesh.uv;                    //get the uw of the selected LOD

                           for (int i = 0; i < uvs.Length; i++ ) {														
                               if(itemNumber == 1){
                                   uvs[i] = Vector2 (uvs[i].x /2  , uvs[i].y /2 + 0.5f);                                        // Offset all the UV"s for a first item
                               }
                               if(itemNumber == 2){
                                   uvs[i] = Vector2 (uvs[i].x /2 + 0.5f  , uvs[i].y /2 + 0.5f);                               // Offset all the UV"s for a second item
                               }
                               if(itemNumber == 3){
                                   uvs[i] = Vector2 (uvs[i].x /2   , uvs[i].y /2 );                               // Offset all the UV"s for a second item
                               }
                               if(itemNumber == 4){
                                   uvs[i] = Vector2 (uvs[i].x /2 + 0.5f , uvs[i].y /2 );                               // Offset all the UV"s for a second item
                               }						
                           }
                       armorsParts[LODAr2].mesh.uv = uvs;                                                             //assigne new UV"s to the selected LOD
                       Mesh m2 = new Mesh ();																	   //create new mesh to save in new created folder
                       m2 = armorsParts[LODAr2].mesh;																   //assigne the selected LOD Mesh with new UV"s to the new mesh to be exported
                       AssetDatabase.CreateAsset(m2, "Assets/Character_Editor/NewCharacter/HumanMale"+ SavedPrefabNum +"/Mesh/"+armorsParts[LODAr2].name+"_New"+LODAr2+SavedPrefabNum+".asset");//exporte asset to new project folder

                       }
                   }	
                   if(itemNumber == 1){																			//set the texture for the first item a the rigth place on a new texture to be exported
                   int pix= TextureArmorPart[Ar2].GetPixels32();
                   TextureArmor.SetPixels32(0,512,512,512,pix);			
                   TextureArmor.Apply();
                   }
                   if(itemNumber == 2){																			//set the texture for the first item a the rigth place on a new texture to be exported
                   //set the texture a the rigth place
                   int pix2= TextureArmorPart[Ar2].GetPixels32();
                   TextureArmor.SetPixels32(512,512,512,512,pix2);	
                   TextureArmor.Apply();		
                   }
                   if(itemNumber == 3){																			//set the texture for the first item a the rigth place on a new texture to be exported
                   //set the texture a the rigth place
                   int pix3= TextureArmorPart[Ar2].GetPixels32();
                   TextureArmor.SetPixels32(0,0,512,512,pix3);	
                   TextureArmor.Apply();		
                   }
                   if(itemNumber == 4){																			//set the texture for the first item a the rigth place on a new texture to be exported
                   //set the texture a the rigth place
                   int pix4= TextureArmorPart[Ar2].GetPixels32();
                   TextureArmor.SetPixels32(512,0,512,512,pix4);	
                   TextureArmor.Apply();		
                   }				
               }
           }
       }
    // if the number of item equiped on the character is more than 4 and up to 16
           if(AllArmorsPartQ > 4 ){
           TextureArmor = new Texture2D(2048, 2048);
           for(int Ar3= 0; Ar3 < equipedArmor.Length; Ar3++){                                                                     // look for equiped armor part mesh filter for resizing UW
               if(equipedArmor[Ar3] != null){																						
                   itemNumber++;																									// increment the item (armor part selection)
                   TextureArmorPart[Ar3] = equipedArmor[Ar3].GetComponentInChildren.<Renderer>().material.mainTexture as Texture2D;// get the texture of this selected armor part
                   armorsParts = new MeshFilter[3];	                                                                           // set the array Length for LOD inside the item
                   armorsParts = equipedArmor[Ar3].GetComponentsInChildren.<MeshFilter>();                                       //get the meshfilter of LOD and store in array

                   for(int LODAr3= 0; LODAr3<armorsParts.Length; LODAr3++){		                                             //check for LOD inside the item the array is determined with 3 level 						
                       if(armorsParts[LODAr3] != null){ 									                                    // if there is a LOD inside item
                           armorsParts[LODAr3].GetComponent.<Renderer>().material = materialArmor;	                                           //assigne the new created material in new folder to the LOD to be exported
                           Vector2[] uvs1 = armorsParts[LODAr3].GetComponent.<MeshFilter>().mesh.uv;                    //get the uw of the selected LOD

                           for (int uvi = 0; uvi < uvs1.Length; uvi++ ) {														
                               if(itemNumber == 1){
                                   uvs1 [uvi] = Vector2 (uvs1 [uvi].x /4  , uvs1 [uvi].y /4 + 0.75f);                                        // Offset all the UV"s for a first item
                                   }
                               if(itemNumber == 2){
                                   uvs1 [uvi] = Vector2 (uvs1 [uvi].x /4 + 0.25f  , uvs1 [uvi].y /4 + 0.75f);                               // Offset all the UV"s for a second item
                                   }
                               if(itemNumber == 3){
                                   uvs1 [uvi] = Vector2 (uvs1 [uvi].x /4   , uvs1 [uvi].y /4 +0.5f);                               // Offset all the UV"s for a second item
                                   }
                               if(itemNumber == 4){
                                   uvs1 [uvi] = Vector2 (uvs1 [uvi].x /4 + 0.25f , uvs1 [uvi].y /4+0.5f );                               // Offset all the UV"s for a second item
                                   }	
                               if(itemNumber == 5){
                                   uvs1 [uvi] = Vector2 (uvs1 [uvi].x /4 + 0.5f , uvs1 [uvi].y /4+0.75f );                               // Offset all the UV"s for a second item
                                   }
                               if(itemNumber == 6){
                                   uvs1 [uvi] = Vector2 (uvs1 [uvi].x /4 + 0.75f , uvs1 [uvi].y /4+0.75f );                               // Offset all the UV"s for a second item
                                   }								
                               if(itemNumber == 7){
                                   uvs1 [uvi] = Vector2 (uvs1 [uvi].x /4 + 0.5f , uvs1 [uvi].y /4+0.5f );                               // Offset all the UV"s for a second item
                                   }
                               if(itemNumber == 8){
                                   uvs1 [uvi] = Vector2 (uvs1 [uvi].x /4 + 0.75f , uvs1 [uvi].y /4+0.5f );                               // Offset all the UV"s for a second item
                                   }
                               if(itemNumber == 9){
                                   uvs1 [uvi] = Vector2 (uvs1 [uvi].x /4 , uvs1 [uvi].y /4+0.25f );                               // Offset all the UV"s for a second item
                                   }	
                               if(itemNumber == 10){
                                   uvs1 [uvi] = Vector2 (uvs1 [uvi].x /4+0.25f , uvs1 [uvi].y /4+0.25f );                               // Offset all the UV"s for a second item
                                   }	
                               if(itemNumber == 11){
                                   uvs1 [uvi] = Vector2 (uvs1 [uvi].x /4+0.5f , uvs1 [uvi].y /4+0.25f );                               // Offset all the UV"s for a second item
                                   }
                               if(itemNumber == 12){
                                   uvs1 [uvi] = Vector2 (uvs1 [uvi].x /4+0.75f , uvs1 [uvi].y /4+0.25f );                               // Offset all the UV"s for a second item
                                   }
                               if(itemNumber == 13){
                                   uvs1 [uvi] = Vector2 (uvs1 [uvi].x /4 , uvs1 [uvi].y /4 );                               // Offset all the UV"s for a second item
                                   }
                               if(itemNumber == 14){
                                   uvs1 [uvi] = Vector2 (uvs1 [uvi].x /4+0.25f , uvs1 [uvi].y /4 );                               // Offset all the UV"s for a second item
                                   }
                               if(itemNumber == 15){
                                   uvs1 [uvi] = Vector2 (uvs1 [uvi].x /4+0.5f , uvs1 [uvi].y /4 );                               // Offset all the UV"s for a second item
                                   }
                               if(itemNumber == 16){
                                   uvs1 [uvi] = Vector2 (uvs1 [uvi].x /4+0.75f , uvs1 [uvi].y /4 );                               // Offset all the UV"s for a second item
                                   }					
                               }

                       armorsParts[LODAr3].mesh.uv = uvs1;                                                             //assigne new UV"s to the selected LOD
                       Mesh m3 = new Mesh ();																	   //create new mesh to save in new created folder
                       m3 = armorsParts[LODAr3].mesh;																   //assigne the selected LOD Mesh with new UV"s to the new mesh to be exported
                       AssetDatabase.CreateAsset(m3, "Assets/Character_Editor/NewCharacter/HumanMale"+ SavedPrefabNum +"/Mesh/"+armorsParts[LODAr3].name+"_New"+LODAr3+SavedPrefabNum+".asset");//exporte asset to new project folder
                       }
                       }
                       if(itemNumber == 1){																			//set the texture for the first item a the rigth place on a new texture to be exported
                       int pixel= TextureArmorPart[Ar3].GetPixels32();
                       TextureArmor.SetPixels32(0,1536,512,512,pixel);			
                       TextureArmor.Apply();
                       }
                       if(itemNumber == 2){																			//set the texture for the first item a the rigth place on a new texture to be exported
                       //set the texture a the rigth place
                       int pixel2= TextureArmorPart[Ar3].GetPixels32();
                       TextureArmor.SetPixels32(512,1536,512,512,pixel2);	
                       TextureArmor.Apply();		
                       }
                       if(itemNumber == 3){																			//set the texture for the first item a the rigth place on a new texture to be exported
                       //set the texture a the rigth place
                       int pixel3= TextureArmorPart[Ar3].GetPixels32();
                       TextureArmor.SetPixels32(0,1024,512,512,pixel3);	
                       TextureArmor.Apply();		
                       }
                       if(itemNumber == 4){																			//set the texture for the first item a the rigth place on a new texture to be exported
                       //set the texture a the rigth place
                       int pixel4= TextureArmorPart[Ar3].GetPixels32();
                       TextureArmor.SetPixels32(512,1024,512,512,pixel4);	
                       TextureArmor.Apply();		
                       }
                       if(itemNumber == 5){																			//set the texture for the first item a the rigth place on a new texture to be exported
                       //set the texture a the rigth place
                       int pixel5= TextureArmorPart[Ar3].GetPixels32();
                       TextureArmor.SetPixels32(1024,1536,512,512,pixel5);	
                       TextureArmor.Apply();		
                       }
                       if(itemNumber == 6){																			//set the texture for the first item a the rigth place on a new texture to be exported
                       //set the texture a the rigth place
                       int pixel6= TextureArmorPart[Ar3].GetPixels32();
                       TextureArmor.SetPixels32(1536,1536,512,512,pixel6);	
                       TextureArmor.Apply();		
                       }
                       if(itemNumber == 7){																			//set the texture for the first item a the rigth place on a new texture to be exported
                       //set the texture a the rigth place
                       int pixel7= TextureArmorPart[Ar3].GetPixels32();
                       TextureArmor.SetPixels32(1024,1024,512,512,pixel7);	
                       TextureArmor.Apply();		
                       }
                       if(itemNumber == 8){																			//set the texture for the first item a the rigth place on a new texture to be exported
                       //set the texture a the rigth place
                       int pixel8= TextureArmorPart[Ar3].GetPixels32();
                       TextureArmor.SetPixels32(1536,1024,512,512,pixel8);	
                       TextureArmor.Apply();		
                       }
                       if(itemNumber == 9){																			//set the texture for the first item a the rigth place on a new texture to be exported
                       //set the texture a the rigth place
                       int pixel9= TextureArmorPart[Ar3].GetPixels32();
                       TextureArmor.SetPixels32(0,512,512,512,pixel9);	
                       TextureArmor.Apply();		
                       }
                       if(itemNumber == 10){																			//set the texture for the first item a the rigth place on a new texture to be exported
                       //set the texture a the rigth place
                       int pixel10= TextureArmorPart[Ar3].GetPixels32();
                       TextureArmor.SetPixels32(512,512,512,512,pixel10);	
                       TextureArmor.Apply();		
                       }
                       if(itemNumber == 11){																			//set the texture for the first item a the rigth place on a new texture to be exported
                       //set the texture a the rigth place
                       int pixel11= TextureArmorPart[Ar3].GetPixels32();
                       TextureArmor.SetPixels32(1024,512,512,512,pixel11);	
                       TextureArmor.Apply();		
                       }
                       if(itemNumber == 12){																			//set the texture for the first item a the rigth place on a new texture to be exported
                       //set the texture a the rigth place
                       int pixel12= TextureArmorPart[Ar3].GetPixels32();
                       TextureArmor.SetPixels32(1536,512,512,512,pixel12);	
                       TextureArmor.Apply();		
                       }
                       if(itemNumber == 13){																			//set the texture for the first item a the rigth place on a new texture to be exported
                       //set the texture a the rigth place
                       int pixel13= TextureArmorPart[Ar3].GetPixels32();
                       TextureArmor.SetPixels32(0,0,512,512,pixel13);	
                       TextureArmor.Apply();				
                       }
                       if(itemNumber == 14){																			//set the texture for the first item a the rigth place on a new texture to be exported
                       //set the texture a the rigth place
                       int pixel14= TextureArmorPart[Ar3].GetPixels32();
                       TextureArmor.SetPixels32(512,0,512,512,pixel14);	
                       TextureArmor.Apply();				
                       }
                       if(itemNumber == 15){																			//set the texture for the first item a the rigth place on a new texture to be exported
                       //set the texture a the rigth place
                       int pixel15= TextureArmorPart[Ar3].GetPixels32();
                       TextureArmor.SetPixels32(1024,0,512,512,pixel15);	
                       TextureArmor.Apply();				
                       }
                       if(itemNumber == 16){																			//set the texture for the first item a the rigth place on a new texture to be exported
                       //set the texture a the rigth place
                       int pixel16= TextureArmorPart[Ar3].GetPixels32();
                       TextureArmor.SetPixels32(1536,0,512,512,pixel16);	
                       TextureArmor.Apply();				
                       }
                   }
       }
       }

           //save the armor texture
       //create a new materials inside new character folder and assign it to the scene character to save the prefab

       int bytes1= TextureArmor.EncodeToPNG();
       int path1= EditorUtility.SaveFilePanel("Save Texture", "char","HumanMale"+ SavedPrefabNum +"Armor.png", "png");
       File.WriteAllBytes(path1,bytes1);
       AssetDatabase.Refresh();	
       materialArmor.mainTexture = AssetDatabase.LoadAssetAtPath("Assets/Character_Editor/NewCharacter/HumanMale"+ SavedPrefabNum +"/HumanMale"+ SavedPrefabNum +"Armor.png" ) as Texture2D;




       //save the character skin Texture
       int bytes= CombineAll.EncodeToPNG();
       int path= EditorUtility.SaveFilePanel("Save Texture", "char","HumanMale"+ SavedPrefabNum +"CharacterSkin.png", "png");
       File.WriteAllBytes(path,bytes);
       AssetDatabase.Refresh();
       int materialSkin= new Material (Shader.Find("Unlit/Texture"));
       AssetDatabase.CreateAsset(materialSkin, "Assets/Character_Editor/NewCharacter/HumanMale"+ SavedPrefabNum +"/HumanMale"+ SavedPrefabNum +"SkinMat.mat");	
       //assigne the texture to the new material
       materialSkin.mainTexture = AssetDatabase.LoadAssetAtPath("Assets/Character_Editor/NewCharacter/HumanMale"+ SavedPrefabNum +"/HumanMale"+ SavedPrefabNum +"CharacterSkin.png" ) as Texture2D;
       //assigne the new material to the character and LOD
       for(int rendN= 0; rendN<ModelRenderers.Length; rendN++){	
           ModelRenderers[rendN].material = materialSkin;
           }


       //Save the prefab				 			  				  				  				 
       Object prefab = EditorUtility.CreateEmptyPrefab ("Assets/Character_Editor/NewCharacter/HumanMale"+ SavedPrefabNum +"/HumanMale" + SavedPrefabNum + ".prefab");
       PrefabUtility.ReplacePrefab(Character, prefab, ReplacePrefabOptions.ConnectToPrefab);

       // quit the editor because the mesh you exporte have now new UW"S and quitting the editor play mode will remove the new UW"s 
       EditorApplication.isPlaying = false;
   }*/





    public void LoadPlayer(int NrScarsT, int NrEyeBrowT, int NrSkinFaceT, int NrColorNumberT, int NrColorPilosityT, int NrBeardT, int NrHairSkullT, int NrHeadAddT, int NrEyeT, int NrPantT, int NrTorsoT, int NrShoeT, int NrGloveT, int NrBeltT, int NrRobeLongT, int NrRobeShortT, int NrHairM, int NrHeadM, int NrJawM, int NrEyeM, int NrTorsoM, int NrTorsoAddM, int NrBeltM, int NrBeltAddM, int NrShoulderRM, int NrShoulderLM, int NrArmRM, int NrArmLM, int NrLegRM, int NrLegLM, int NrWeaponRM, int NrWeaponLM)
    {
        /////////////////

        
            
            // this will allow in the future update more character race
            CharacterRace = "HumanMale";

            //  _____ _____  _______ _   _ ___ ___ 
            // |_   _| __\ \/ /_   _| | | | _ \ __|
            //   | | | _| >  <  | | | |_| |   / _| 
            //   |_| |___/_/\_\ |_|  \___/|_|_\___|

            CombineAll = atlasBase;
            skinFaceS = atlasBase;
            ////LOADING CHARACTER TEXTURE////
            //At start this part of the script put textures of the character in aray liste of texture 2d  
            // the script search in project folder
            //       /!\ need to have a proper nomenclature folder and texture 


            // AtlasBase Texture SkinFace
            atlasBaseSearchSkinFace = Resources.LoadAll("Character_Editor/Textures/Character/HumanMale/HumanMale_Color/Color" + colorNumber);//.Cast.<Texture2D>().ToArray();
            //Debug.LogError(Resources.LoadAll("Character_Editor/Textures/Character/HumanMale/HumanMale_Color/Color" + colorNumber).Length);
            //AssetDatabase.FindAssets ("HumanMale_Color"+colorNumber+"_FaceSkin t:texture2D", ["Assets/Character_Editor/Textures/Character/HumanMale/HumanMale_Color/Color"+colorNumber+""]); //Search For Color0 Texture get all SkinFace
            atlasBaseSkinFace = new Texture2D[atlasBaseSearchSkinFace.Length];
            for (int a = 0; a < atlasBaseSearchSkinFace.Length; ++a)
            {
                atlasBaseSkinFace[a] = Resources.Load("Character_Editor/Textures/Character/HumanMale/HumanMale_Color/Color0/HumanMale_Color0_FaceSkin" + a + "") as Texture2D;
                //Debug.LogError(Resources.Load("Character_Editor/Textures/Character/HumanMale/HumanMale_Color/Color0/HumanMale_Color0_FaceSkin" + a ));
            }
            skinFaceQ = atlasBaseSkinFace.Length;

            // HeadAdd Texture in folder 
            headAddSearch = Resources.LoadAll("Character_Editor/Textures/CharacterOutfit/Head_add");
            //AssetDatabase.FindAssets ("headAdd t:texture2D", ["Character_Editor/Textures/CharacterOutfit/Head_add"]);								 //search texture by name for array Length
            headAdd = new Texture2D[headAddSearch.Length];                                                                                              //resize array
            for (int b = 0; b < headAddSearch.Length; ++b)
            {                                                                                              //fill with Texture2D
                headAdd[b] = Resources.Load("Character_Editor/Textures/CharacterOutfit/Head_add/headAdd" + b + "") as Texture2D;
            }
            headAddQ = headAdd.Length;

            // EyeBrow Texture in folder
            EyeBrowSearch = Resources.LoadAll("Character_Editor/Textures/Character/HumanMale/HumanMale_Eyebrow/Color0");
            //AssetDatabase.FindAssets ("EyeBrow t:texture2D", ["Character_Editor/Textures/Character/HumanMale/HumanMale_Eyebrow/Color0"]);								 //search texture by name for array Length
            EyeBrow = new Texture2D[EyeBrowSearch.Length];                                                                                              //resize array
            for (int c = 0; c < EyeBrowSearch.Length; ++c)
            {                                                                                              //fill with Texture2D
                EyeBrow[c] = Resources.Load("Character_Editor/Textures/Character/HumanMale/HumanMale_Eyebrow/Color0/EyeBrow" + c + "_Color0") as Texture2D;
            }
            EyeBrowQ = EyeBrow.Length;
            //texture Quantity  
            // Scars Texture in folder  
            ScarsSearch = Resources.LoadAll("Character_Editor/Textures/Character/HumanMale/HumanMale_Scars");
            //AssetDatabase.FindAssets ("Scars t:texture2D", ["Character_Editor/Textures/Character/HumanMale/HumanMale_Scars"]);								 //search texture by name for array Length
            Scars = new Texture2D[ScarsSearch.Length];                                                                                              //resize array
            for (int d = 0; d < ScarsSearch.Length; ++d)
            {                                                                                              //fill with Texture2D
                Scars[d] = Resources.Load("Character_Editor/Textures/Character/HumanMale/HumanMale_Scars/Scars" + d + "") as Texture2D;
            }
            ScarsQ = Scars.Length;

            // Beard Texture in folder  
            BeardSearch = Resources.LoadAll("Character_Editor/Textures/Character/HumanMale/HumanMale_Beard/Color0");
            //AssetDatabase.FindAssets ("Beard t:texture2D", ["Character_Editor/Textures/Character/HumanMale/HumanMale_Beard/Color0"]);								 //search texture by name for array Length
            Beard = new Texture2D[BeardSearch.Length];                                                                                              //resize array
            for (int e = 0; e < BeardSearch.Length; ++e)
            {                                                                                              //fill with Texture2D
                Beard[e] = Resources.Load("Character_Editor/Textures/Character/HumanMale/HumanMale_Beard/Color0/Beard" + e + "_Color0") as Texture2D;
            }
            BeardQ = Beard.Length;

            // HairSkull Texture in folder  
            HairSkullSearch = Resources.LoadAll("Character_Editor/Textures/Character/HumanMale/HumanMale_HairSkull/Color0");                  //search texture by name for array Length
            HairSkull = new Texture2D[HairSkullSearch.Length];                                                                                              //resize array
            for (int g = 0; g < HairSkullSearch.Length; ++g)
            {                                                                                              //fill with Texture2D
                HairSkull[g] = Resources.Load("Character_Editor/Textures/Character/HumanMale/HumanMale_HairSkull/Color0/HumanMale_HairSkull" + g + "_Color0") as Texture2D;
            }
            HairSkullQ = HairSkull.Length;

            // Eye Texture in folder 
            EyeSearch = Resources.LoadAll("Character_Editor/Textures/Character/HumanMale/HumanMale_Eye");                                 //search texture by name for array Length
            Eye = new Texture2D[EyeSearch.Length];                                                                                              //resize array
            for (int f = 0; f < EyeSearch.Length; ++f)
            {                                                                                              //fill with Texture2D
                Eye[f] = Resources.Load("Character_Editor/Textures/Character/HumanMale/HumanMale_Eye/Eye" + f + "") as Texture2D;
            }
            EyeQ = Eye.Length;

            // Pant Texture in folder 
            PantSearch = Resources.LoadAll("Character_Editor/Textures/CharacterOutfit/Pant");                         //search texture by name for array Length
            Pant = new Texture2D[PantSearch.Length];                                                                                            //resize array
            for (int i = 0; i < PantSearch.Length; ++i)
            {                                                                                              //fill with Texture2D
                Pant[i] = Resources.Load("Character_Editor/Textures/CharacterOutfit/Pant/Pant" + i + "") as Texture2D;
            }
            PantQ = Pant.Length;

            // Torso Texture in folder 
            TorsoSearch = Resources.LoadAll("Character_Editor/Textures/CharacterOutfit/Torso");                           //search texture by name for array Length
            Torso = new Texture2D[TorsoSearch.Length];                                                                                              //resize array
            for (int j = 0; j < TorsoSearch.Length; ++j)
            {                                                                                              //fill with Texture2D
                Torso[j] = Resources.Load("Character_Editor/Textures/CharacterOutfit/Torso/Torso" + j + "") as Texture2D;
            }
            TorsoQ = Torso.Length;

            // Shoe Texture in folder 
            ShoeSearch = Resources.LoadAll("Character_Editor/Textures/CharacterOutfit/Shoe");                     //search texture by name for array Length
            Shoe = new Texture2D[ShoeSearch.Length];                                                                                            //resize array
            for (int k = 0; k < ShoeSearch.Length; ++k)
            {                                                                                              //fill with Texture2D
                Shoe[k] = Resources.Load("Character_Editor/Textures/CharacterOutfit/Shoe/Shoe" + k + "") as Texture2D;
            }
            ShoeQ = Shoe.Length;                                                                                                                                     //texture Quantity 

            // Glove Texture in folder 
            GloveSearch = Resources.LoadAll("Character_Editor/Textures/CharacterOutfit/Glove");                       //search texture by name for array Length
            Glove = new Texture2D[GloveSearch.Length];                                                                                              //resize array
            for (int l = 0; l < GloveSearch.Length; ++l)
            {                                                                                              //fill with Texture2D
                Glove[l] = Resources.Load("Character_Editor/Textures/CharacterOutfit/Glove/Glove" + l + "") as Texture2D;
            }
            GloveQ = Glove.Length;

            // Belt Texture in folder 
            BeltSearch = Resources.LoadAll("Character_Editor/Textures/CharacterOutfit/Belt");                             //search texture by name for array Length
            Belt = new Texture2D[BeltSearch.Length];                                                                                            //resize array
            for (int m = 0; m < BeltSearch.Length; ++m)
            {                                                                                              //fill with Texture2D
                Belt[m] = Resources.Load("Character_Editor/Textures/CharacterOutfit/Belt/Belt" + m + "") as Texture2D;
            }
            BeltQ = Belt.Length;
            // Cloak Texture in folder 

            cloakSearch = Resources.LoadAll("Character_Editor/Textures/Armor/Cloak");                         //search texture by name for array Length
            cloakTex = new Texture2D[cloakSearch.Length];                                                                                           //resize array
            for (int cl = 0; cl < cloakSearch.Length; ++cl)
            {                                                                                              //fill with Texture2D
                cloakTex[cl] = Resources.Load("Character_Editor/Textures/Armor/Cloak/A_Cloak_" + cl + "") as Texture2D;
            }
            cloakQ = cloakTex.Length;
            for (int clo2 = 0; clo2 < cloak.Length; clo2++)
            {
                cloak[clo2].SetActive(false);
            }
            // robeLong Texture in folder 
            robeLongSearch = Resources.LoadAll("Character_Editor/Textures/CharacterOutfit/RobeLong");                             //search texture by name for array Length
            robeLongTex = new Texture2D[robeLongSearch.Length];                                                                                             //resize array
            for (int rl = 0; rl < robeLongSearch.Length; ++rl)
            {                                                                                              //fill with Texture2D
                robeLongTex[rl] = Resources.Load("Character_Editor/Textures/CharacterOutfit/RobeLong/RobeLong" + rl + "") as Texture2D;
            }
            robeLongQ = robeLongTex.Length;

            // robeShort Texture in folder 
            robeShortSearch = Resources.LoadAll("Character_Editor/Textures/CharacterOutfit/RobeShort");                           //search texture by name for array Length
            robeShortTex = new Texture2D[robeShortSearch.Length];                                                                                           //resize array
            for (int rsh = 0; rsh < robeShortSearch.Length; ++rsh)
            {                                                                                              //fill with Texture2D
                robeShortTex[rsh] = Resources.Load("Character_Editor/Textures/CharacterOutfit/RobeShort/RobeShort" + rsh + "") as Texture2D;
            }
            robeShortQ = robeShortTex.Length;


            // lunch the texturing loop in the start function 
            //the character model receive the default texture combined 
            // default are the 0 texture in here folder(most of them are empty transparent png, only the faceskin colorskin and the pant have pixels)                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       //texture Quantity 
            ColorSkinF();
            SkinFaceCombineF();

        //    _   ___ __  __  ___  ___ 
        //   /_\ | _ \  \/  |/ _ \| _ \
        //  / _ \|   / |\/| | (_) |   /
        // /_/ \_\_|_\_|  |_|\___/|_|_\


        //get biped part 
        //!\\ YOU SHOULD HAVE ONLY 1 BIPED WITH THE SAME NOMENCLATURE IN YOUR SCENE TO WORK PROPRELY

        headAnchor = findInChildrensByName("Bip01_Head");
        jawAnchor = findInChildrensByName("Bip01_Jaw");
        torsoAnchor = findInChildrensByName("Bip01_Spine3");
        beltAnchor = findInChildrensByName("Bip01_Pelvis");
        shoulderRAnchor = findInChildrensByName("Bip01_R_UpperArm");
        shoulderLAnchor = findInChildrensByName("Bip01_L_UpperArm");
        armRAnchor = findInChildrensByName("Bip01_R_Forearm");
        armLAnchor = findInChildrensByName("Bip01_L_Forearm");
        legRAnchor = findInChildrensByName("Bip01_R_Calf");
        legLAnchor = findInChildrensByName("Bip01_L_Calf");
        weaponRAnchor = findInChildrensByName("Bip01_R_Weapon");
        weaponLAnchor = findInChildrensByName("Bip01_L_Weapon");
        FXAnchor = findInChildrensByName("Bip01_Spine3");


        // Set the number of the selected item for each categorie
        headN = 0;
            hairModelN = 0;
            jawN = 0;
            eyeN = 0;
            torsoN = 0;
            torsoAddN = 0;
            beltN = 0;
            beltAddN = 0;
            shoulderRN = 0;
            shoulderLN = 0;
            armRN = 0;
            armLN = 0;
            legRN = 0;
            legLN = 0;
            FXN = 0;
            weaponRN = 0;
            weaponLN = 0;

            // Find All Armor Part GameObject

            AllArmor = FindObjectsOfType(typeof(GameObject)) as GameObject[];


            // Find Helm and store
            for (int obj = 0; obj < AllArmor.Length; obj++) { if (AllArmor[obj].name.Contains("A_Helm_" + CharacterRace)) { headQ++; } }
            headArmor = new GameObject[headQ];
            for (int p = 0; p < headQ; ++p)
            {
                headArmor[p] = GameObject.Find("A_Helm_" + CharacterRace + "_" + p + "");
            }

            // Find HairModel and store
            for (int hm = 0; hm < AllArmor.Length; hm++) { if (AllArmor[hm].name.Contains("A_HairModel_" + CharacterRace)) { hairModelQ++; } }
            hairModel = new GameObject[hairModelQ];
            for (int hmo = 0; hmo < hairModelQ; ++hmo)
            {
                hairModel[hmo] = GameObject.Find("A_HairModel_" + CharacterRace + "_" + hmo + "");
            }

            // Find JawModel and store
            for (int jw = 0; jw < AllArmor.Length; jw++) { if (AllArmor[jw].name.Contains("A_Jaw_" + CharacterRace)) { jawQ++; } }
            jaw = new GameObject[jawQ];
            for (int jwx = 0; jwx < jawQ; ++jwx)
            {
                jaw[jwx] = GameObject.Find("A_Jaw_" + CharacterRace + "_" + jwx + "");
            }

            // Find TorsoArmor and store
            for (int to = 0; to < AllArmor.Length; to++) { if (AllArmor[to].name.Contains("A_TorsoArmor_" + CharacterRace)) { torsoQ++; } }
            torsoArmor = new GameObject[torsoQ];
            for (int q = 0; q < torsoQ; ++q)
            {
                torsoArmor[q] = GameObject.Find("A_TorsoArmor_" + CharacterRace + "_" + q + "");
            }

            for (int be = 0; be < AllArmor.Length; be++) { if (AllArmor[be].name.Contains("A_Belt_" + CharacterRace)) { beltQ++; } }
            beltArmor = new GameObject[beltQ];
            for (int r = 0; r < beltQ; ++r)
            {
                beltArmor[r] = GameObject.Find("A_Belt_" + CharacterRace + "_" + r + "");
            }
            //			foreach( var Helm in AllArmor){
            //	Debug.Log("trouvées");
            for (int toa = 0; toa < AllArmor.Length; toa++) { if (AllArmor[toa].name.Contains("A_TorsoAdd_" + CharacterRace)) { torsoAddQ++; } }
            torsoAddArmor = new GameObject[torsoAddQ];
            for (int s = 0; s < torsoAddQ; ++s)
            {
                torsoAddArmor[s] = GameObject.Find("A_TorsoAdd_" + CharacterRace + "_" + s + "");
            }

            for (int eyx = 0; eyx < AllArmor.Length; eyx++) { if (AllArmor[eyx].name.Contains("A_EyeAdd_" + CharacterRace)) { eyeQ++; } }
            eyeAddArmor = new GameObject[eyeQ];
            for (int x = 0; x < eyeQ; ++x)
            {                                                                                              //fill with Texture2D
                eyeAddArmor[x] = GameObject.Find("A_EyeAdd_" + CharacterRace + "_" + x + "");
            }

            for (int shr = 0; shr < AllArmor.Length; shr++) { if (AllArmor[shr].name.Contains("A_Shoulder_R_" + CharacterRace)) { shoulderRQ++; } }
            shoulderRArmor = new GameObject[shoulderRQ];
            for (int o = 0; o < shoulderRQ; ++o)
            {                                                                                              //fill with Texture2D
                shoulderRArmor[o] = GameObject.Find("A_Shoulder_R_" + CharacterRace + "_" + o + "");
            }

            for (int shl = 0; shl < AllArmor.Length; shl++) { if (AllArmor[shl].name.Contains("A_Shoulder_L_" + CharacterRace)) { shoulderLQ++; } }
            shoulderLArmor = new GameObject[shoulderLQ];
            for (int n = 0; n < shoulderLQ; ++n)
            {                                                                                              //fill with Texture2D
                shoulderLArmor[n] = GameObject.Find("A_Shoulder_L_" + CharacterRace + "_" + n + "");
            }

            for (int arr = 0; arr < AllArmor.Length; arr++) { if (AllArmor[arr].name.Contains("A_Arm_R_" + CharacterRace)) { armRQ++; } }
            armRArmor = new GameObject[armRQ];
            for (int u = 0; u < armRQ; ++u)
            {                                                                                              //fill with Texture2D
                armRArmor[u] = GameObject.Find("A_Arm_R_" + CharacterRace + "_" + u + "");
            }

            for (int arl = 0; arl < AllArmor.Length; arl++) { if (AllArmor[arl].name.Contains("A_Arm_L_" + CharacterRace)) { armLQ++; } }
            armLArmor = new GameObject[armLQ];
            for (int t = 0; t < armLQ; ++t)
            {                                                                                              //fill with Texture2D
                armLArmor[t] = GameObject.Find("A_Arm_L_" + CharacterRace + "_" + t + "");
            }

            for (int lel = 0; lel < AllArmor.Length; lel++) { if (AllArmor[lel].name.Contains("A_Leg_L_" + CharacterRace)) { legLQ++; } }
            legLArmor = new GameObject[legLQ];
            for (int v = 0; v < legLQ; ++v)
            {                                                                                              //fill with Texture2D
                legLArmor[v] = GameObject.Find("A_Leg_L_" + CharacterRace + "_" + v + "");
            }

            for (int ler = 0; ler < AllArmor.Length; ler++) { if (AllArmor[ler].name.Contains("A_Leg_R_" + CharacterRace)) { legRQ++; } }
            legRArmor = new GameObject[legRQ];
            for (int w = 0; w < legRQ; ++w)
            {                                                                                              //fill with Texture2D
                legRArmor[w] = GameObject.Find("A_Leg_R_" + CharacterRace + "_" + w + "");
            }

            for (int wr = 0; wr < AllArmor.Length; wr++) { if (AllArmor[wr].name.Contains("W_R_")) { weaponRQ++; } }
            weaponRArmor = new GameObject[weaponRQ];
            for (int wir = 0; wir < weaponRQ; ++wir)
            {                                                                                              //fill with Texture2D
                weaponRArmor[wir] = GameObject.Find("W_R_" + wir + "");
            }

            for (int wl = 0; wl < AllArmor.Length; wl++) { if (AllArmor[wl].name.Contains("W_L_")) { weaponLQ++; } }
            weaponLArmor = new GameObject[weaponLQ];
            for (int wil = 0; wil < weaponLQ; ++wil)
            {                                                                                              //fill with Texture2D
                weaponLArmor[wil] = GameObject.Find("W_L_" + wil + "");
            }

            for (int bea = 0; bea < AllArmor.Length; bea++) { if (AllArmor[bea].name.Contains("A_BeltAdd_" + CharacterRace)) { beltAddQ++; } }
            beltAddArmor = new GameObject[beltAddQ];
            for (int ra = 0; ra < beltAddQ; ++ra)
            {
                beltAddArmor[ra] = GameObject.Find("A_BeltAdd_" + CharacterRace + "_" + ra + "");
            }

            // Find FxTorso and store
            for (int fxt = 0; fxt < AllArmor.Length; fxt++) { if (AllArmor[fxt].name.Contains("A_FXTorso_")) { FXQ++; } }
            FXArmor = new GameObject[FXQ];
            for (int fxu = 0; fxu < FXQ; ++fxu)
            {
                FXArmor[fxu] = GameObject.Find("A_FXTorso_" + fxu + "");
            }

            // how much armor by categorie
            // Set the quantity number of item for each category by the array Length
            headQ = headArmor.Length;
            hairModelQ = hairModel.Length;
            jawQ = jaw.Length;
            eyeQ = eyeAddArmor.Length;
            torsoQ = torsoArmor.Length;
            torsoAddQ = torsoAddArmor.Length;
            beltQ = beltArmor.Length;
            beltAddQ = beltAddArmor.Length;
            shoulderRQ = shoulderRArmor.Length;
            shoulderLQ = shoulderLArmor.Length;
            armRQ = armRArmor.Length;
            armLQ = armLArmor.Length;
            legRQ = legRArmor.Length;
            legLQ = legLArmor.Length;
            weaponRQ = weaponRArmor.Length;
            weaponLQ = weaponLArmor.Length;
            FXQ = FXArmor.Length;

            // Set a selected item for each category(the selected item is the one who will take place on the model it is the displayed model)
            headArmorS = headArmor[headN];
            hairModelS = hairModel[hairModelN];
            jawS = jaw[jawN];
            eyeS = eyeAddArmor[eyeN];
            torsoArmorS = torsoArmor[torsoN];
            torsoAddArmorS = torsoAddArmor[torsoAddN];
            beltArmorS = beltArmor[beltN];
            beltAddArmorS = beltAddArmor[beltAddN];
            shoulderRArmorS = shoulderRArmor[shoulderRN];
            shoulderLArmorS = shoulderLArmor[shoulderLN];
            armRArmorS = armRArmor[armRN];
            armLArmorS = armLArmor[armLN];
            legRArmorS = legRArmor[legRN];
            legLArmorS = legLArmor[legLN];
            weaponRArmorS = weaponRArmor[weaponRN];
            weaponLArmorS = weaponLArmor[weaponLN];
            FXArmorS = FXArmor[FXN];

        

        /////////////////
        ScarsN = NrScarsT;
        EyeBrowN = NrEyeBrowT;
        skinFaceN = NrSkinFaceT;
        colorNumber = NrColorNumberT;
        colorPilosityNumber = NrColorPilosityT;
        BeardN = NrBeardT;
        HairSkullN = NrHairSkullT;
        headAddN = NrHeadAddT;
        EyeN = NrEyeT;
        PantN = NrPantT;
        TorsoN = NrTorsoT;
        ShoeN = NrShoeT;
        GloveN = NrGloveT;
        BeltN = NrBeltT;
        robeLongN = NrRobeLongT;
        if (robeLongN >= 1) { robeLongB = true; RobeLongOn(); }
        if (robeLongN <= 0) { robeLongN = 0; robeLongB = false; RobeLongOff(); }
        robeShortN = NrRobeShortT;
        if (robeShortN >= 1) { robeShortB = true; RobeShortOn(); }
        if (robeShortN <= 0) { robeShortN = 0; robeShortB = false; RobeShortOff(); }


        //Random armor mesh
        // set the number of the selected item to be placed on the model

        hairModelN = NrHairM;
        headN = NrHeadM;
        jawN = NrJawM;
        eyeN = NrEyeM;
        torsoN = NrTorsoM;
        torsoAddN = NrTorsoAddM;
        beltN = NrBeltM;
        beltAddN = NrBeltAddM;
        shoulderRN = NrShoulderRM;
        shoulderLN = NrShoulderLM;
        armRN = NrArmRM;
        armLN = NrArmLM;
        legRN = NrLegRM;
        legLN = NrLegLM;
        weaponRN = NrWeaponRM;
        weaponLN = NrWeaponLM;
        //FXN = Random.Range(-5,FXQ); // enable it if you want FxTorso be part of the random


        //lunch pilosity function to remap the color on the mesh hair and the texture color
        PilosityColor();

        // set all the bool  to false (no item is equiped)
        ArmorpartEquip[0] = false;
        ArmorpartEquip[1] = false;
        ArmorpartEquip[2] = false;
        ArmorpartEquip[3] = false;
        ArmorpartEquip[4] = false;
        ArmorpartEquip[5] = false;
        ArmorpartEquip[6] = false;
        ArmorpartEquip[7] = false;
        ArmorpartEquip[8] = false;
        ArmorpartEquip[9] = false;
        ArmorpartEquip[10] = false;
        ArmorpartEquip[11] = false;
        ArmorpartEquip[12] = false;
        ArmorpartEquip[13] = false;
        ArmorpartEquip[14] = false;

        //lunch texture feedback armor function 
        FBTexArmor();

        // IF ITEM SELECTED IS DIFFERENT FROM 0 LUNCH EQUIP FUNCTION		OTHERWISE//set bool  of equiped item to false, remove item from model equiped armor array, lunch feedback texture armor function,remove armor part from the model
        if (headN > 0) { HeadEquip(); ArmorpartEquip[0] = true; } else { ArmorpartEquip[0] = false; equipedArmor[0] = null; FBTexArmor(); headArmorS.transform.position = anchorHead.position; headArmorS.transform.parent = anchorHead; }
        if (hairModelN > 0) { hairModelEquip(); ArmorpartEquip[1] = true; } else { ArmorpartEquip[1] = false; equipedArmor[1] = null; FBTexArmor(); hairModelS.transform.position = anchorHair.position; hairModelS.transform.parent = anchorHead; }
        if (jawN > 0) { JawEquip(); ArmorpartEquip[2] = true; } else { ArmorpartEquip[2] = false; equipedArmor[2] = null; FBTexArmor(); jawS.transform.position = anchorJaw.position; jawS.transform.parent = anchorJaw; }
        if (torsoN > 0) { TorsoEquip(); ArmorpartEquip[3] = true; } else { ArmorpartEquip[3] = false; equipedArmor[3] = null; FBTexArmor(); torsoArmorS.transform.position = anchorTorso.position; torsoArmorS.transform.parent = anchorTorso; }
        if (torsoAddN > 0) { TorsoAddEquip(); ArmorpartEquip[4] = true; } else { ArmorpartEquip[4] = false; equipedArmor[4] = null; FBTexArmor(); torsoAddArmorS.transform.position = anchorTorso.position; torsoAddArmorS.transform.parent = anchorTorso; }
        if (beltN > 0) { BeltEquip(); ArmorpartEquip[5] = true; } else { ArmorpartEquip[5] = false; equipedArmor[5] = null; FBTexArmor(); beltArmorS.transform.position = anchorBelt.position; beltArmorS.transform.parent = anchorBelt; }
        if (beltAddN > 0) { BeltAddEquip(); ArmorpartEquip[6] = true; } else { ArmorpartEquip[6] = false; equipedArmor[6] = null; FBTexArmor(); beltAddArmorS.transform.position = anchorBelt.position; beltAddArmorS.transform.parent = anchorBelt; }
        if (armLN > 0) { ArmLEquip(); ArmorpartEquip[10] = true; } else { ArmorpartEquip[10] = false; equipedArmor[10] = null; FBTexArmor(); armLArmorS.transform.position = anchorArmL.position; armLArmorS.transform.parent = anchorArmL; }
        if (armRN > 0) { ArmREquip(); ArmorpartEquip[9] = true; } else { ArmorpartEquip[9] = false; equipedArmor[9] = null; FBTexArmor(); armRArmorS.transform.position = anchorArmR.position; armRArmorS.transform.parent = anchorArmR; }
        if (legRN > 0) { LegREquip(); ArmorpartEquip[11] = true; } else { ArmorpartEquip[11] = false; equipedArmor[11] = null; FBTexArmor(); legRArmorS.transform.position = anchorLegR.position; legRArmorS.transform.parent = anchorLegR; }
        if (legLN > 0) { LegLEquip(); ArmorpartEquip[12] = true; } else { ArmorpartEquip[12] = false; equipedArmor[12] = null; FBTexArmor(); legLArmorS.transform.position = anchorLegL.position; legLArmorS.transform.parent = anchorLegL; }
        if (shoulderRN > 0) { ShoulderREquip(); ArmorpartEquip[7] = true; } else { ArmorpartEquip[7] = false; equipedArmor[7] = null; FBTexArmor(); shoulderRArmorS.transform.position = anchorShoulderR.position; shoulderRArmorS.transform.parent = anchorShoulderR; }
        if (shoulderLN > 0) { ShoulderLEquip(); ArmorpartEquip[8] = true; } else { ArmorpartEquip[8] = false; equipedArmor[8] = null; FBTexArmor(); shoulderLArmorS.transform.position = anchorShoulderL.position; shoulderLArmorS.transform.parent = anchorShoulderL; }
        if (weaponLN > 0) { WeaponLEquip(); ArmorpartEquip[14] = true; } else { ArmorpartEquip[14] = false; equipedArmor[14] = null; FBTexArmor(); weaponLArmorS.transform.position = anchorWeaponL.position; weaponLArmorS.transform.parent = anchorWeaponL; }
        if (weaponRN > 0) { WeaponREquip(); ArmorpartEquip[13] = true; } else { ArmorpartEquip[13] = false; equipedArmor[13] = null; FBTexArmor(); weaponRArmorS.transform.position = anchorWeaponR.position; weaponRArmorS.transform.parent = anchorWeaponR; }

        //if(FXN>=0){FXEquip();} else {FXArmorS.transform.position = anchorFX.position;FXArmorS.transform.parent = anchorFX;} if you want activate the fx in the randomness
        if (eyeN > 0) { EyeEquip(); } else { eyeS.transform.position = anchorEye.position; eyeS.transform.parent = anchorEye; }

        // lunch feedback texture armor
        FBTexArmor();
        Destroy(gameObject);
    }









}