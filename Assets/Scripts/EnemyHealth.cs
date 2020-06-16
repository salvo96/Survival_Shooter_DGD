using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour, IDamageable {

    public float startingHealth = 100f;            
    public float currentHealth;                   
    public float sinkSpeed = 2.5f;              //Velocità di risucchio dell'enemy una volta ucciso
    public int scoreValue = 10;                 //Quantità di punteggio che assegno se elimino enemy                
    
    Animator anim;                              
    AudioSource enemyAudio;               
    BoxCollider boxCollider;            
    bool isDead;                                
    bool isSinking;                            


    void Awake()
    {
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        boxCollider = GetComponent<BoxCollider>();

        currentHealth = startingHealth;
    }

    void Update()
    {
        if (isSinking)  //se l'enemy si trova in fase di risucchio
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
    }


    public void TakeDamage(float amount) 
    {
        if (isDead) //se l'enemy è morto non faccio nulla (esco)
            return;

        enemyAudio.Play();
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            isDead = true;
            boxCollider.isTrigger = true;
            anim.SetTrigger("Dead");
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            isSinking = true;
            GameManager.instance.IncreaseScore(scoreValue);
            Destroy(gameObject, 1f);    //distruggo l'enemy dopo 2 secondi
        }
    }
}
