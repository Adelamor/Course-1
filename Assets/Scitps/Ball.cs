using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D Rigidbody2D;
    [SerializeField] private int m_Speed = 10;
    private Vector2 m_StartSpeed;
    public Action OnTouchBottom;
    public Action OnTouchUpper;

    private void Start()    
    {
        Rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        Restart();
    }
    private void FixedUpdate()
    {
        var currentVelocity = Rigidbody2D.velocity;
        currentVelocity = currentVelocity.normalized * m_StartSpeed.magnitude;
        Rigidbody2D.velocity = currentVelocity;
    }
    
    private void Restart()
    {
        var x = UnityEngine.Random.value > 0.5f ? m_Speed : -m_Speed;
        var y = UnityEngine.Random.value > 0.5f ? m_Speed : -m_Speed;
        m_StartSpeed = new Vector2(x,y);
        Rigidbody2D.velocity = m_StartSpeed;
        Rigidbody2D.position = Vector3.zero;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.gameObject.name == "Bottom")
        {
            if (OnTouchBottom !=null) OnTouchBottom();
            Restart();
        }        
        if (other.gameObject.gameObject.name == "Upper")
        {
            if (OnTouchBottom !=null) OnTouchUpper();
            Restart();
        }
    }
}