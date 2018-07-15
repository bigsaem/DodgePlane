using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    private string levelName = "GameScene";

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

}
