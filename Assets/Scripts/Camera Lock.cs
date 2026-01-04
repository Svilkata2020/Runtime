using UnityEngine;

public class CameraLock : MonoBehaviour
{
    public Transform lockGO;
    void Update()
    {
        transform.position = lockGO.position;
    }
}
