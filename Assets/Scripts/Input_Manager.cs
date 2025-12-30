using UnityEngine;

public class Input_Manager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;

    private Player_Motor motor;
    private Player_Look look;

    public Gun gun;

    void Awake()
    {
        //new player input actions
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;

        //getting all references
        motor = GetComponent<Player_Motor>();
        look = GetComponent<Player_Look>();
    }
    void Start()
    {
        onFoot.Enable();
        onFoot.Move.performed += ctx => motor.moveInput = ctx.ReadValue<Vector2>();
        onFoot.Move.canceled += ctx => motor.moveInput = Vector2.zero;

        onFoot.Jump.started += ctx => motor.isJumping = true;
        onFoot.Jump.canceled += ctx => motor.isJumping = false;

        onFoot.Shoot.started += ctx => gun.Shoot();

    }

    void Update()
    {
        motor.Move();
    }

    void LateUpdate()
    {
        look.Look(onFoot.Look.ReadValue<Vector2>());
    }

    void OnEnable()
    {
        onFoot.Enable();
    }

    void OnDisable()
    {
        onFoot.Disable();
    }
}
