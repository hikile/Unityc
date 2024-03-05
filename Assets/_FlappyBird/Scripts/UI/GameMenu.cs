using System;
using GameTool;
using TMPro;
using UnityEngine;

public class GameMenu : SingletonUI<GameMenu>
{
    // Start is called before the first frame update
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hightestScoreText;

    private void Start()
    {
        scoreText.text = "Score: 0";
        hightestScoreText.text = "Highest Score: " + GameData.Instance.hightestScore;
    }

    public void UpdateScore(int anount)
    {
        GameData.Instance.score += anount;
        scoreText.text = "Score: "+GameData.Instance.score.ToString();
        if (GameData.Instance.hightestScore < GameData.Instance.score)
        {
            GameData.Instance.hightestScore = GameData.Instance.score;
            hightestScoreText.text = "Hightest Score: " + GameData.Instance.score;
        }
    }
}
