using UnityEngine;
using UnityEngine.Events;
public class ObjectFromPool : MonoBehaviour
{
    public UnityEvent<GameObject> onDesactivate;
 
    private void OnDisable()
    {
        onDesactivate?.Invoke(gameObject);
    }
}
