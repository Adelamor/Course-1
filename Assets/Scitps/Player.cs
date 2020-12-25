using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D Rigidbody2D;
    [SerializeField] private int m_JumpPower = 10;

    private Vector2 m_StartSpeed;
    
    private void Start()    
    {
        m_StartSpeed = new Vector2(m_JumpPower,m_JumpPower);
        Rigidbody2D.velocity =m_StartSpeed;
    }

    private void Update()
    {
    }
    private void FixedUpdate()
    {
        var currentVelocity = Rigidbody2D.velocity;
        currentVelocity = currentVelocity.normalized * m_StartSpeed.magnitude;
        Rigidbody2D.velocity = currentVelocity;
    }
}