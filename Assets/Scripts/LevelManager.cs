using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name)
    {
        Application.LoadLevel(name);
    }

    public void QuitRequest()
    {
        SceneManager.LoadScene("Start");
    }

    public void LoadNextLevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }
    public void ResetScore()
    {
        PlayerPrefs.SetInt("highestScore", 0);
        HighestScoreDisplay.ResetScore();
    }
}
