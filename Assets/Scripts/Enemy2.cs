using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("MyGame / Enemy2")]
public class Enemy2 : Enemy
{
    public Transform m_rocket;
    protected float m_fireTimer = 2;
    protected Transform m_player;

    // Start is called before the first frame update
    void Start()
    {
        m_renderer = this.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMove();
        if (m_isActiv && !this.m_renderer.isVisible)
        {
            Destroy(this.gameObject);
        }
    }

    protected override void UpdateMove()
    {
        m_fireTimer -= Time.deltaTime;
        if(m_fireTimer <= 0 )
        {
            m_fireTimer = 2;
            if(m_player != null )
            {
                Vector3 relativePos = m_player.position - transform.position;
                Instantiate(m_rocket, transform.position, Quaternion.LookRotation(relativePos));
            }
            else
            {
                GameObject obj = GameObject.FindGameObjectWithTag("Player");
                if(obj != null)
                {
                    m_player = obj.transform;
                }
            }
        }
        transform.Translate(new Vector3(0, 0, -m_speed * Time.deltaTime));
    }
}
