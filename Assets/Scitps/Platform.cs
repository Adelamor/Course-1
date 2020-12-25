using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum PlayformType
{
        Player,
        Enemy
}

public class Platform : MonoBehaviour
{    
    public PlayformType PlayformType;
    public Rigidbody2D Rigidbody2D;
    public TextMeshProUGUI TextMeshProUGUI;
    public int Scores = 0;
    private Ball m_Ball;

    private void Start()
    {
        TextMeshProUGUI = GameObject.Find("ScroresText").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI.text = Scores.ToString();
        Rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        m_Ball = FindObjectOfType<Ball>();
    }
    private void FixedUpdate()
    {
        if(PlayformType == PlayformType.Enemy)
        {
            var ballPosition = m_Ball.transform.position;
            Rigidbody2D.MovePosition(ballPosition);
            Debug.Log("Enemy");
        }
        else if (PlayformType == PlayformType.Player)
        {
            var worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
            Rigidbody2D.MovePosition(worldMousePosition);
            Debug.Log("Player");
        }
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.GetComponent<Ball>() != null)
        {
            Scores++;
            TextMeshProUGUI.text = Scores.ToString();
        }        
    }
}
