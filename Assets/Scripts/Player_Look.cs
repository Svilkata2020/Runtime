using UnityEngine;

public class Player_Look : MonoBehaviour
{
    public Camera playerCamera;
    private float xRotation = 0f;
    [SerializeField] private float xSens = 0.3f;
    [SerializeField] private float ySens = 0.2f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Look(Vector2 delta)
    {
        float mouseX = delta.x * xSens;
        float mouseY = delta.y * ySens;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        transform.Rotate(Vector2.up * mouseX);

    }
}
