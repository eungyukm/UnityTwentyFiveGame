using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    public int gameNuber = 1;

    public enum GameState
    {
        Menu,
        InGame,
        GameOver
    }

    public GameState gameState = GameState.Menu;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TenTimer());
    }

    IEnumerator TenTimer()
    {
        yield return new WaitForSeconds(10f);
        GameOverState();
    }

    public bool IsGameOver(int clickNumber)
    {
        return gameNuber != clickNumber;
    }

    public void InCreasingGameNumber()
    {
        gameNuber++;

        if(gameNuber == 25)
        {
            GameOverState();
        }
    }

    public void GameStartState()
    {
        gameState = GameState.InGame;
    }

    public void GameOverState()
    {
        gameState = GameState.GameOver;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
