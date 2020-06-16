using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPowerUp : PowerUp, IPowerUp {

    public PlayerShooting playerShooting;
    public GameObject player;

    public void ImproveFeature()
    {
        playerShooting.damagePerShot = 50;
        TakeContact("Ammo Boost");
    }
	
    public override void TakeContact(string type)
    {
        powerUpInfo.text = type;
        GameManager.instance.StartCoroutine("AmmoBoost");
        gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
            ImproveFeature();
    }
}
