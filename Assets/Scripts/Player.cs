using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[AddComponentMenu("MyGame / Player")]
public class Player : MonoBehaviour
{
    public float m_speed = 1;
    public Transform m_roctet;
    public Transform m_transform;
    float m_rocketTimer = 0;
    public int m_life = 3;
    public AudioClip m_shootClip;
    protected AudioSource m_audio;
    public Transform m_explosionFX;

    // Start is called before the first frame update
    void Start()
    {
        m_transform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float movev = 0;
        float moveh = 0;

        if(Input.GetKey(KeyCode.W))
        {
            movev += m_speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.S))
        {
            movev -= m_speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.A))
        {
            moveh -= m_speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.D))
        {
            moveh += m_speed * Time.deltaTime;
        }

        this.transform.Translate(new Vector3(moveh, 0, movev));

        m_rocketTimer -=Time.deltaTime;
        if(m_rocketTimer <= 0)
        {
            m_rocketTimer = 0.1f;
            if(Input.GetKey(KeyCode.Space)|| Input.GetMouseButton(0))
            {
                Instantiate(m_roctet, transform.position, transform.rotation);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" || other.tag == "EnemyRocket")
        {
            m_life -= 1;

            GameManager.Instance.UpdateLifeText();

            if(m_life <= 0)
            {
                Destroy(this.gameObject);
                GameManager.Instance.DecreaseLife();
            }
        }
    }
}
