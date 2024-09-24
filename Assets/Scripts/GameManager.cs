using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[AddComponentMenu("MyGame / GameManager")]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Text m_text_life;
    public Text m_text_score;
    public Text m_text_best;
    public GameObject m_canvas_gameover;
    public GameObject Player;

    private int m_life = 3;
    public int m_score = 0;
    private int m_bestScore = 0;

    void Start()
    {
        Instance = this;
        m_bestScore = PlayerPrefs.GetInt("BestScore", 0);

        UpdateLifeText();

        var restart_button = m_canvas_gameover.transform.Find("Button_restart").GetComponent<Button>();
        restart_button.onClick.AddListener(delegate (){SceneManager.LoadScene(SceneManager.GetActiveScene().name);});
        Time.timeScale = 1;
        m_canvas_gameover.SetActive(false);
    }

    void Update()
    {
        if(Player != null)
        {
            m_life = Player.GetComponent<Player>().m_life;
        }
        else
        {
            return;
        }

        UpdateScoreText();
        UpdateBestScoreText();
    }

    public void AddScore(int point)
    {
        m_score += point;
        Debug.Log("Point: " + point.ToString());
    }

    public void UpdateLifeText()
    {
        m_text_life.text = "生命: " + Player.GetComponent<Player>().m_life.ToString();
    }

    public void UpdateScoreText()
    {
        m_text_score.text = "分数: " + m_score.ToString();
    }

    public void UpdateBestScoreText()
    {
        if (m_score > m_bestScore)
        {
             m_bestScore = m_score;
             PlayerPrefs.SetInt("BestScore", m_bestScore);
             PlayerPrefs.Save();
        }
        m_text_best.text = "最高分: " + m_bestScore.ToString();
    }

    public void DecreaseLife()
    {
        if (m_life > 0)
        {
            m_life--;
            UpdateLifeText();
            if (m_life <= 0)
            {
                GameOver();
            }
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0;

        m_canvas_gameover.SetActive(true);
    }
}
