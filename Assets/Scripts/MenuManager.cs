using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public GameObject menuBackground;
    public GameObject credits;
    public GameObject namePlayScreen;
    public GameObject optionsMenu;
    public GameObject soundMenu;
    public GameObject highScores;
    public Text HighScoreBody1;
    public Text HighScoreBody2;
    public Text HighScoreBody3;
    public InputField playerName;
    public Slider master, music, effects, userInterface;
    public Slider level;

    private void Start()
    {
        if (GameManager.instance != null)
            GameManager.instance.DestroyGameM();
        if (PauseManager.instance != null)
            PauseManager.instance.DestroyPauseM();
        AudioManager.instance.PlayMenuMusic();
    }

    public void StartGame()
    {
        if (playerName.text.Length != 0)
        {
            AudioManager.instance.PlayUIMusic();
            UserInfo.SetPlayerSetting(playerName.text);    
            UserInfo.SetPlayerSetting(level.value);
            UserInfo.SetAttackDamageDifficulty(0f);
            UserScore<int>.SetFinished(false);
            UserScore<int>.SetScore(0);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            AudioManager.instance.PlayGamePlayMusic();
        }
 
    }

    public void ExitGame()
    {
        AudioManager.instance.PlayUIMusic();
        Application.Quit();
    }

    public void IntoCredits()
    {
        menuBackground.SetActive(false);
        credits.SetActive(true);
        AudioManager.instance.PlayUIMusic();
    }

    public void IntoMenu()
    {        
        menuBackground.SetActive(true);
        credits.SetActive(false);
        optionsMenu.SetActive(false);
        namePlayScreen.SetActive(false);
        highScores.SetActive(false);
        AudioManager.instance.PlayUIMusic();
    }

    public void SelectName()
    {
        menuBackground.SetActive(false);
        namePlayScreen.SetActive(true);
        AudioManager.instance.PlayUIMusic();
    }

    public void IntoOptions()
    {
        menuBackground.SetActive(false);
        optionsMenu.SetActive(true);
        soundMenu.SetActive(false);
        AudioManager.instance.PlayUIMusic();
    }

    public void IntoSound()
    {
        optionsMenu.SetActive(false);
        soundMenu.SetActive(true);
        AudioManager.instance.PlayUIMusic();
        if (PlayerPrefs.HasKey("master"))
            master.value = PlayerPrefs.GetFloat("master");
        
        if (PlayerPrefs.HasKey("music"))
            music.value = PlayerPrefs.GetFloat("music");
     
        if (PlayerPrefs.HasKey("effects"))
            effects.value = PlayerPrefs.GetFloat("effects");
            
        if (PlayerPrefs.HasKey("userInterface"))
            userInterface.value = PlayerPrefs.GetFloat("userInterface");
            
    }

    public void IntoHighScores()
    {
        string name;
        int score;
        menuBackground.SetActive(false);
        highScores.SetActive(true);
        AudioManager.instance.PlayUIMusic();
        HighScoreBody1.text = "";
        HighScoreBody2.text = "";
        HighScoreBody3.text = "";
        for (int i = 1; i < 11; i++)
        {
            if (PlayerPrefs.HasKey(i.ToString()))
            {
                name = PlayerPrefs.GetString(i.ToString());
                if (PlayerPrefs.HasKey(name))
                {
                    score = PlayerPrefs.GetInt(name);
                    HighScoreBody1.text += i.ToString() + "\n";
                    HighScoreBody2.text += name + "\n";
                    HighScoreBody3.text += score + "\n";
                }
                else
                {
                    HighScoreBody1.text += i.ToString() + "\n";
                    HighScoreBody2.text += "\n";
                    HighScoreBody3.text += "\n";
                }
            }
            else
            {
                HighScoreBody1.text += i.ToString() + "\n";
                HighScoreBody2.text += "\n";
                HighScoreBody3.text += "\n";
            }
        }
    }

}
