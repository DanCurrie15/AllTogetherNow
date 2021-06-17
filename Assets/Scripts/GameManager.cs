using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [Header ("Balls")]
    public int numBalls = 5;
    public GameObject ball1;
    public GameObject ball2;
    public List<GameObject> Balls = new List<GameObject>();

    [Header("Paddles")]
    public GameObject paddle1;
    public GameObject paddle2;

    [Header("Score")]
    public int score = 0;
    public Text scoreText;

    [Header("Levels")]
    public GameObject invaderLevel1;
    public Button level1Btn;
    public GameObject invaderLevel2;
    public Button level2Btn;

    [Header("UI Panels")]
    public GameObject startPanel;
    public GameObject gameOverPanel;
    public Text gameOverText;

    [Header("Walls")]
    public GameObject WallVert1;
    public GameObject WallVert2;
    public GameObject WallHort1;

    [Header("Game Bools")]
    public bool gameOn = false;
    public bool isBreaker = true;

    [Header("Cannon")]
    public GameObject cannon;

    void Start()
    {
        ScoreOrLossPoints(0);
        OnLevelBtnPress(1);
    }

    void Update()
    {
        if(!gameOn && Input.GetKeyDown(KeyCode.Space) && !startPanel.activeInHierarchy)
        {
            gameOn = true;
            ball1.GetComponent<BallController>().Launch();
            ball2.GetComponent<BallController>().Launch();
        }
    }

    public void LoseBall()
    {        
        if (numBalls > 0)
        {
            --numBalls;
            Balls[numBalls].gameObject.SetActive(false);
        }
        
        if (numBalls > 0 && !ball1.activeInHierarchy)
        {
            ball1.transform.position = new Vector3(paddle1.transform.position.x - 1f, paddle1.transform.position.y, 0f);
            ball1.SetActive(true);
            ball1.GetComponent<BallController>().Launch();
        }
        else if (numBalls > 0 && !ball2.activeInHierarchy)
        {
            ball2.transform.position = new Vector3(paddle2.transform.position.x + 1f, paddle2.transform.position.y, 0f);
            ball2.SetActive(true);
            ball2.GetComponent<BallController>().Launch();
        }
        else if (numBalls < 1 && !ball1.activeInHierarchy && !ball2.activeInHierarchy)
        {
            // Game Over :(
            GameOver(false);
        }
    }

    public void GameOver(bool win)
    {
        gameOverPanel.SetActive(true);
        gameOn = false;
        if (win)
        {
            gameOverText.text = "A WINNER IS YOU :D";
        }
        else
        {
            gameOverText.text = "OH NO :(\nTRY AGAIN?";
        }
    }

    public void ScoreOrLossPoints(int points)
    {
        score = score + points;
        scoreText.text = "SCORE: " + score.ToString("00000");
        if (isBreaker && points > 0)
        {
            cannon.GetComponent<CannonControler>().FadeIn();
        }        
    }

    public void HideStartPanel()
    {
        startPanel.SetActive(false);
    }

    public void OnLevelBtnPress(int btn)
    {
        if (btn == 1)
        {
            invaderLevel1.SetActive(true);
            invaderLevel2.SetActive(false);
            level1Btn.Select();
        }
        else
        {
            invaderLevel1.SetActive(false);
            invaderLevel2.SetActive(true);
            level2Btn.Select();
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene("GAME");
    }

    public void InvaderMode()
    {
        isBreaker = false;
        WallHort1.SetActive(false);
        WallVert1.SetActive(true);
        WallVert2.SetActive(true);
        ball1.SetActive(false);
        ball2.SetActive(false);
    }

    public void BreakoutMode()
    {
        isBreaker = true;
        WallHort1.SetActive(true);
        WallVert1.SetActive(false);
        WallVert2.SetActive(false);

        ball1.transform.position = new Vector3(paddle1.transform.position.x - 1f, paddle1.transform.position.y, 0f);
        ball1.SetActive(true);
        ball1.GetComponent<BallController>().Launch();

        ball2.transform.position = new Vector3(paddle2.transform.position.x + 1f, paddle2.transform.position.y, 0f);
        ball2.SetActive(true);
        ball2.GetComponent<BallController>().Launch();
    }
}
