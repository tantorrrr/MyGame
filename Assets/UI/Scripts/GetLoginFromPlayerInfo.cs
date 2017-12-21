using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetLoginFromPlayerInfo : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
       GameObject nick = GameObject.Find("PlayerInfo");
        if (nick != null)
        {
           // PlayerPrefs.SetString("username", split[5].Trim());
            GetComponent<UnityEngine.UI.Text>().text = PlayerPrefs.GetString("username");
            PhotonNetwork.playerName = PlayerPrefs.GetString("username");
        }
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
