using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour {

    public Image panel;
    public Button pauseBtn;
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(Time.timeScale != 0)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
            
        }
	}

    public void Pause()
    {
        Time.timeScale = 0;
        if(pauseBtn && panel)
        {
            pauseBtn.gameObject.SetActive(false);
            panel.gameObject.SetActive(true);
        }
            
    }

    public void Resume()
    {
        Time.timeScale = 1;
        if (pauseBtn && panel)
        {
            pauseBtn.gameObject.SetActive(true);
            panel.gameObject.SetActive(false);
        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void Quit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start");
    }
}
