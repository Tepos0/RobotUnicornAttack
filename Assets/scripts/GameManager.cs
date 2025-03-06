using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
   [SerializeField]
    private UnityEvent _onGameStart;
    [SerializeField]
    private UnityEvent onRespawnGame;

    private float secondsToRestart = 3f;

    void Start()
    {
        _onGameStart?.Invoke();
    }

    public void PlayerLose()
    {
        Invoke(nameof(RestartGame), secondsToRestart);
    }

    private void RestartGame()
    {
        onRespawnGame?.Invoke();
    }
}
