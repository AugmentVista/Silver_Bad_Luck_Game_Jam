using TMPro;
using UnityEngine;
public class Gun_Shoot : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject bulletPrefab;
    public Transform firePoint;

    public int ammoCount = 10;
    public float bulletForce = 10;

    private void Awake()
    {
        playerTransform = transform;
    }

    private void Update()
    {
        if (ammoCount > 0 && Input.GetKeyDown(KeyCode.E))
        {
            Fire();
        }
    }

    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
        ammoCount--;
    }
}