using UnityEngine;
using UnityEngine.Events;

public class Dash : MonoBehaviour
{
    [SerializeField]
    private float duration = 0.5f;

    [SerializeField]
    private float inactiveDuration = 2F;

    [SerializeField]
    private UnityEvent onDash;
    private bool canDash = true;

    [SerializeField]
    private UnityEvent onStopDash;
    private bool isDashing;
    public bool IsDashing {get => isDashing;}

    public void DashAction()
    {
        if(isDashing)
        {
            onDash?.Invoke();
            isDashing = true;
            Invoke(nameof(StopDash), duration);
        }
    }

    private void StopDash()
    {
        onStopDash?.Invoke();
        isDashing = false;
        Invoke(nameof(EnableDash), inactiveDuration);
    }

    private void EnableDash()
    {
        canDash = true;
    }
}
