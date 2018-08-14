using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighestScoreDisplay : MonoBehaviour
{

    private static Text scoreText;

    void Start()
    {

        scoreText = GetComponent<Text>();
        ResetScore();

    }

    public static void ResetScore()
    {
        if (scoreText != null)
        {
            scoreText.text = "Highest Score: " + PlayerPrefs.GetInt("highestScore");

        }
    }
}