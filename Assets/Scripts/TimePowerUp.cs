using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePowerUp : PowerUp, IPowerUp {

    public GameObject player;


    public void ImproveFeature()
    {
        GameManager.instance.AddTimerSeconds(60f);
        GameManager.instance.StartCoroutine("TextPersistance");
        TakeContact("Time Increase");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
            ImproveFeature();
    }


}
