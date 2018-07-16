using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    public int score;
    private Text scoreText;
    private int toStageTwo = 1500;
    //public int scoreOverTime = 65;
    //private ScoreKeeper scoreKeeper;

    // Use this for initialization
    void Start () {
        //scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
        
        scoreText = GetComponent<Text>();
        ResetScore();
        score = LevelManager.GetCurrentScore();

        //Invoke("ScorePoints", 0.5f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Score(int points)
    {
        score += points;
        scoreText.text = score.ToString();
        CheckCurrentScore();
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
        score = 0;
        scoreText.text = score.ToString();

    }

    public void CheckCurrentScore()
    {
        if(score >= toStageTwo && SceneManager.GetActiveScene().name != "GameScene2")
        {

            score = toStageTwo;
            LevelManager.SetCurrentScore(score);
            if(SceneManager.GetActiveScene().name != "GameScene2")
            {
                SceneManager.LoadScene("GameScene2");
            }
        }
    }
    /*
    public void ScorePoints()
    {
        scoreKeeper.Score(scoreOverTime);
    }
    */
}
