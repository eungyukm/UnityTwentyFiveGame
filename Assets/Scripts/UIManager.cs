using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject menuUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject inGameUI;

    [SerializeField] private Text score;
    [SerializeField] private Text time;
    // Start is called before the first frame update
    void Start()
    {
        init();
    }

    private void init()
    {
        menuUI.SetActive(true);
        gameOverUI.SetActive(false);
        inGameUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        menuUI.SetActive(false);
        inGameUI.SetActive(true);
        GameManager.Instance.GameStartState();
    }

    public void GameRetry()
    {
        gameOverUI.SetActive(false);
        GameManager.Instance.GameStartState();

        SceneManager.LoadScene("TwentyFive");
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        SetScore();
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void SetScore()
    {
        int count = GameManager.Instance.gameNuber - 1;
        score.text = count.ToString();
    }

    public void SetTimer(int timer)
    {
        time.text = timer.ToString();
    }
}
