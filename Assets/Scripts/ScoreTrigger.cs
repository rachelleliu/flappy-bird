using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    public GameManager gameManager; //ref to game manager
    
    // Start is called before the first frame update
    void Start()
    {
        //find game manager
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other) {
        //increment the score counter if the player is detected
        if(other.CompareTag("Player")){
            gameManager.AddScore();
        }
    }
}
