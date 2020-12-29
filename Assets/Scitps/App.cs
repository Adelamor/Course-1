using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class App : MonoBehaviour
{
    public enum ScreenName
    {
        Menu,
        Game,
        Lose,
        Win
    }

    [Serializable]
    public class UIScreen
    {
        public ScreenName Name;
        public GameObject Screen;
    }
    
    public TextMeshProUGUI[] ScoreTexts;
    public TextMeshProUGUI TotalScoreText;
    public GameObject GamePrefab;

    [Space]
    public int ScoresToWin = 1;
    public UIScreen[] Screens;

    private GameObject m_Game;
    private Ball m_Ball;
    private int m_Scores;

    public int TotalScores {get {return PlayerPrefs.GetInt("TotalScores", 0);} set {PlayerPrefs.SetInt("TotalScores", value);}}

    private void Start()
    {
        Application.targetFrameRate = 60;
        GoToMenu();
        //SwitchUI(ScreenName.Menu);        
    }

    public void StartGame()
    {
        m_Scores = 0;
        UpdateScores();

        if(m_Game !=null)
        {
            Destroy(m_Game);
        }

        m_Game = Instantiate(GamePrefab, Vector3.zero, Quaternion.identity);
        m_Ball = FindObjectOfType<Ball>();

        m_Ball.OnTouchUpper += () => ChangeScores(1); 
        m_Ball.OnTouchBottom += () => ChangeScores(-1);
        SwitchUI(ScreenName.Game);
        AudioManager.Instance.PlaySoundByName("Click");        
    }
    public void GoToMenu()
    {
        if(m_Game !=null) Destroy(m_Game);
        SwitchUI(ScreenName.Menu);
        AudioManager.Instance.PlaySoundByName("Click");
        TotalScoreText.text = "Total Scores:" + TotalScores.ToString();
    }

    public void GameLose()
    {
        if(m_Game !=null) Destroy(m_Game);   
        SwitchUI(ScreenName.Lose);     
    }

    public void GameWin()
    {
        if(m_Game !=null) Destroy(m_Game);
        SwitchUI(ScreenName.Win);
    }

    private void SwitchUI(ScreenName screenName)
    {
        for (int i = 0; i < Screens.Length; i++)
        {
            var item = Screens[i];
            item.Screen.SetActive(item.Name == screenName);            
        }
    }

    private void ChangeScores (int value)
    {
        TotalScores += value;
        m_Scores += value;
        if (m_Scores <= 0) 
        {
            m_Scores = 0;
            GameLose();
        }
        
        else if(m_Scores >= ScoresToWin)
        {
            GameWin();
        }
        UpdateScores();
    }


    private void UpdateScores()
    {
        foreach (var item in ScoreTexts)
        {
            item.text = m_Scores.ToString();
        }
        
    }

}
