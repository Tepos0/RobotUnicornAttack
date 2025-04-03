using UnityEngine;

public class ActivateObjects : MonoBehaviour
{
    [SerializeField]
    private GameObject [] objectsToActivate;

    private void Onable()
    {
        ActivateAllObjects();
    }

    private void ActivateAllObjects()
    {
        foreach (GameObject obj in objectsToActivate);
    }

}
