using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
#if (UNITY_STANDALONE || UNITY_EDITOR_WIN || UNITY_EDITOR_OSX ) && (!UNITY_WEBPLAYER && !UNITY_WEBGL && !UNITY_ANDROID && !UNITY_IOS)
using System.Net.NetworkInformation;
#endif
using System.Net;
using System.Collections.Generic;
using System;
[Serializable]
public class LogingSystem : MonoBehaviour {
    public Text loginField;
    public InputField passwordField;
    private string info;
    public int playerID;
    [SerializeField] public string LogingURL;
    [SerializeField] public string securePassword;
    
    // Use this for initialization
    void Start()
    {
#if (UNITY_STANDALONE || UNITY_EDITOR_WIN || UNITY_EDITOR_OSX) && !UNITY_WEBPLAYER
        ShowNetworkInterfaces();

#endif

    }

    
    public void ShowNetworkInterfaces()
    {
#if (UNITY_STANDALONE || UNITY_EDITOR_WIN || UNITY_EDITOR_OSX) && (!UNITY_WEBPLAYER && !UNITY_WEBGL && !UNITY_IOS && !UNITY_ANDROID)

        IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
        NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

        foreach (NetworkInterface adapter in nics)
        {
            PhysicalAddress address = adapter.GetPhysicalAddress();
            byte[] bytes = address.GetAddressBytes();
            string mac = null;
            for (int i = 0; i < bytes.Length; i++)
            {
                mac = string.Concat(mac + (string.Format("{0}", bytes[i].ToString("X2"))));
                if (i != bytes.Length - 1)
                {
                    mac = string.Concat(mac + "-");
                }
            }
            info += mac;

        }
#endif

    }
    public void findPlayer()
        {
        StartCoroutine(playerFinder());
        //Invoke("CreatePlayer", 0.2f);

    }
    IEnumerator playerFinder()
    {


#if (UNITY_STANDALONE || UNITY_EDITOR_WIN || UNITY_EDITOR_OSX) && (!UNITY_WEBPLAYER && !UNITY_WEBGL && !UNITY_ANDROID && !UNITY_IOS)

        string sends = LogingURL + "?" + "login=" + loginField.text + "&password=" + passwordField.text + "&secure=" + securePassword;
        Debug.LogError(sends);
#endif
#if UNITY_WEBGL || UNITY_WEBPLAYER || UNITY_ANDROID || UNITY_IOS

			string sends = RegisterUrl + "?" + "firstname=" + firstName.text.Trim () + "&lastname=" + lastName.text.Trim () + "&age=" + Age.text.Trim () + "&country=" + Country.text.Trim () + "&username=" + userName.text.Trim () + "&email=" + Email.text.Trim () + "&password=" + Password.text.Trim () + "&mac=1&secure=" + securePassword.Trim ();

#endif
        WWW php_query = new WWW(sends);
        yield return php_query;
        if (php_query.text.Trim() == "1")
        {
            Debug.LogError(php_query.text);
            //GetLoginCanvas.ToggleCanvas("login");
        }
        else
        {
            // WarningMSG.text = php_query.text;
            Debug.LogError(php_query.text);
        }





    }
}
