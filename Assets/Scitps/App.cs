using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class App : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public GameObject GamePrefab;

    private GameObject m_Game;
    private Ball m_Ball;
    private int m_Scores;

    void Start()
    {
        Application.targetFrameRate = 60;
        RestartGame();
        UpdateScores();
    }
    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }
    public void RestartGame()
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
    }
    private void ChangeScores (int value)
    {
        m_Scores += value;
        if (m_Scores <= 0) m_Scores = 0;
        UpdateScores();
    }


    private void UpdateScores()
    {
        ScoreText.text = m_Scores.ToString();
    }

}
