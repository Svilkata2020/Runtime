using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject muzzle;
    private Camera cam;


    private Vector3 shootPoint;
    private Vector3 shootDirection;
    private LayerMask notPlayer;


    private void Start()
    {
        cam = Camera.main;

        int playerLayer = LayerMask.NameToLayer("Player");
        notPlayer = ~(1 << playerLayer);
    }

    private void Update()
    {
        Ray shootRay = new Ray(cam.transform.position, cam.transform.TransformDirection(Vector3.forward));
        RaycastHit hitInfo;
        if(Physics.Raycast(shootRay, out hitInfo, 100, notPlayer))
        {
            shootPoint = hitInfo.point;
        }
        else
        {
            shootPoint = shootRay.GetPoint(100);
        }
    }

    public void Shoot() 
    {
        shootDirection = (shootPoint - muzzle.transform.position).normalized;
        Instantiate(bulletPrefab, muzzle.transform.position, Quaternion.LookRotation(shootDirection));
    }
}
