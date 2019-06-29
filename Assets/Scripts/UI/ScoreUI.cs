using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour {
    Text scoreText;
    static int scorePoint;

    void Start() {
        scoreText = GetComponent<Text>();
        scorePoint = 0;
    }

    void Update() {
        scoreText.text = "Score : " + scorePoint;
    }

    public void SetScore(int set) {
        scorePoint += set;
    }
    public int GetScore() {
        return scorePoint;
    }
}
