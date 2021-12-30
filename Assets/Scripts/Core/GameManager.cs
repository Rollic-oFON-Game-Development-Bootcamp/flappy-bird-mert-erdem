using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static UnityAction ActionGameStart, ActionGameOver;

    //UI button's method
    public void StartGame()
    {
        ActionGameStart?.Invoke();
    }

    //UI button's method
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
