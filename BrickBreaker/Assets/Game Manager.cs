using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

    public int lives;
    public double score;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TMP_InputField highScoreInput;
    public bool gameover = false;
    public GameObject gameOverPanel;
    public GameObject loadingLevelPanel;
    int bricksAmount;
    public Transform[] levels;
    private int currentLevelIndex = 0;


    // Start is called before the first frame update
    void Start() {
        score = 0;
        livesText.text = "Lives: " + lives;
        scoreText.text = "Scrore: " + score;
        bricksAmount = GameObject.FindGameObjectsWithTag("brick").Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLives(int livesChange) {
        lives += livesChange;

        if (lives <= 0) {
            lives = 0;
            GameOver();
        }

        livesText.text = "Lives: " + lives;
    }

    public void UpdateScore(int scoreChange) {
        score += scoreChange;
        scoreText.text = "Score: " + score;
    }

    public void UpdateBrickAmount() {
        bricksAmount--;
        if(bricksAmount <=0) {
            
            if(currentLevelIndex >= levels.Length -1) {
                GameOver();
            } else {
                loadingLevelPanel.SetActive(true);
                loadingLevelPanel.GetComponentInChildren<TextMeshProUGUI>().text = "Level " + (currentLevelIndex +2);
                gameover = true;
                Invoke("LoadLevel", 2f);
            }
        }
    }


    void LoadLevel() {
        currentLevelIndex++;
        Instantiate(levels[currentLevelIndex], Vector2.zero, Quaternion.identity);
        bricksAmount = GameObject.FindGameObjectsWithTag("brick").Length;
        gameover = false;
        loadingLevelPanel.SetActive(false);
    }

    void GameOver() {
        gameover = true;
        gameOverPanel.SetActive(true);
        int highscore = PlayerPrefs.GetInt("HIGHSCORE");
        if(score > highscore) {
            PlayerPrefs.SetInt("HIGHSCORE", (int)score);

            highScoreText.text = "New Highscore!:" + "\n" + "Enter your name below.";
            highScoreInput.gameObject.SetActive(true);

        } else {
            highScoreText.text = PlayerPrefs.GetString("HIGHSCORENAME") + " Highscore: " + highscore + "\n" + "Your score is: " + score;
        }
    }

    public void NewHighScore() {
        string highScoreName = highScoreInput.text;
        PlayerPrefs.SetString("HIGHSCORENAME", highScoreName);
        highScoreInput.gameObject.SetActive(false);
        highScoreText.text = "Highscore: " + highScoreName + "\n" + "Your highscore is: " + score;
    }

    public void PlayAgain() {
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit() {
        Application.Quit();
        Debug.Log("NIE WYJDZIESZ");
    }
}
