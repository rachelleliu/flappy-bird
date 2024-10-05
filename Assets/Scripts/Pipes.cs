using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float speed = 2f; //set pipe speed
    public float destroyAfter = 5f; //set how long pipes stay before deletion 
    private float timer = 0f;  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //increment timer
        timer += Time.deltaTime;
        
        //move pipes to the left
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        //destroy pipes after timer passed
        if(timer >= destroyAfter){
            Destroy(gameObject);
        }
    }
}
