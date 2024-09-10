using UnityEngine;

public class Gun_Shoot : MonoBehaviour
{
    public Transform playerTransform;
    public Transform firePoint;
    public int MaxAmmo;
    public int ammoCount;
    public float bulletForce;

    // Public references for different ammo types
    public GameObject ammoType1;
    public GameObject ammoType2;
    public GameObject ammoType3;
    public GameObject ammoType4;
    public GameObject ammoType5;
    public GameObject ammoType6;
    public GameObject ammoType7;

    private void Awake()
    {
        ammoCount = MaxAmmo;
        playerTransform = transform;
    }

    private void Update()
    {
        if (ammoCount > 0 && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
        }
    }

    public void Fire()
    {
        // Generate a random number between 1 and 100
        int randomNumber = Random.Range(1, 101);

        // Determine which ammo to use based on the random number
        GameObject ammoToFire = null;

        switch (randomNumber)
        {
            case int n when (n >= 1 && n <= 30):
                ammoToFire = ammoType1;
                break;
            case int n when (n >= 31 && n <= 50):
                ammoToFire = ammoType2;
                break;
            case int n when (n >= 51 && n <= 60):
                ammoToFire = ammoType3;
                break;
            case int n when (n >= 61 && n <= 70):
                ammoToFire = ammoType4;
                break;
            case int n when (n >= 71 && n <= 80):
                ammoToFire = ammoType5;
                break;
            case int n when (n >= 81 && n <= 90):
                ammoToFire = ammoType6;
                break;
            case int n when (n >= 91 && n <= 100):
                ammoToFire = ammoType7;
                break;
        }

        if (ammoToFire != null)
        {
            ShootBullet(ammoToFire, bulletForce);
        }
        else
        {
            Debug.Log("No ammo selected for the random number.");
        }
    }

    private void ShootBullet(GameObject ammoPrefab, float force)
    {
        GameObject bullet = Instantiate(ammoPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * force, ForceMode.Impulse);
        ammoCount--;
    }
}