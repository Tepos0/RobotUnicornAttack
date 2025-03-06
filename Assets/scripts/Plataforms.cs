using UnityEngine;
using UnityEngine.Events;

public class Plataforms : MonoBehaviour
{
    [SerializeField]
    private float initialSpeed = 2f;

    [SerializeField]
    private float speedIncrease = 0.1f;
    private bool canMove = true;
    public bool CanMove {set => canMove = value; }

    private Vector3 startingPosition;
    private float speed;
    private float duration =1f;
    [SerializeField]
    private float inactiveDuration =2f;
    [SerializeField]
    private UnityEvent onDash;
    [SerializeField]
    private UnityEvent onStopDash;

    private bool canDash = true;
    private bool IsDashing;
    public bool IsDashing{get => isDashing;}
    private bool dashEnabled = true;

    public void SetDashEnabled(bool enabled)
    {
        dashEnabled = enabled;
    }
    public void DashAction

    private void Start()
    {
        startingPosition = transform.position;
        speed = initialSpeed;
    }

    private void Update()
    {
        if (canMove)
        {
            MovePlatforms();
        }
    }

    private void MovePlatforms()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    public void IncreaseSpeed()
    {
        speed += speedIncrease;
    }

    public void StopMovement()
    {
        canMove = false;
    }
    public void StartMovement ()
    {
        canMove = true;
    }

    public void Restart()
    {
        transform.position = startingPosition;
        speed = initialSpeed;
        StartMovement();
    }

}
