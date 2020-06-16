using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamageable {

    public float startingHealth = 100f;                            
    public float currentHealth;                                                                   
    public Image damageImage;                                                                   
    public float flashSpeed = 5f;                               
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     
    public AudioSource damageSound;
                             
    bool isDead;                                                
    bool damaged;                                               


    void Awake()
    {
        currentHealth = startingHealth;
    }


    void Update()
    {
        if (damaged)    //se il player è stato attaccato
            damageImage.color = flashColour;
        else
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);  //vario il colore dello schermo verso il trasparente con interpolazione lineare  
        damaged = false;
    }


    public void TakeDamage(float amount)  //funzione che viene eseguita in fase d'attacco dall'enemy per danneggiare il player
    {
        damaged = true;
        currentHealth -= amount;
        damageSound.Play();
    }

}
