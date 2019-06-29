using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TopScoreUI : MonoBehaviour {
    public ScoreUI scoreUI;
    Text topScoreText;
    const string path = "Assets/Prefabs/UI/TopScore.txt";
    static int topScore;

    ~TopScoreUI() {
        if (scoreUI.GetScore() > topScore) {
            File.WriteAllText(path, scoreUI.GetScore().ToString());
        }
    }

    void Start() {
        topScoreText = GetComponent<Text>();

        using (StreamReader sr = File.OpenText(path)) {
            string s;
            while ((s = sr.ReadLine()) != null) {
                topScore = int.Parse(s);
                topScoreText.text = "TopScore : " + topScore;
            }
        }
    }

    void Update() {
        if (scoreUI.GetScore() > topScore) {
            topScoreText.text = "TopScore : " + scoreUI.GetScore();
        }
    }
}
