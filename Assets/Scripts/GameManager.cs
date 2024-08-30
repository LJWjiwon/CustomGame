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
        // �̱��� ���� instance�� ����ִ°�?
        if (gamemanager == null)
        {
            // instance�� ����ִٸ�(null) �װ��� �ڱ� �ڽ��� �Ҵ�
            gamemanager = this;
        }
        else
        {
            // instance�� �̹� �ٸ� GameManager ������Ʈ�� �Ҵ�Ǿ� �ִ� ���

            // ���� �ΰ� �̻��� GameManager ������Ʈ�� �����Ѵٴ� �ǹ�.
            // �̱��� ������Ʈ�� �ϳ��� �����ؾ� �ϹǷ� �ڽ��� ���� ������Ʈ�� �ı�
            Debug.LogWarning("���� �ΰ� �̻��� ���� �Ŵ����� �����մϴ�!");
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
