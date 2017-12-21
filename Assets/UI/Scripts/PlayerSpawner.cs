using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : Photon.PunBehaviour {
    [Tooltip("The prefab to use for representing the player")]
    public GameObject playerPrefab;
    public Transform spawnPlace;
    public bool local;
    // Use this for initialization
    void Start () {
        if (playerPrefab == null)
        {
            Debug.LogError("<Color=Red><a>Missing</a></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'", this);
        }
        else
        {
            if (!local)
            {
                Debug.Log("We are Instantiating LocalPlayer from " + Application.loadedLevelName);
                // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
                PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
            }
            else
            {
                GameObject.Instantiate(playerPrefab, spawnPlace.position, spawnPlace.rotation);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
