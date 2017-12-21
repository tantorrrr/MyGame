using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelAnimation : MonoBehaviour {
    public ObjectSizeInPercents osip;
    public float ShowPosX;
    public float HidePosX;
    public float Speed;
    public float frequency;
    public bool hide;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void AnimatePanel()
    {
        CancelInvoke("ChangePos");
        hide = !hide;
        InvokeRepeating("ChangePos", 0.0f, frequency);
        
    }
    private void ChangePos()
    {
        if (ShowPosX < HidePosX) { 
            if (!hide && ShowPosX < osip.PositionInPercentX)
            {
                osip.PositionInPercentX -= Speed * Time.deltaTime;
            }
            else if (hide && HidePosX > osip.PositionInPercentX)
            {
                osip.PositionInPercentX += Speed * Time.deltaTime;
            } }
            else { 
        if (!hide && ShowPosX > osip.PositionInPercentX)
        {
            osip.PositionInPercentX += Speed * Time.deltaTime;
        }
        else if (hide && HidePosX < osip.PositionInPercentX)
        {
            osip.PositionInPercentX -= Speed * Time.deltaTime;
        } }
    }
    

}
