using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float flapForce = 5.0f; //set force of flap
    private Rigidbody2D rb; //reference to player rigidbody
    
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
        }
    }
}
