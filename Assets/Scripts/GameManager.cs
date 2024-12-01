using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Playing,
    GameOver
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject _gameOverCanvas;

    public GameState CurrentState { get; private set; } = GameState.Playing;

    private int _score = 0; // امتیاز کاربر
    public int Score => _score; // برای خواندن امتیاز

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (_gameOverCanvas != null)
        {
            _gameOverCanvas.SetActive(false); 
        }
    }

    public void AddScore(int value)
    {
        if (CurrentState == GameState.Playing)
        {
            _score += value;
            Debug.Log($"Score Updated: {_score}");
        }
    }

    public void GameOver()
    {
        if (CurrentState == GameState.Playing)
        {
            CurrentState = GameState.GameOver;
            Time.timeScale = 0f;
            _gameOverCanvas.SetActive(true); 
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
