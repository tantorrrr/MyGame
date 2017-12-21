using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class ObjectSizeInPercents : MonoBehaviour {
    public float SizeInPercentX;
    public float SizeInPercentY;
    public float PositionInPercentX;
    public float PositionInPercentY;
    //public float PositionInPercentY;
    public RectTransform parentRectTransform;
    public bool setScreenSize;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.LogError(GetComponent<RectTransform>().anchoredPosition.y);
        if(setScreenSize)
        {
            GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
            return;
        }
        float x = parentRectTransform.sizeDelta.x * (SizeInPercentX / 100);
        float y = parentRectTransform.sizeDelta.y * (SizeInPercentY / 100);
        this.GetComponent<RectTransform>().sizeDelta = new Vector2(x, y);
        ///Position
        ///

        float posx = (GetComponent<RectTransform>().sizeDelta.x / 2) + ( (parentRectTransform.sizeDelta.x / 100) * PositionInPercentX);
        //GetComponent<RectTransform>().anchoredPosition = new Vector2(posx, GetComponent<RectTransform>().anchoredPosition.y);
        float posy =( -parentRectTransform.sizeDelta.y / 100 ) * PositionInPercentY;
        GetComponent<RectTransform>().anchoredPosition = new Vector2(posx, posy);
    }
}
