using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaoController : MonoBehaviour
{
    public Animator m_Animator;

    private int m_State = 0;
    private float m_Timer = 3f;
    private Vector2 m_MoveDirection = new Vector2();
    private Rigidbody2D m_Rigidbody;

    [Range(0f, 30f)]
    public float m_MoveSpeed = 10f;


    public enum Estate
    {
        Idle = 0,
        Up_Walk = 1,
        Down_Walk = 2,
        Left_Walk = 3,
        Right_Walk = 4
    }

    private Estate m_AnimState;

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
            m_Animator.SetInteger("State", 0);
        }
        else if(m_State == 1)
        {
            m_MoveDirection = transform.right;
            m_Animator.SetInteger("State", 4);
        }
        else if(m_State == 2)
        {
            m_MoveDirection = -transform.right;
            m_Animator.SetInteger("State", 3);
        }
        else if(m_State == 3)
        {
            m_MoveDirection = transform.up;
            m_Animator.SetInteger("State", 1);
        }
        else if(m_State == 4)
        {
            m_MoveDirection = -transform.up;
            m_Animator.SetInteger("State", 2);
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
        }
    }

    private void AnimationChao()
    {

    }
}
