using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed = 7f;
    [SerializeField] float groundDrag;

    [Header("Ground")]
    [SerializeField] float playerHeight;
    [SerializeField] LayerMask whatIsGround;
    bool isGrounded;

    [Header("Jumping")]
    [SerializeField] float jumpForce;
    [SerializeField] float jumpCooldown;
    [SerializeField] float airMultiplier;

    bool readyToJump = true;
    [HideInInspector] public bool isJumping;

    [HideInInspector] public float horizontalInput;
    [HideInInspector] public float verticalInput;

    [SerializeField] Transform orientation;

    Rigidbody rb;
    Vector3 moveDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        rb.linearDamping = isGrounded ? groundDrag : 0f;

        SpeedControl();

        if(readyToJump && isJumping && isGrounded)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        //calculate speed
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if (isGrounded)
        {
            rb.AddForce(moveDirection * moveSpeed * 10f, ForceMode.Force);
        } else if (!isGrounded)
        {
            rb.AddForce(moveDirection * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    public void UpdateInput(Vector2 move)
    {
        horizontalInput = move.x;
        verticalInput = move.y;
    }
    void SpeedControl()
    {
        Vector3 flatVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        if(flatVelocity.magnitude > moveSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitedVelocity.x, rb.linearVelocity.y, limitedVelocity.z);
        }
    }

    void Jump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void ResetJump()
    {
        readyToJump = true;
    }
}

