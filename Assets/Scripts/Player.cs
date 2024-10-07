using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float flapForce = 5.0f; //set force of flap
    private Rigidbody2D rb; //reference to player rigidbody

    public GameManager gameManager; //reference to game manager
    public bool lost = false; //set if player lost

    //game sounds
    public AudioSource flapSound;
    public AudioSource loseSound;
    
    // Start is called before the first frame update
    void Start()
    {
        //access player rigidbody
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //flap bird up if spacebar or left mouse is hit        
        if(Input.GetButtonDown("Jump")){
            rb.AddForce(Vector2.up * flapForce, ForceMode2D.Impulse);
            flapSound.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        //set lost to true and call GameOver function
        loseSound.Play();
        lost = true;
        gameManager.GameOver();    
    }
}
