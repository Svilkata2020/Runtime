using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerActions playerInput;
    PlayerActions.OnFootActions onFoot;

    //references
    [SerializeField] PlayerCam playerCamera;
    [SerializeField] Gun gun;
    private Movement movement;

    private void Awake()
    {
        playerInput = new PlayerActions();
        onFoot = playerInput.OnFoot;
    }

    private void Start()
    {
        movement = GetComponent<Movement>();

        onFoot.Jump.started += ctx => movement.isJumping = true;
        onFoot.Jump.canceled += ctx => movement.isJumping = false;
        onFoot.Shoot.started += ctx => gun.Shoot();
    }

    private void Update()
    {
        playerCamera.Look(onFoot.Look.ReadValue<Vector2>());
        movement.UpdateInput(onFoot.Move.ReadValue<Vector2>());
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
