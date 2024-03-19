using System;
using System.Collections;
using System.Collections.Generic;
using GameTool;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Lobby : MonoBehaviour
{
    public Button leftButton;
    public Button rightButton;
    public Button playButton;
    public Animator bird;
    private List<RuntimeAnimatorController> listAnimator; // taọ một list animator  
    private int id;

    private void Start()
    {
        listAnimator = GameData.Instance.listAnimators;
        id = 0;

    }

    private void OnEnable()
    {
       playButton.onClick.AddListener(call:(playGame));
       rightButton.onClick.AddListener(call:(nextButton));
       leftButton.onClick.AddListener(call:(backButton));
    }

    void nextButton()
    {
        id++;
        if (id > 3)
        {
            id = 0;
        }

        bird.runtimeAnimatorController = listAnimator[id]; // gán animator của bird thành animator số 0 trong list animator
    }

    void backButton()
    {
        id--;
        if (id < 0)
        {
            id = 3;
        }
        bird.runtimeAnimatorController = listAnimator[id];
    }
    public void playGame()
    {
        GameData.Instance.ID = id; //gán id trong GameData thành id của loppy
        LoadSceneManager.Instance.LoadScene("Game");
    }
    
}
