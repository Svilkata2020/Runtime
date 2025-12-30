using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;

    void Start()
    {
        Destroy(gameObject, 5);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
