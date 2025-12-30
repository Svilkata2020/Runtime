using UnityEngine;

public class Player_Motor : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float gravity = -10f;
    [SerializeField]
    private float jumpForce = 7f;

    private float yVelocity = 0f;
    private bool isGrounded;


    CharacterController player;

    public Vector2 moveInput;
    public bool isJumping;

    private void Awake()
    {
        player = GetComponent<CharacterController>();
    }



    void Update()
    {
        //checks if player is on ground
        isGrounded = player.isGrounded;

        //applies gravity and jumping logic
        if (isGrounded && yVelocity < 0f)
        {
            yVelocity = -2f;
        }
        if (isJumping && isGrounded)
        {
            yVelocity = jumpForce;
        }
        yVelocity += gravity * Time.deltaTime;
    }

    //moving function
    public void Move()
    {
        Vector3 direction = transform.TransformDirection(moveInput.x, 0, moveInput.y);
        Vector3 delta = direction * speed;
        delta.y = yVelocity;
        player.Move(delta * Time.deltaTime);
    }
}
