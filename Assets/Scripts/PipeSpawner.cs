using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipes; //ref to pipes to spawn
    public float spawnRate = 2f; //set pipe spawn rate in seconds
    public float heightOffset = 2f; //random height offset for pipes
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //increment timer by time since last frame
        timer += Time.deltaTime;

        //spawn pipes if timer meets spawn rate
        if(timer >= spawnRate){
            SpawnPipe();
            timer = 0f;
        }
    }

    void SpawnPipe(){
        //generate a random number for height offset
        float height = Random.Range(-heightOffset, heightOffset);

        //new pipe position
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y + height, 0);
        
        //instantiate new pipes
        Instantiate(pipes, spawnPos, Quaternion.identity);
    }
}
