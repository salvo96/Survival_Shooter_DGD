using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public Text timer;
    public PlayerHealth playerHealth;
    public Animator anim;
    public PlayerShooting playerShooting;
    public Text powerUpInfo;
    public GameObject[] powerUp;
    public GameObject pauseMenu;
    public PlayerMovement playerMovement;

    int score;
    int last_score = 0;
    float timeLeft = UserInfo.GetDuration();   //setto la durata della partita in funzione del livello scelto
    bool gameActive = true;

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

    private void Start()        //gestire meglio per riavvio livello e avvio la prima volta
    {
        SpawnEnemies(UserInfo.GetSpawnTime());   //scelgo la velocità di spawn dei nemici in base al livello scelto
        score = 0;
        StartCoroutine("Timer");
        StartCoroutine("SpawnPowerUp");
    }

    void Update()
    {
        if (gameActive)
        {
            if (playerHealth.currentHealth <= 0)
            {
                StopCoroutine("Timer");
                StartCoroutine("GameOver");
            }
            else
            {
                //creo un moltiplicatore che in funzione dello score aumenta la difficoltà (tempo di spawn e danno inflitto dai nemici)
                if(score%50 == 0 && score > 0 && last_score != score)
                {
                    //ogni 200 punti diminuisco il tempo di spawn di 0.5 s
                    EnemyManager.instance.SetSpawnTime(EnemyManager.instance.GetSpawnTime() - 0.5f);
                    //ogni 200 punti aumento il danno inflitto dai nemici di 5
                    UserInfo.SetAttackDamageDifficulty(UserInfo.GetAttackDamageDifficulty() + 5);
                    last_score = score;
                }
            }
        }

        if (Input.GetKeyDown("escape") && !PauseManager.instance.InPause())
            PauseManager.instance.PauseMenu();
        
    }


    public void SpawnEnemies(float time)
    {
        EnemyManager.instance.StartSpawn(time);       //gestire in base al livello di difficoltà
       
    }

    IEnumerator Timer()
    {
        while (timeLeft > 0)
        {
            timeLeft -= 1;
            timer.text = Mathf.Floor(timeLeft / 60).ToString("00") + ":" + Mathf.FloorToInt(timeLeft % 60).ToString("00");
            yield return new WaitForSeconds(1);
        }
        StartCoroutine("GameOver");     //gestire il blocco di user e nemici come nel caso di life<0        
    }    

    IEnumerator GameOver()
    {
        gameActive = false;
        EnemyManager.instance.SetPlayerAlive(false);
        playerMovement.enabled = false;
        anim.SetTrigger("GameOver");
        UserScore<int>.SetScore(score);      //una volta che la partita è finita salvo lo score nella classe statica relativa
        UserScore<int>.SetFinished(true);
        yield return new WaitForSeconds(5f);
        EnemyManager.instance.DestroyEnemyM();
        AudioManager.instance.DestroyAudioM();
        SceneManager.LoadScene(0);
    }

    IEnumerator AmmoBoost()
    {
        yield return new WaitForSeconds(10f);
        playerShooting.damagePerShot = 20;
        powerUpInfo.text = "";
    }

    IEnumerator TextPersistance()
    {
        yield return new WaitForSeconds(10f);
        powerUpInfo.text = "";
    }

    IEnumerator SpawnPowerUp()
    {
        while (gameActive)
        {
            int powerUpIndex = Random.Range(0, powerUp.Length);  //seleziono in modo casuale l'indice dell'array (ovvero seleziono in modo casuale il punto in cui vado a spawnare l'enemy tra quelli esistenti)
            powerUp[powerUpIndex].SetActive(true);
            yield return new WaitForSeconds(30f + Random.Range(0f, 100f));
        }
    }


    public void IncreaseScore(int value)
    {
        score += value;
    }

    public int GetScore()
    {
        return score;
    }

    public void AddTimerSeconds(float seconds)
    {
        timeLeft += seconds;
    }

    public void DestroyGameM()
    {
        Destroy(gameObject);
    }

    public bool GetGameActive()
    {
        return gameActive; 
    }


}
