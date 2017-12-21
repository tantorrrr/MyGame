using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendInfo : MonoBehaviour {
    public string Login;
    public string Password;
    public int playerID;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    public void setLogin(string login)
    {
        Login = login;
    }
    public string getLogin()
    {
        return Login;
    }
    
}
