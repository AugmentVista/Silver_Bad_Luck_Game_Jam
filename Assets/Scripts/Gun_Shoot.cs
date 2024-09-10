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
    public List<int> normalAmmo = new List<int> { 1, 3, 5, 7, 13, 19, 23, 29, 39, 43, 47, 51, 55, 60, 63, 69, 70, 75, 77, 87, 90, 93, 98, 99, 100 };
    public float damageAmount = 10f; 

    private void Awake()
    {
        ammoCount = MaxAmmo;
        playerTransform = transform; 
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
            ShootBullet(bulletForce * 4); 
        }
    }

    public void Fire()
    {
        if (normalAmmo.Contains(ammoCount))
        {
            Debug.Log("Normal Ammo Shot");
            ShootBullet(bulletForce); 
        }
    }

    private void ShootBullet(float force)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * force, ForceMode.Impulse);
        ammoCount--;

        //Bullet bulletScript = bullet.GetComponent<Bullet>();
        //if (bulletScript != null)
        //{
        //    bulletScript.SetDamage(damageAmount); 
        //}
    }
}
