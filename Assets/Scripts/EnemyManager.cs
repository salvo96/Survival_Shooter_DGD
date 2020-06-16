using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public static EnemyManager instance;
    public GameObject enemy;    
    public Transform[] spawnPoints;         //Array contenente gli SpawnPoints per il dato enemy

    bool isPlayerAlive = true;
    float spawnTime;
    bool isRunning=false;

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

    public void StartSpawn(float time)
    {
        spawnTime = time;
        if (!isRunning)
        {
            StartCoroutine("Spawn");
            isRunning = true;
        }
    }

    IEnumerator Spawn()
    {
        while (isPlayerAlive)
        {       //se il player è morto non spawno più nulla
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);  //seleziono in modo casuale l'indice dell'array (ovvero seleziono in modo casuale il punto in cui vado a spawnare l'enemy tra quelli esistenti)
            Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);   //Creo una nuova instanza dell'enemy
            yield return new WaitForSeconds(spawnTime);
        }
    }

    public void SetPlayerAlive(bool state)
    {
        isPlayerAlive = state;
    }

    public void DestroyEnemyM()
    {
        Destroy(gameObject);
    }

    public void SetSpawnTime(float value)
    {
        spawnTime = value;
    }

    public float GetSpawnTime()
    {
        return spawnTime;
    }
}
