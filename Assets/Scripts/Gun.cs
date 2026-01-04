using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Transform muzzle;
    [SerializeField] GameObject bulletPrefab;

    LayerMask playerLayer;
    int notPlayer;
    Camera cam;
    Vector3 targetPoint;
    void Start()
    {
        cam = Camera.main;

        playerLayer = LayerMask.GetMask("Player");
        notPlayer = ~playerLayer;
    }

    void Update()
    {
        Ray shootRay = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hitInfo;
        if(Physics.Raycast(shootRay, out hitInfo, 100, notPlayer))
        {
            targetPoint = hitInfo.point;
        }
        else
        {
            targetPoint = shootRay.GetPoint(100);
        }
    }

    public void Shoot() 
    {
        Vector3 shootDirection = (targetPoint - muzzle.position).normalized;
        Instantiate(bulletPrefab, muzzle.position, Quaternion.LookRotation(shootDirection));
    }
}
