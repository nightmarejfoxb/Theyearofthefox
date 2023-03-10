using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    bool gameOver = false;
    int score = 0;
    public GameObject gameovertext;
    public TextMeshProUGUI textscore;

    private void Awake()
    {
        instance = this;
    }


    public void GameOver()
    {
        gameOver = true;

        gameovertext.SetActive(true);
    }

    public void Incrementscore()
    {
        if (!gameOver)
        {
            score++;
            textscore.text = score.ToString();

            print(score);
        }
    }

    public void restart()
    {
        SceneManager.LoadScene("play sence");
    }

    public void menu()
    {
        SceneManager.LoadScene("meun");
    }
}
