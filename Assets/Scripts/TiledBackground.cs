using UnityEngine;

public class TiledBackground : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.5f;
    private Renderer renderUsed;
    private Vector2 offset = Vector2.zero;
    private bool isMoving = true;
    public bool IsMoving 
    {
        get => isMoving;
        set 
        {
            isMoving=value;
        }
    }

    private void Start()
    {
        renderUsed = GetComponent<Renderer>();
    }
    private void Update()
    {
        if(isMoving) return;
        offset.x += speed * Time.deltaTime;
        renderUsed.material.mainTextureOffset = offset;
    }

}
