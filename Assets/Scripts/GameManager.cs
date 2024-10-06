using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject startButton; //start button
    public Player player; //ref to player
    public TMP_Text countdown; //countdown text
    public TMP_Text scoreDisplay; //score display text
    public float count = 3f; //set countdown timer length
    public int score = 0; //set initial score
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        //disable text displays and freeze game
        countdown.gameObject.SetActive(false);
        scoreDisplay.gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //display player score
        scoreDisplay.text = "Score: " + score.ToString();
        
        //start countdown to restart when player loses
        if(player.lost){
            countdown.gameObject.SetActive(true);
            count -= Time.unscaledDeltaTime;
        }

        //set countdown text
        countdown.text = "Restarting in " + count.ToString("0");

        //restart game when countdown ends
        if(count < 1){
            Restart();
        }
    }

    public void StartGame(){
        //disable start button
        startButton.SetActive(false);
        
        //unfreeze time
        Time.timeScale = 1;

        //display score
        scoreDisplay.gameObject.SetActive(true);
    }

    public void GameOver(){
        //freeze game
        Time.timeScale = 0;
    }

    public void Restart(){
        //reload scene
        EditorSceneManager.LoadScene(0);
    }

    public void AddScore(){
        //increment score by 1
        score++;
    }
}
