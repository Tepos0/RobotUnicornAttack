using UnityEngine;

public class Jump : MonoBehaviour
{
  [SerializeField]
   private float _jumpForce = 10f;

   [SerializeField]
   private float _maxJumpTime = 0.3f;

   [SerializeField]

   private float _jumpBoost = 0.5f;

   private Rigidbody rb;
   private bool _isGrounded;
   private bool _isJumping;
   private float _jumpTimeCounter;
   private bool _buttonPressed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void StartJump()
    {
        _buttonPressed=true;
        if (_isGrounded)
        {
            _isJumping=true;
            _jumpTimeCounter = _maxJumpTime;
            rb.linearVelocity=Vector3.up*_jumpForce;
            _isGrounded=false;
        }
    }
        public void EndJump()
        {
            _buttonPressed=false;
        }

    private void FixedUpdate()
    {
        HandleJump();
    }

    private void HandleJump()
    {
        if (_buttonPressed && _isJumping)
        {
            if(_jumpTimeCounter>0)
            {
                rb.linearVelocity=Vector3.up*(_jumpForce+_jumpBoost);
                _jumpTimeCounter-=Time.fixedDeltaTime;
            }
            else 
            {
                _isJumping=false;
            }
        }
    }

    private void OllisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded=true;
        }
        
    }



}
