using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitForPlayers : Photon.PunBehaviour {
    public int minPlayers = 2;
    public bool listen = false;
    public GameObject SelectPlayersLobby;
    public GameObject joinPanel;
    public GameObject[] Team1Players;
    public GameObject[] Team2Players;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (listen)
        {
            if (PhotonNetwork.playerList.Length == minPlayers)
            {
                int team1 = 0;
                int team2 = 0;
                joinPanel.SetActive(true);
              //  listen = false;
                //joinPanel.active = true;
                for(int i = 0; i< PhotonNetwork.playerList.Length; i++)
                {
                    if(PhotonNetwork.playerList[i].GetTeam() == PunTeams.Team.blue)
                    {
                        Team1Players[team1].GetComponent<Text>().text = PhotonNetwork.playerList[i].NickName;
                        team1++;
                    }
                        
                }
                for (int i = 0; i < PhotonNetwork.playerList.Length; i++)
                {
                    if (PhotonNetwork.playerList[i].GetTeam() == PunTeams.Team.red)
                    {
                        Team2Players[team2].GetComponent<Text>().text = PhotonNetwork.playerList[i].NickName;
                        team2++;
                    }
                        
                }
                LoadArena();
            }
            
        }
	}
    void LoadArena()
    {
        if (!PhotonNetwork.isMasterClient)
        {
            Debug.LogError("PhotonNetwork : Trying to Load a level but we are not the master Client");
        }
        Debug.Log("PhotonNetwork : Loading Level : " + PhotonNetwork.room.PlayerCount);
        //PhotonNetwork.LoadLevel("Level1");
    }
    public void active()
    {
        listen = !listen;
    }
}
