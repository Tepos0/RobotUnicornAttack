using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private Text timerText;

    private int currentSeconds;
    public void StartTimer(int startSeconds)
    {
        currentSeconds = startSeconds;
        SetTimer();
    }

    private void SetTimer()
    {
        onSecondPassed?.Invoke();
        currentSeconds --;
        timerText.text = currentSeconds.ToString();
        if(currentSeconds >0)
        {
            Invoke("SetTimer", 1f);
        }
    }
}
