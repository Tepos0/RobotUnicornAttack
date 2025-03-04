using UnityEngine;
using UnityEngine.Events;

public class PlayerCollion : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onPlayerLose;
    private Dash dash;

    private void Start()
    {
        dash = GetComponent<Dash>();
    }

    private void OnllisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            if (dash.IsDashing)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                onPlayerLose?.Invoke();
            }
        }
        
    }
}
