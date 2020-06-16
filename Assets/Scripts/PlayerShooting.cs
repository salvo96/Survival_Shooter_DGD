using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 20;                  
    public float timeBetweenBullets = 0.15f;        
    public float range = 100f;                      

    float timer;                                    
    Ray shootRay;                                   //ray che fuoriesce dall'arma (per impiego con raycast)                            
    RaycastHit shootHit;                            //raycast che mi determina l'oggetto colpito                           
    int shootableMask;                                                 
    public LineRenderer gunLine;                                                    
    public Light gunLight;                                 
    float effectsDisplayTime = 0.2f;
    public AudioSource gunSound;

    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
    }

    void Update()
    {
        timer += Time.deltaTime;
        
        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && !PauseManager.instance.InPause() && GameManager.instance.GetGameActive())
            Shoot();

        if (timer >= timeBetweenBullets * effectsDisplayTime)
            DisableEffects();
    }

    public void DisableEffects()
    {
        // Disable the line renderer and the light.
        gunLine.enabled = false;
        gunLight.enabled = false;
    }

    void Shoot()
    {
        timer = 0f;
        gunSound.Play();
        gunLight.enabled = true;
        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            if (shootHit.distance <= 10.0f)
            {
                EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();


                if (enemyHealth != null)
                    enemyHealth.TakeDamage(damagePerShot);

                gunLine.SetPosition(1, shootHit.point);
            }
        }
        else
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
    }
}
