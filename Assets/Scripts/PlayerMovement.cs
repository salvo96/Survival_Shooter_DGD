using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 6f;

    /*variabili private*/
    Animator anim;
    Rigidbody playerRigidbody;
    Transform position;
    int floorMask;

    Vector3 movement;    
    float camRayLength = 100f;

    delegate void MultiDelegate(float h, float v);
    MultiDelegate playerActions;

    void Awake()    //eseguito all'inizio prima di start() e indipendentemente dal fatto che lo script component sia abilitato o meno
    {
        floorMask = LayerMask.GetMask("Terrain");
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        position = GetComponent<Transform>();

        playerActions += Move;
        playerActions += Animate;
    }

    void FixedUpdate()
    {        
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        playerActions(h, v);
        Turn();
    }

    void Move(float h, float v)
    {        
        movement.Set(h, 0f, v); //->setto il vector3 movement ai valori ottenuti mediante la pressione dei pulsanti di movimento
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);    //sposto il player dalla posizione attuale (transform.position) di una quantità movement (normalizzata al passo precedente)
    }

    void Turn()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition); //genero un raggio dalla main camera al punto in cui sta correntemente puntando il mouse
        RaycastHit floorHit;
        if(Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;    //vector3 contentente il punto in cui deve essere spostato il player
            playerToMouse.y = 0f;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidbody.MoveRotation(newRotation);  //ruoto il rigidbody tenendo conto delle interazioni fisiche (al contrario transform.rotation non ne tiene conto)
        }

    }

    void Animate(float h, float v)  //quando devo animare il mio oggetto?
    {
        bool walk = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walk);
    }


}
