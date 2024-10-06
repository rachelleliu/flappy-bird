using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float speed = 0.8f; //set speed of platform movement
    public float xReset = -0.783f; //set x position boundary
    public float xStart = 0.83f; //set reset x position
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //continuously move platform to the left
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        //if platform crosses boundary, move back to the starting position
        if(transform.position.x <= xReset){
            Vector3 start = new Vector3(xStart, transform.position.y, 0);
            transform.position = start;
        }
    }
}
