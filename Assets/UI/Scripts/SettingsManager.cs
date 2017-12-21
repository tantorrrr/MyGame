using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SettingsManager : MonoBehaviour {
    
    public Dropdown screenTypeDropdown;
    public Dropdown resolutionDropdown;
    public Dropdown textureQualityDropdown;
    public Dropdown antialiasingDropdown;
    public Dropdown vSyncDropdown;
    public Slider musicVolumeSlider;
    public Resolution[] resolutions;
    public GameSettings gameSettings;
    public AudioSource audioSource;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnEnable()
    {
        gameSettings = new GameSettings();
        resolutions = Screen.resolutions;
        //////
        screenTypeDropdown.onValueChanged.AddListener(delegate { onFullScreenChange(); });
        resolutionDropdown.onValueChanged.AddListener(delegate { onResolutionChange(); });
        textureQualityDropdown.onValueChanged.AddListener(delegate { onTextureQualityChange(); });
        antialiasingDropdown.onValueChanged.AddListener(delegate { onAntialiasingChange(); });
        vSyncDropdown.onValueChanged.AddListener(delegate { onVSyncChange(); });
        //////

        foreach (Resolution resolution in resolutions)
        {
            resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }
       // resolutionDropdown.options = resolution.ToString();

    }
    private void onFullScreenChange()
    {
        if (screenTypeDropdown.value == 0)
            gameSettings.screenType = Screen.fullScreen = false;
        else
            gameSettings.screenType = Screen.fullScreen = true;
    }
    private void onResolutionChange()
    {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
    }
    private void onTextureQualityChange()
    {
        QualitySettings.masterTextureLimit= gameSettings.textureQuality = textureQualityDropdown.value;
    }
    private void onAntialiasingChange()
    {
        QualitySettings.antiAliasing = gameSettings.antialiasing= (int)Mathf.Pow(2f, antialiasingDropdown.value);
    }
    private void onVSyncChange()
    {
        QualitySettings.vSyncCount = gameSettings.vSync = vSyncDropdown.value;
    }
    private void onMusicChange()
    {
        audioSource.volume = gameSettings.musicVolume = musicVolumeSlider.value;
    }
    public void saveSettings()
    {
        string jsonData = JsonUtility.ToJson(gameSettings,true);
        File.WriteAllText(Application.persistentDataPath + "/gamesettings.json", jsonData);
        Debug.Log("Save");
    }
    void loadSettings()
    {
        gameSettings = JsonUtility.FromJson<GameSettings>(Application.persistentDataPath + "/gamesettings.json");
    }
}
