using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SyncTime : Photon.PunBehaviour {
    public int timeToStart = 20;
    public GameObject timeClock;
	// Use this for initialization
	void Start () {
        if (!PhotonNetwork.isMasterClient)
        {
            Debug.LogError("PhotonNetwork : Trying but we are not the master Client");
        }
        InvokeRepeating("setTime", 1f, 1f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void setTime()
    {
        timeToStart--;
        this.photonView.RPC("SetTime", PhotonTargets.All, timeToStart);

    }

    //sync all players time to start
    [PunRPC]
    void SetTime(int time)
    {
        if(time>0)
        timeClock.GetComponent<Text>().text = time + "";
        else if (time == 0)
        {
            if (!PhotonNetwork.isMasterClient)
            {
                Debug.LogError("PhotonNetwork : Trying to Load a level but we are not the master Client");
            }
            Debug.Log("PhotonNetwork : Loading Level : " + PhotonNetwork.room.PlayerCount);
            PhotonNetwork.LoadLevel("Level1");
        }
    }
}
