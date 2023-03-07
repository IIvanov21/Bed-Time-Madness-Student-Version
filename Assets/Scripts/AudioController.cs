using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider master, music, ambient, player;
    [SerializeField] TMP_Text masterText, musicText, ambientText, playerText;
    // Start is called before the first frame update
    void Start()
    {
        //Connecting our custom functions to the OnValueChanged Unity event for each slider
        master.onValueChanged.AddListener(delegate { SetMasterSound(); });
        music.onValueChanged.AddListener(delegate { SetMusicSound(); });
        ambient.onValueChanged.AddListener(delegate { SetAmbientSound(); });
        player.onValueChanged.AddListener(delegate { SetPlayerSound(); });

        //Set the stored sound settings
        SetStartingValues();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMasterSound()
    {
        audioMixer.SetFloat("MasterVolume", master.value);//Connects the slider value to the audio mixer
        float percentage = (((-80.0f - master.value)) / -80.0f) * 100.0f;//Convert dB to percentage
        masterText.text = ((int)percentage).ToString();//Display percentage value

        //Save Audio settings
        PlayerPrefs.SetFloat("masterVolume", master.value);
        PlayerPrefs.Save();
    }

    public void SetMusicSound()
    {
        audioMixer.SetFloat("MusicVolume", music.value);
        float percentage = (((-80.0f - music.value)) / -80.0f) * 100.0f;
        musicText.text = ((int)percentage).ToString();

        PlayerPrefs.SetFloat("musicVolume", music.value);
        PlayerPrefs.Save();
    }

    public void SetAmbientSound()
    {
        audioMixer.SetFloat("AmbientVolume", ambient.value);
        float percentage = (((-80.0f - ambient.value)) / -80.0f) * 100.0f;
        ambientText.text = ((int)percentage).ToString();

        PlayerPrefs.SetFloat("ambientVolume", ambient.value);
        PlayerPrefs.Save();
    }

    public void SetPlayerSound()
    {
        audioMixer.SetFloat("PlayerVolume", player.value);
        float percentage = (((-80.0f - player.value)) / -80.0f) * 100.0f;
        playerText.text = ((int)percentage).ToString();

        PlayerPrefs.SetFloat("playerVolume", player.value);
        PlayerPrefs.Save();
    }

    void SetStartingValues()
    {
        float percentage, value;

        //Master Volume
        value = PlayerPrefs.GetFloat("masterVolume");
        audioMixer.SetFloat("MasterVolume",value);//Extracting the actual volume value
        master.value = value;//Apply it to the slider
        percentage = ((-80.0f - value) / -80.0f) * 100.0f;//Convert it to a percentage
        masterText.text = ((int)percentage).ToString();//Display the percentage

        //Music Volume
        value = PlayerPrefs.GetFloat("musicVolume");
        audioMixer.SetFloat("MusicVolume", value);//Extracting the actual volume value
        music.value = value;//Apply it to the slider
        percentage = ((-80.0f - value) / -80.0f) * 100.0f;//Convert it to a percentage
        musicText.text = ((int)percentage).ToString();//Display the percentage

        //Ambient Volume
        value = PlayerPrefs.GetFloat("ambientVolume");
        audioMixer.SetFloat("AmbientVolume", value);//Extracting the actual volume value
        ambient.value = value;//Apply it to the slider
        percentage = ((-80.0f - value) / -80.0f) * 100.0f;//Convert it to a percentage
        ambientText.text = ((int)percentage).ToString();//Display the percentage


        //Player Volume
        value = PlayerPrefs.GetFloat("playerVolume");
        audioMixer.SetFloat("PlayerVolume", value);//Extracting the actual volume value
        player.value = value;//Apply it to the slider
        percentage = ((-80.0f - value) / -80.0f) * 100.0f;//Convert it to a percentage
        playerText.text = ((int)percentage).ToString();//Display the percentage
    }
}
