using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlatformsTrigger : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onPlatformTriggered;
    private void OriggerEnter(Collider other)
    {
        if (other.CompareTag("DeadZone"))
        {
            Destroy(other.gameObject);
            onPlatformTriggered?.Invoke();
        }
        
    }

}
