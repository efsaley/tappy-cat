using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int score;
    Text scoreText;
    int highScore;

    public Text panelScore;
    public Text panelHighScore;
    public GameObject New;
    // Start is called before the first frame update
    void Start()
    {
      score = 0;
      scoreText = GetComponent<Text>();
      scoreText.text = score.ToString();
      panelScore.text = score.ToString();
      highScore = PlayerPrefs.GetInt("highscore");
      panelHighScore.text = highScore.ToString();
    }

    public void Scored()
    {
        score++;
        scoreText.text = score.ToString();
        panelScore.text = score.ToString();

        byte toRed = (byte)Mathf.Clamp(255 - score * 20, 0, 255);
        scoreText.color = new Color32( 255, toRed, toRed, 200 );
        if (score > highScore)
        {
          highScore = score;
          panelHighScore.text = highScore.ToString();
          PlayerPrefs.SetInt("highscore", highScore);
          New.SetActive(true);
        }
    }

    public int GetScore()
    {
      return score;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
