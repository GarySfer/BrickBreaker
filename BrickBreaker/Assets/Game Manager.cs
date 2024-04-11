using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {

    public int lives;
    public double score;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;

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
        livesText.text = "Lives: " + lives;
    }

    public void UpdateScore(int scoreChange) {
        score += scoreChange;
        scoreText.text = "Score: " + score;
    }
}
