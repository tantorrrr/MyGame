using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePanel : MonoBehaviour {
    GameObject currPanel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void changePanel(GameObject panel)
    {
        if (currPanel)
        {
            currPanel.GetComponent<PanelAnimation>().AnimatePanel();
            //currPanel.SetActive(false);
            panel.GetComponent<PanelAnimation>().AnimatePanel();
            //panel.SetActive(true);
            currPanel = panel;

        }
        else
        {
            panel.GetComponent<PanelAnimation>().AnimatePanel();
            //panel.SetActive(true);
            currPanel = panel;
        }
    }
}
