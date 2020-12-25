using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour
{
    public GameObject GamePrefab;
    private GameObject m_Game;
    private Ball m_Ball;
    void Start()
    {
        Application.targetFrameRate = 60;
        RestartGame();
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
        if(m_Game !=null)
        {
            Destroy(m_Game);
        }
        m_Game = Instantiate(GamePrefab, Vector3.zero, Quaternion.identity);
        m_Ball = FindObjectOfType<Ball>();

        m_Ball.OnTouchBottom += RestartGame;
    }

}
