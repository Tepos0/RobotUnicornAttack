using UnityEngine;
using UnityEngine.Events;

public class DesactivateInSeconds : MonoBehaviour
{
    [SerializeField]
    private float _secondsToDesactivate = 5f;
    public UnityEvent<GameObject> onDesactivate;

    private void OnEnable()
    {
        Invoke("DesactivateObject", _secondsToDesactivate);
    }

    private void DesactivateObejct()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        onDesactivate?.Invoke(gameObject);
    }

}
