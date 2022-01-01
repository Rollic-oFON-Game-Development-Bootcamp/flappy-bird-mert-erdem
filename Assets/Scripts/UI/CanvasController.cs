using UnityEngine;
using TMPro;

public class CanvasController : MonoBehaviour
{
    private static CanvasController _instance;
    public static CanvasController Instance => _instance ?? (_instance = FindObjectOfType<CanvasController>());

    [SerializeField] private GameObject canvasMenu, canvasGame, canvasEnd;
    [SerializeField] private TextMeshProUGUI textScore, textBest, textInGameScore;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        GameManager.Instance.ActionGameOver += SetGameOverUI;
        GameManager.Instance.ActionGameStart += SetGameUI;
    }

    //action game start's method
    private void SetGameUI()
    {
        canvasMenu.SetActive(false);
        canvasGame.SetActive(true);
    }

    //action game over's method
    private void SetGameOverUI()
    {
        canvasGame.SetActive(false);
        canvasEnd.SetActive(true);
    }

    public void SetScoreTexts(int score, int best)
    {
        textScore.text += score.ToString();
        textBest.text += best.ToString();
    }

    public void SetInGameScoreText(int score)
    {
        textInGameScore.text = score.ToString();
    }

    private void OnDestroy()
    {
        GameManager.Instance.ActionGameOver -= SetGameOverUI;
        GameManager.Instance.ActionGameStart -= SetGameUI;
    }
}
