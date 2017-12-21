using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
public class SavePasswordAndLogin : MonoBehaviour {
    rememberPlayerLogin rpl_saved;
    rememberPlayerLogin rpl_loaded;
    public InputField login;
    public InputField password;
    public Toggle saveData;
	// Use this for initialization
	void Start () {
        LoadData();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Save()
    {
        if (saveData.isOn)
        {
            rpl_saved = new rememberPlayerLogin();
            rpl_saved.playerLogin = login.text;
            rpl_saved.playerPassword = password.text;
            rpl_saved.remember = saveData.isOn;
            string json = JsonUtility.ToJson(rpl_saved);
            //back
            //myObject = JsonUtility.FromJson<MyClass>(json);

            if (!Directory.Exists("Assets/Game mechanism/Resources/Saves"))
                Directory.CreateDirectory("Assets/Game mechanism/Resources/Saves");
            if (!File.Exists("Assets/Game mechanism/Resources/Saves/PlayerLoginData.txt"))
                File.Create("Assets/Game mechanism/Resources/Saves/PlayerLoginData.txt");
            string path = "Assets/Game mechanism/Resources/Saves/PlayerLoginData.txt";


            //Write some text to the test.txt file
            // StreamWriter writer = new StreamWriter(path, true);
            File.WriteAllText(path, json, System.Text.Encoding.UTF8);
            //writer.(json);
            // writer.Close();
        }
    }

    public void LoadData()
    {
        if (!Directory.Exists("Assets/Game mechanism/Resources/Saves"))
            Directory.CreateDirectory("Assets/Game mechanism/Resources/Saves");
        if (!File.Exists("Assets/Game mechanism/Resources/Saves/PlayerLoginData.txt"))
            File.Create("Assets/Game mechanism/Resources/Saves/PlayerLoginData.txt");
        string path = "Assets/Game mechanism/Resources/Saves/PlayerLoginData.txt";
        rpl_loaded = new rememberPlayerLogin();
        rpl_loaded = JsonUtility.FromJson<rememberPlayerLogin>(File.ReadAllText(path));
        Debug.LogError(rpl_loaded.remember);
        if (rpl_loaded.remember)
        {
            login.text = rpl_loaded.playerLogin;
            password.text = rpl_loaded.playerPassword;
            saveData.isOn = rpl_loaded.remember;
        }
    }
}
