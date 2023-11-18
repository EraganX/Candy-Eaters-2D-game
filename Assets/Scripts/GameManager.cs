using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    int score = 0;
    bool gameOver = false; 
    public TMP_Text ScoreText;
    int lifes = 3;

    public GameObject lifeHolder;
    public GameObject gameOverPanel;

    private void Awake()
    {
        instance = this;
        gameOverPanel.SetActive(false);
    }

    public void IncrementScore()
    {
        if (gameOver == false)
        {
            score++;
            ScoreText.text = score.ToString();
        }
         
    }

    public void DecreaseLife()
    {
        if (lifes>1)
        {
            lifes--;
            lifeHolder.transform.GetChild(lifes).gameObject.SetActive(false);
        }
        else
        {
            lifeHolder.transform.GetChild(lifes-1).gameObject.SetActive(false);
            gameOver = true;
            GameOver();
        }
    }


    public void GameOver()
    {
        CandySpawnerScript.Instance.StopSpawningCandy();
        GameObject.Find("Player").GetComponent<PlayerController>().canmove= false;
        gameOverPanel.SetActive(true);
        print("Game Over");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
