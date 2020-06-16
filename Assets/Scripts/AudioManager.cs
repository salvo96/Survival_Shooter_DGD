using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;
    public AudioMixer mixer;
    public AudioClip menu, gameplay;
    public AudioSource musicSource;
    public AudioSource UISource;

    float master, music, effects, userInterface;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject); //se una instance è già prensente distruggi questa
        }
        else
        {
            instance = this; //altrimenti imposta questa come instance e conservala.
            DontDestroyOnLoad(gameObject);
        }
    }    

    void Start()
    {
        if (PlayerPrefs.HasKey("master")) {
            master = PlayerPrefs.GetFloat("master");
            SetMaster(master);
        }
        if (PlayerPrefs.HasKey("music"))
        {
            music = PlayerPrefs.GetFloat("music");
            SetMusic(music);
        }
        if (PlayerPrefs.HasKey("effects"))
        {
            effects = PlayerPrefs.GetFloat("effects");
            SetEffects(effects);
        }
        if (PlayerPrefs.HasKey("userInterface"))
        {
            userInterface = PlayerPrefs.GetFloat("userInterface");
            SetUI(userInterface);
        }

    }

    public void SetMaster(float level)
    {
        mixer.SetFloat("master", level);
        PlayerPrefs.SetFloat("master", level);
        PlayerPrefs.Save();
    }

    public void SetMusic(float level)
    {
        mixer.SetFloat("music", level);
        PlayerPrefs.SetFloat("music", level);
        PlayerPrefs.Save();
    }

    public void SetEffects(float level)
    {
        mixer.SetFloat("effects", level);
        PlayerPrefs.SetFloat("effects", level);
        PlayerPrefs.Save();
    }

    public void SetUI(float level)
    {
        mixer.SetFloat("userInterface", level);
        PlayerPrefs.SetFloat("userInterface", level);
        PlayerPrefs.Save();
    }

    public void PlayMenuMusic()
    {
        musicSource.Stop();
        musicSource.clip = menu;
        musicSource.Play();
    }

    public void PlayGamePlayMusic()
    {
        musicSource.Stop();
        musicSource.clip = gameplay;
        musicSource.Play();
    }

    public void PlayUIMusic()
    {
        UISource.Play();
    }


    public void DestroyAudioM()
    {
        Destroy(gameObject);
    }



}
