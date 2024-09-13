using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class Gun_Shoot : MonoBehaviour
{
    public Transform playerTransform;
    public Transform firePoint;
    public int maxAmmo;
    public int ammoCount;
    public float fireRate;
    public int luckModifier;
    public int timeSpentOverheated;
    public bool gunIsOverheated;

    private float force;
    private bool canFireAgain;

    public GameObject bulletAmmo;
    public GameObject pillowAmmo;
    public GameObject chickenAmmo;
    public GameObject lampAmmo;
    public GameObject skullAmmo;
    public GameObject deerAmmo;
    public GameObject busAmmo;
    public GameObject Overheated;

    public int bulletForce;
    public int pillowForce;
    public int chickenForce;
    public int lampForce;
    public int skullForce;
    public int deerForce;
    public int busForce;


    private void Start()
    {
        gunIsOverheated = false;
        canFireAgain = true;
        ammoCount = maxAmmo;
        playerTransform = transform;
    }

    private void Update()
    {
        if (ammoCount > 0 && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
        }
    }

    private IEnumerator FireRateCoroutine()
    {
        yield return new WaitForSeconds(fireRate);
        canFireAgain = true;
    }

    public void Fire()
    {
        if (gunIsOverheated || !canFireAgain) { return; }
        StartCoroutine(FireRateCoroutine());

        int randomNumber = Random.Range(1, 101) + luckModifier;

        Debug.Log(randomNumber);

        GameObject ammoToFire = null;

        switch (randomNumber)
        {
            case int i when (i >= 1 && i <= 30):
                ammoToFire = bulletAmmo;
                force = bulletForce;
                break;
            case int i when (i >= 31 && i <= 50):
                ammoToFire =pillowAmmo;
                force = pillowForce;
                break;
            case int i when (i >= 51 && i <= 60):
                ammoToFire = chickenAmmo;
                force = chickenForce;
                break;
            case int i when (i >= 61 && i <= 70):
                ammoToFire = lampAmmo;
                force = lampForce;
                break;
            case int i when (i >= 71 && i <= 80):
                ammoToFire = skullAmmo;
                force = skullForce;
                break;
            case int i when (i >= 81 && i <= 90):
                ammoToFire = deerAmmo;
                force = deerForce;
                break;
            case int i when (i >= 91 && i <= 100):
                ammoToFire = busAmmo;
                force = busForce;
                break;
            case int i when (i > 100):
                ammoToFire = Overheated;
                gunIsOverheated = true;
                break;
        }

        if (ammoToFire != null && !gunIsOverheated)
        {
            ShootBullet(ammoToFire, force);
        }
        else if (ammoToFire == Overheated)
        {
            Overheat(ammoToFire);
            gunIsOverheated = true;
            StartCoroutine(OverheatCoroutine());
            
            IEnumerator OverheatCoroutine()
            {
                Debug.Log("Started Coroutine at timestamp : " + Time.time);
                yield return new WaitForSeconds(timeSpentOverheated);
                Debug.Log("Finished Coroutine at timestamp : " + Time.time);
                luckModifier++;
                gunIsOverheated = false;
            }
        }
        else
        {
            Debug.Log("No ammo selected for the random number.");
            Debug.Log(randomNumber + " is the random number");
        }
    }

    private void Overheat(GameObject ammoPrefab)
    {
        GameObject bullet = Instantiate(ammoPrefab, firePoint.position, firePoint.rotation);
        bullet.transform.parent = firePoint.transform;
        ammoCount--;
    }

    private void ShootBullet(GameObject ammoPrefab, float force)
    {
        GameObject bullet = Instantiate(ammoPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * force, ForceMode.Impulse);
        ammoCount--;
        canFireAgain = false;
    }
}