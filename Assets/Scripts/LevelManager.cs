using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    private string levelName = "GameScene";
    public Button stage2;
    private static int currentScore = 0;
    

    public void Start()
    {
        DontDestroyOnLoad(this);
        DisplayStage();
    }

    public void DisplayStage()
    {
        if (stage2 != null)
        {
            if (PlayerPrefs.GetInt("highestScore") >= 1500)
            {
                stage2.interactable = true;
            }
            else
            {
                stage2.interactable = false;
            }
        }
    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(levelName);
    }

    public void QuitRequest()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(Application.loadedLevel + 1);
    }

    public void ChooseStage(int lvl)
    {
        switch (lvl)
        {
            case 1:
                levelName = "GameScene";
                break;
            case 2:
                levelName = "GameScene2";
                break;
            default:
                levelName = "GameScene";
                break;
        }
    }

    public void ResetScore()
    {
        PlayerPrefs.SetInt("highestScore", 0);
        DisplayStage();
        HighestScoreDisplay.ResetScore();
    }

    public static int GetCurrentScore()
    {
        return currentScore;
    }

    public static void SetCurrentScore(int cs)
    {
        currentScore = cs;
    }


}
