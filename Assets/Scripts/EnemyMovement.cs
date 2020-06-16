using UnityEngine;
using System.Collections;
using UnityEngine.AI;


public class EnemyMovement : MonoBehaviour {

    Transform player;
    NavMeshAgent nav;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        
    }

    void Update () {
        if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && GameManager.instance.GetGameActive())
            nav.SetDestination(player.position);		
	}
}
