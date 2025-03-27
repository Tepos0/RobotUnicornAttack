using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onPlayerLose;
    [SerializeField]

    private UnityEvent<Transform> onObstacleDestroyed;
    private Dash dash;

    private void Start()
    {
        dash = GetComponent<Dash>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (dash.IsDashing)
            {
                Destroy(collision.gameObject);
                onObstacleDestroyed?.Invoke(transform);
            }
            else
            {
                onPlayerLose?.Invoke();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeadZone"))
        {
            onPlayerLose?.Invoke();
        }
        
    }
}
