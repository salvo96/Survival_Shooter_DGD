using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthRefresher : MonoBehaviour {

    Slider healthSlider;
    public PlayerHealth playerHealth;

    void Awake()
    {
        healthSlider = GetComponent<Slider>();
        StartCoroutine("HealthSlider");
    }

    IEnumerator HealthSlider()
    {
        while (true)
        {
            healthSlider.value = playerHealth.currentHealth;
            yield return null;
        }
    }
}
