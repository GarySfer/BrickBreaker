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
    public bool gameover = false;
    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start() {
        lives = 3;
        score = 0;
        livesText.text = "Lives: " + lives;
        scoreText.text = "Scrore: " + score;
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

    void GameOver() {
        gameover = true;
        gameOverPanel.SetActive(true);
    }

    public void PlayAgain() {
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit() {
        Application.Quit();
        Debug.Log("NIE WYJDZIESZ");
    }
}
