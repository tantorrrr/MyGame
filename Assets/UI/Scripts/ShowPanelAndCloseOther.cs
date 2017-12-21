using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPanelAndCloseOther : MonoBehaviour {
    public GameObject[] AllPanelsToClose;
    public GameObject PanelToOpen;
   // public GameObject LastOpen;
   // public bool setLastOpen = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OpenPanel()
    {
        for(int i = 0; i< AllPanelsToClose.Length; i++)
        {
            AllPanelsToClose[i].SetActive(false);
        }
        PanelToOpen.SetActive(true);
        /*
        if (LastOpen != null)
            LastOpen.SetActive(true);
        else
        {
            PanelToOpen.SetActive(true);
            PanelToOpen.GetComponent<ShowPanelAndCloseOther>().LastOpen = gameObject;
        }*/
            
    }

}
