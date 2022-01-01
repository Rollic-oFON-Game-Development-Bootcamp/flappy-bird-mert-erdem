using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance ?? (_instance = FindObjectOfType<GameManager>());

    public UnityAction ActionGameStart, ActionGameOver;
    private int score = 0;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(gameObject);
    }

    #region UI Buttons' Methods
    public void StartGame()
    {
        ActionGameOver += SetHighScore;
        ActionGameStart?.Invoke();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    #endregion

    public void AddScore()
    {
        score++;
        CanvasController.Instance.SetInGameScoreText(score);
    }

    //action game over's method
    private void SetHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HIGH_SCORE", 0);

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HIGH_SCORE", highScore);
        }

        CanvasController.Instance.SetScoreTexts(score, highScore);
    }

    private void OnDestroy() => ActionGameOver -= SetHighScore;
}
