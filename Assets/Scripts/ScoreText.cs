using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

    public ScoreType type;
    string content = "";
    Text scoreText;
    // Use this for initialization
    void Start()
    {
        scoreText = GetComponent<Text>();
        if (type == ScoreType.HighScore)
        {
            content = "HighScore: " + PlayerPrefs.GetInt("highestScore");
            print("highScore");
        }
        else
        {
            content = "Score: " + PlayerPrefs.GetInt("currentScore");
        }
        scoreText.text = content;
    }
}
public enum ScoreType
{
    HighScore,
    CurrentScore
}
