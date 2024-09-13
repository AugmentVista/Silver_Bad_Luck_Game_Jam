using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class Gun_Shoot : MonoBehaviour
{
    public Transform playerTransform;
    public Transform firePoint; // Transform just infront of the gun barrel
    public int maxAmmo; 
    public int ammoCount;
    public float fireRate; // This is the time between shots, a higher value will result in slower shooting
    public int luckModifier;
    public int timeSpentOverheated; // time in seconds
    public bool gunIsOverheated; // bool, cannot shoot while this is true

    private float force;
    private bool canFireAgain;

    public GameObject bulletAmmo;
    public GameObject pillowAmmo;
    public GameObject chickenAmmo;
    public GameObject lampAmmo;
    public GameObject skullAmmo;
    public GameObject deerAmmo;
    public GameObject busAmmo;
    public GameObject Overheated; // particle effect, does not operate under same rules as above GameObjects

    // Amount of force each ammo type is launched at, objects are heavier the further down the list they are
    public int bulletForce;
    public int pillowForce;
    public int chickenForce;
    public int lampForce;
    public int skullForce;
    public int deerForce;
    public int busForce;


    private void Start()
    {
        gunIsOverheated = false; // gun is not overheated when game starts
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
    private IEnumerator OverheatCoroutine()
    {
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        yield return new WaitForSeconds(timeSpentOverheated);
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        luckModifier++;
        gunIsOverheated = false;
    }

    public void Fire() // The type of shot that is fired is dependant on a random number
    {
        if (gunIsOverheated || !canFireAgain) 
        { 
            return; // returns if overheated or can't fire again
        } 

        StartCoroutine(FireRateCoroutine());

        int randomNumber = Random.Range(1, 101) + luckModifier;

        GameObject ammoToFire = null; // Reset the ammo to avoid repeats

        switch (randomNumber)
        {
            case int i when (i >= 1 && i <= 15):
                ammoToFire = bulletAmmo;
                force = bulletForce;
                break;
            case int i when (i >= 16 && i <= 30):
                ammoToFire =pillowAmmo;
                force = pillowForce;
                break;
            case int i when (i >= 31 && i <= 45):
                ammoToFire = chickenAmmo;
                force = chickenForce;
                break;
            case int i when (i >= 46 && i <= 60):
                ammoToFire = lampAmmo;
                force = lampForce;
                break;
            case int i when (i >= 61 && i <= 70):
                ammoToFire = skullAmmo;
                force = skullForce;
                break;
            case int i when (i >= 76 && i <= 81):
                ammoToFire = deerAmmo;
                force = deerForce;
                break;
            case int i when (i >= 82 && i <= 90):
                ammoToFire = busAmmo;
                force = busForce;
                break;
            case int i when (i > 91):
                ammoToFire = Overheated;
                gunIsOverheated = true;
                StartCoroutine(OverheatCoroutine());
                break;
        }

        if (ammoToFire != null && !gunIsOverheated)
        {
            ShootBullet(ammoToFire, force);
        }
        else if (ammoToFire == Overheated)
        {
            Overheat(ammoToFire);
        }
        else
        {
            Debug.Log("No ammo selected for the random number."); // this should only run if a number less than 1 is generated somehow
            Debug.Log(randomNumber + " is the random number");
        }
    }

    private void Overheat(GameObject ammoPrefab) // overheated is a particle effect and doesn't fire away from the gun
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