using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet")]
    [SerializeField] float speed;
    [SerializeField] float lifeTime;

    [Header("Bullet")]
    [SerializeField] float explosionForce;
    [SerializeField] float explosionRadius;
    [SerializeField] float upwardsModifier;

    Rigidbody rb;
    LayerMask bullet;
    int notBullet;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        bullet = LayerMask.GetMask("Bullet");
        notBullet = ~bullet;
    }
    void Start()
    {
        rb.linearVelocity = transform.forward * speed;
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Explode();
        Destroy(gameObject);
    }

    void Explode() 
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, notBullet);

        foreach (Collider collider in colliders) 
        {
            Rigidbody rbCollider = collider.GetComponent<Rigidbody>();
            
            if(rbCollider != null)
            {
                rbCollider.AddExplosionForce(explosionForce, transform.position, explosionRadius, upwardsModifier, ForceMode.Impulse);
            }
            else
            {
                rbCollider = collider.GetComponentInParent<Rigidbody>();
                if (rbCollider != null)
                {
                    rbCollider.AddExplosionForce(explosionForce, transform.position, explosionRadius, upwardsModifier, ForceMode.Impulse);
                }
            }
        }

    }

}
