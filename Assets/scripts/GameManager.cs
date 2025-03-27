using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onGameStart;
    [SerializeField]
    private UnityEvent onRespawnGame;
    [SerializeField]

    private UnityEvent onFinishGame;
    [SerializeField]

    private UnityEvent onLoseGame;
    [SerializeField]
    private UnityEvent onShowGameOverScreen;
    [SerializeField]
    private float finalSecondsToRestart = 5f;

    private float secondsToRestart = 3f;

    private float secondsToShowGameOverScreen = 3f;

    void Awake()
    {
        secondsToRestart += secondsToShowGameOverScreen;
        finalSecondsToRestart += secondsToShowGameOverScreen;
    }

    void Start()
    {
        onGameStart?.Invoke();
    }

    public void LoseGame()
    {
        onLoseGame?.Invoke();
        Invoke("ShowGameOverScreen", secondsToRestart);
    }

    private void ShowGameOverScreen()
    {
        onShowGameOverScreen?.Invoke();
    }
    private void RestartGame()
    {
        onRespawnGame?.Invoke();
    }

    public void RespawnGame()
    {
        Invoke("RestartGame", secondsToRestart);
    }

    public void FinichGame()
    {
        onFinishGame?.Invoke();
        Invoke("StartGame", finalSecondsToRestart);
        Invoke("RestartGame", finalSecondsToRestart);
    }

}
