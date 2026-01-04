using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX = 100f;
    public float sensY = 100f;
    float mouseX = 0f;
    float mouseY = 0f;

    public Transform orientation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void Look(Vector2 delta)
    {
        mouseX -= delta.y * sensY * 0.01f;
        mouseY += delta.x * sensX * 0.01f;

        mouseX = Mathf.Clamp(mouseX, -90f, 90f);

        transform.rotation = Quaternion.Euler(mouseX, mouseY, transform.rotation.z);
        orientation.rotation = Quaternion.Euler(orientation.rotation.x, mouseY, orientation.rotation.z);
    }
}
