using System;
using GameTool;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : SingletonUI<GameMenu>
{
    // Start is called before the first frame update
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hightestScoreText;
    [Header("UI Loss")]
    public GameObject loadUI;
    public Button btnReplay;
    public Button btnHome;
    public TextMeshProUGUI txtScore;
    public TextMeshProUGUI txtHgScore;

    private void Start()
    {
        scoreText.text = "Score: 0";
        hightestScoreText.text = "Highest Score: " + GameData.Instance.hightestScore;
        btnReplay.onClick.AddListener(()=>SceneManager.LoadSceneAsync("Game"));
        btnHome.onClick.AddListener(()=>SceneManager.LoadSceneAsync("Game_choice"));
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

    public void LoadUILoss()
    {
        loadUI.SetActive(true);
        txtScore.text = scoreText.text;
        txtHgScore.text = hightestScoreText.text;
    }
    
}
