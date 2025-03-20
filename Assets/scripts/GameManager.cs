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
    private float finalSecondsToRestart = 3f;

    private float secondsToRestart = 5f;

    void Start()
    {
        onGameStart?.Invoke();
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
