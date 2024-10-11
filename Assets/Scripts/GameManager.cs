using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Player player; //ref to player
    public float count = 3f; //set countdown timer length
    public int score = 0; //set initial score
    public int highScore = 0; //high score
    private bool gameStarted = false; //boolean to track if game started
    
    //UI elements
    public GameObject startButton; //start button
    public GameObject startMenu; //start menu
    public GameObject overMenu; //game over menu
    public TMP_Text highScoreDisplay; //high score display text
    public TMP_Text countdown; //countdown text
    public TMP_Text scoreDisplay; //score display text
    
    
    // Start is called before the first frame update
    void Start()
    {
        //retrieve high score
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        //disable unneeded UI and freeze game
        countdown.gameObject.SetActive(false);
        scoreDisplay.gameObject.SetActive(false);
        overMenu.gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //start game if user input detected and set gameStarted boolean to true
        if(Input.GetButtonDown("Jump") && !gameStarted){
            StartGame();
        }
        
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
        //disable start menu and set gameStarted bool to true;
        startMenu.SetActive(false);
        gameStarted = true;
        
        //unfreeze time
        Time.timeScale = 1;

        //display score
        scoreDisplay.gameObject.SetActive(true);
    }

    public void GameOver(){
        //freeze game
        Time.timeScale = 0;

        //check if score is new high score and store new
        if(score > highScore){
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        } 
        
        //display game over menu
        overMenu.SetActive(true);
        highScoreDisplay.text = "High Score: " + highScore.ToString();
    }

    public void Restart(){
        //reload scene
        SceneManager.LoadScene("FlappyBird");
    }

    public void AddScore(){
        //increment score by 1
        score++;
    }
}
