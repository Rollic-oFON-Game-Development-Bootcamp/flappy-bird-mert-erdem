using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private GameObject canvasMenu, canvasGame, canvasEnd;

    private void Start()
    {
        GameManager.ActionGameOver += SetGameOverUI;
        GameManager.ActionGameStart += SetGameUI;
    }

    private void SetGameUI()
    {
        canvasMenu.SetActive(false);
        canvasGame.SetActive(true);
    }

    private void SetGameOverUI()
    {
        canvasGame.SetActive(false);
        canvasEnd.SetActive(true);
    }

    private void OnDestroy()
    {
        GameManager.ActionGameOver -= SetGameOverUI;
        GameManager.ActionGameStart -= SetGameUI;
    }
}
