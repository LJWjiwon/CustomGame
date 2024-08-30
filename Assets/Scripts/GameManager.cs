using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gamemanager;
    public GameObject GameOverUI;
    public Text ScoreText;
    int score = 0;
    public bool isGameover = false;

    void Awake()
    {
        // 싱글톤 변수 instance가 비어있는가?
        if (gamemanager == null)
        {
            // instance가 비어있다면(null) 그곳에 자기 자신을 할당
            gamemanager = this;
        }
        else
        {
            // instance에 이미 다른 GameManager 오브젝트가 할당되어 있는 경우

            // 씬에 두개 이상의 GameManager 오브젝트가 존재한다는 의미.
            // 싱글톤 오브젝트는 하나만 존재해야 하므로 자신의 게임 오브젝트를 파괴
            Debug.LogWarning("씬에 두개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }

    public void Update()
    {
        if (isGameover)
        {
            if(Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(0);
            }
            
        }
    }

    public void PlayerDead()
    {
        GameOverUI.SetActive(true);
    }

    public void AddScore(int score)
    {
        this.score += score;
        ScoreText.text = "score: " + this.score.ToString();
    }
}
