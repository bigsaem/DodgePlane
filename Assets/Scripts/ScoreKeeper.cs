using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    public int score;
    private Text scoreText;
    //public int scoreOverTime = 65;
    //private ScoreKeeper scoreKeeper;

    // Use this for initialization
    void Start () {
        //scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
        scoreText = GetComponent<Text>();
        ResetScore();
        
        //Invoke("ScorePoints", 0.5f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Score(int points)
    {
        score += points;
        scoreText.text = score.ToString();
    }

    public int GetScore()
    {
        return score;
    }

    public void SetScore(int scoreValue)
    {
        score = scoreValue;
    }

    public void ResetScore()
    {
        PlayerPrefs.SetInt("highestScore", 0);
        HighestScoreDisplay.ResetScore();
    }
    /*
    public void ScorePoints()
    {
        scoreKeeper.Score(scoreOverTime);
    }
    */
}
