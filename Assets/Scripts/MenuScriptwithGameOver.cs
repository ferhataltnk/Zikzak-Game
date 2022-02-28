using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScriptwithGameOver : MenuScript
{ 
    public void gameOverPanelClose()
    {
        SceneManager.LoadScene(0);
    }

    public void PauseGame()
    {
        Time.timeScale = Time.timeScale==0f ? 1f : 0f;

    }



}
