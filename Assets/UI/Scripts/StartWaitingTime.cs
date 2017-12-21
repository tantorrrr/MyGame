using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartWaitingTime : MonoBehaviour {
    public GameObject timer;
    private int time = 0;

    public string waitText = "Waiting...";
    public GameObject JoinText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void StartTime()
    {
        if (timer.activeSelf)
        {
            timer.GetComponent<Text>().text = "0";
            JoinText.GetComponent<Text>().text = "Join";
            timer.SetActive(false);
            CancelInvoke("addSec");
            time = 0;
        }
        else
        {
            JoinText.GetComponent<Text>().text = waitText;
            timer.SetActive(true);
            InvokeRepeating("addSec", 1f, 1f);
        }
        

    }
    private void addSec()
    {
        time++;
        timer.GetComponent<Text>().text = "" + time;
    }
}
