using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public float timeBetweenAttacks = 0.5f;
    public float attackDamage;

    Animator anim;                              
    GameObject player;                          
    PlayerHealth playerHealth;                  
    EnemyHealth enemyHealth;                    
    bool playerInRange;                         
                           


    void Awake()
    {        
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
        attackDamage = UserInfo.GetAttackDamage();   //scelgo il danno inflitto dai nemici in base al livello scelto
    }

    private void Start()
    {
        StartCoroutine("AttackRoutine");
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
            playerInRange = true;
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
            playerInRange = false;
    }

    IEnumerator AttackRoutine()
    {
        while (true)
        {
            if (playerInRange && enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && GameManager.instance.GetGameActive())
            {          
                playerHealth.TakeDamage(attackDamage);
                anim.SetTrigger("PlayerAttack");
            }
            yield return new WaitForSeconds(timeBetweenAttacks);
        }

    }
}
