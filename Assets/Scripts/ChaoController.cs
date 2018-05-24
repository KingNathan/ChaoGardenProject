using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaoController : MonoBehaviour
{
    private int m_State = 0;
    private float m_Timer = 3f;
    private Vector2 m_MoveDirection = new Vector2();
    private Rigidbody2D m_Rigidbody;

    [Range(0f, 30f)]
    public float m_MoveSpeed = 10f;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ChaoBehavior();
        StateUpdate();
    }

    private void ChaoBehavior()
    {
        if(m_State == 0)
        {
            m_MoveDirection = Vector2.zero;
        }else if(m_State == 1)
        {
            m_MoveDirection = transform.right;
        }else if(m_State == 2)
        {
            m_MoveDirection = -transform.right;
        }else if(m_State == 3)
        {
            m_MoveDirection = transform.up;
        }else if(m_State == 4)
        {
            m_MoveDirection = -transform.up;
        }

        m_MoveDirection *= m_MoveSpeed;
        m_Rigidbody.velocity = m_MoveDirection;
    }

    private void StateUpdate()
    {
        if (m_Timer > 0)
        {
            m_Timer -= Time.deltaTime;
        }
        else if (m_Timer <= 0)
        {
            m_State = Random.Range(0, 5);
            m_Timer = 3f;
            Debug.Log(m_State);
        }
    }
}
