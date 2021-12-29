using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private GameObject canvasMenu, canvasGame, canvasEnd;

    private void Start()
    {
        GameManager.ActionGameOver += SetGameOverUI;
    }

    private void SetGameOverUI()
    {
        canvasGame.SetActive(false);
        canvasEnd.SetActive(true);
    }

    private void OnDestroy()
    {
        GameManager.ActionGameOver -= SetGameOverUI;
    }
}
