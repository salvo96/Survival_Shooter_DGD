using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {

    public static PauseManager instance;

    public GameObject pauseMenu;

    bool inPause = false;   //utile ad esempio nello script di animazione dei powerUp

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

    public void PauseMenu()
    {
        inPause = true;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        AudioManager.instance.PlayMenuMusic();
    }

    public void ReturnToGame()
    {
        inPause = false;
        AudioManager.instance.PlayGamePlayMusic();
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void BackToMenu()
    {
        EnemyManager.instance.DestroyEnemyM();
        AudioManager.instance.DestroyAudioM();
        SceneManager.LoadScene(0);
    }

    public void DestroyPauseM()
    {
        Destroy(gameObject);
    }

    public bool InPause()
    {
        return inPause;
    }
}
