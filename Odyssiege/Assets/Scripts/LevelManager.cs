using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public enum GameState { MENU, ALIVE, WIN, DEAD, END };
    public GameState gameState;

    public int currentScene;

    private void Update()
    {
        // TODO : Change based on win condition implementation
    }

    // Win Condition
    // Assumes win condition is based on entering an invisible trigger wall at end of level (i.e. passes gate or something)
    void OnTriggerEnter2D(Collider2D collision) // TODO: Change based on win condition implementation
    {
        if (collision.gameObject.tag == "Finish")
        {
            WinLevel();
        }
    }

    private void Start()
    {
        currentScene = 0;
        gameState = GameState.MENU;
    }

    public void OnDeath()
    {
        gameState = GameState.DEAD;
        SceneManager.LoadScene(currentScene);
    }

    public void StartGame()
    {
        gameState = GameState.ALIVE;
        SceneManager.LoadScene(1); // Change depending on build/build order
    }

    public void WinLevel()
    {
        // TODO: Fanfare for winning level
        gameState = GameState.WIN;
        SceneManager.LoadScene(currentScene + 1);
    }

    public void EndGame()
    {
        gameState = GameState.END;
        // TODO: Give end game text, change to credits? Menu?
    }
}
