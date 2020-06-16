using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePowerUp : PowerUp, IPowerUp {

    public PlayerHealth playerHealth;
    public GameObject player;

    public void ImproveFeature()
    {
        playerHealth.currentHealth = 100;
        GameManager.instance.StartCoroutine("TextPersistance");
        TakeContact("Life");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
            ImproveFeature();
    }


}
