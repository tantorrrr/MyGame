using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameJoining : Photon.PunBehaviour {
    public int minPlayers = 0;
    public int joinedPlayers = 0;
    public GameObject[] pictures;
    public GameObject button;
    public GameObject SelectPlayersLobby;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    [PunRPC]
    void JoinGame()
    {
        pictures[joinedPlayers].GetComponent<Image>().color = Color.blue;
        joinedPlayers++;
        if (joinedPlayers == minPlayers)
        {
            
            SelectPlayersLobby.active = true;
            Destroy(gameObject);
        }
        
    }
    public void sendJoin()
    {
        
        this.photonView.RPC("JoinGame", PhotonTargets.All);
        button.active = false;
    }
    

}
