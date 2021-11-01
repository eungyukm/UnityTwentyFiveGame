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

    [SerializeField] private UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    IEnumerator TenTimer()
    {
        int time = 0;
        uiManager.SetTimer(time);
        while (time < 10)
        {
            yield return new WaitForSeconds(1f);
            time++;
            uiManager.SetTimer(time);
        }

        GameOverState();
    }

    public bool IsGameOver(int clickNumber)
    {
        Debug.Log($"GameNuber :{gameNuber} 선택 : {clickNumber}");
        return gameNuber != clickNumber;
    }

    public void InCreasingGameNumber()
    {
        Debug.Log("Game Nuber 증가!");
        gameNuber++;

        if(gameNuber == 25)
        {
            GameOverState();
        }
    }

    public void GameStartState()
    {
        gameState = GameState.InGame;
        gameNuber = 1;
        StartCoroutine(TenTimer());
    }

    public void GameOverState()
    {
        gameState = GameState.GameOver;
        uiManager.GameOver();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
