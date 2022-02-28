using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   /*UI elemanlarına script tarafından erişebilmem için dahil etmek zorundayım.*/
using TMPro;

public class Score : MonoBehaviour
{

    public static int skor;
    public int highScore;

    public TMPro.TextMeshProUGUI highScoreText;
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI gameHighScoreText;


    //public Text skortext;
    public TMPro.TextMeshProUGUI skortext;

    private void Awake()
    {
        gameHighScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
    }
    void Start()
    {
        skor = 0;
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    void Update()
    {
        skortext.text = skor.ToString();   /*canvas elemanlarından text(skortext olarak dışardan alıcam) objesinin text componentine erişiyorum. */

        scoreText.text = skor.ToString();

        if (skor>PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", skor);

        }

    }




}
