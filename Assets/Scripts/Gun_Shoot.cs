using System.Collections.Generic;
using UnityEngine;
public class Gun_Shoot : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject bulletPrefab;
    public Transform firePoint;

    public int MaxAmmo;
    public int ammoCount;
    public float bulletForce;

    List<int> normalAmmo = new List<int> { 1, 3, 5, 7, 13, 19, 23, 29, 39, 43, 47, 51, 55, 60, 63, 69, 70, 75, 77, 87, 90, 93, 98, 99, 100 };
   
    private void Awake()
    {
        playerTransform = transform;
        MaxAmmo = ammoCount;
    }

    private void Update()
    {

        if (ammoCount > 0 && Input.GetKeyDown(KeyCode.E))
        {
            if (!normalAmmo.Contains(ammoCount))
            {
                SillyAmmoCheck();
            }
            else if (normalAmmo.Contains(ammoCount))
            {
                Fire();
            }
            else
            {
                Debug.Log("Out of ammo");
            }
        }
    }
    private void SillyAmmoCheck()
    {
        if (!normalAmmo.Contains(ammoCount))
        {
            Debug.Log("Silly Ammo Shot");
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(firePoint.forward * bulletForce/4, ForceMode.Impulse);
            ammoCount--;
        }
    }

    public void Fire()
    {
        if (normalAmmo.Contains(ammoCount))
        {
            Debug.Log("normal ammo shot");
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
            ammoCount--;
        }
    }
}