using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[AddComponentMenu("MyGame / Enemy")]
public class Enemy : MonoBehaviour
{
    public float m_speed = 1;
    protected float m_rotSpeed = 30;
    public float m_life = 10;
    internal Renderer m_renderer;
    internal bool m_isActiv = false;
    public int m_point = 10;
    public Transform m_explosionFX;
    public int m_score = 10;

    // Start is called before the first frame update
    void Start()
    {
        m_renderer = this.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMove();
        if(m_isActiv && !this.m_renderer.isVisible)
        {
            Destroy(this.gameObject);
        }
    }

    protected virtual void UpdateMove()
    {
        float rx = Mathf.Sin(Time.time) * Time.deltaTime;
        transform.Translate(new Vector3 (rx, 0, -m_speed * Time.deltaTime));
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerRocket")
        {
            Rocket rocket = other.GetComponent<Rocket>();
            if(rocket != null)
            {
                m_life -= rocket.m_power;
                if(m_life <= 0)
                {
                    Destroy(this.gameObject);
                }
            }
        }
        else if(other.tag == "Player")
        {
            m_life = 0;
            Destroy(this.gameObject);
        }

        if(m_life <= 0)
        {
            Destroy(this.gameObject);
            GameManager.Instance.AddScore(m_point);
        }
    }

    private void OnBecameVisible()
    {
        m_isActiv = true;
    }
}
