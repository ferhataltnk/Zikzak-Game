using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{
    public TMPro.TextMeshProUGUI highScore;

    private void Awake()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        

    }



     void QuitMenuShow()
    {
        SceneManager.LoadScene(1);

    }



    public void QuitGame()
    {
        Application.Quit();
    }








}
