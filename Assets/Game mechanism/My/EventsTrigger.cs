using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsTrigger : MonoBehaviour {

    public UnityEvent[] eventsArray;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    public void startEvent(int eventNumber){
        if (eventsArray[eventNumber] != null)
        {
            eventsArray[eventNumber].Invoke();
        }

    }
}
