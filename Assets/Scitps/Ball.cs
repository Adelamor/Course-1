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
    private void Start()    
    {
        Rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        m_StartSpeed = new Vector2(m_Speed,m_Speed);
        Rigidbody2D.velocity = m_StartSpeed;
    }
    private void FixedUpdate()
    {
        var currentVelocity = Rigidbody2D.velocity;
        currentVelocity = currentVelocity.normalized * m_StartSpeed.magnitude;
        Rigidbody2D.velocity = currentVelocity;
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.gameObject.name == "Bottom")
        {
            if (OnTouchBottom !=null) OnTouchBottom();
        }        
    }
}