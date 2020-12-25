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

    [Range(0,1)]
    public float SpeedKof = 1;
    
    private Ball m_Ball;
    private Vector2 m_TargetPosition;

    public int Scores = 0;

    private void Start()
    {
        TextMeshProUGUI = GameObject.Find("ScroresText").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI.text = Scores.ToString();
        Rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        m_Ball = FindObjectOfType<Ball>();
    }
    private void FixedUpdate()
    {
        var targetPosition = new Vector3();

        if(PlayformType == PlayformType.Enemy) targetPosition = m_Ball.transform.position;    
        else if (PlayformType == PlayformType.Player) targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        Debug.Log($"{gameObject.name} {m_TargetPosition} {targetPosition} {SpeedKof}");
        m_TargetPosition = Vector3.Lerp(m_TargetPosition, targetPosition, SpeedKof);
        Debug.Log($"time {Time.deltaTime}");
        Rigidbody2D.MovePosition(m_TargetPosition);
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
