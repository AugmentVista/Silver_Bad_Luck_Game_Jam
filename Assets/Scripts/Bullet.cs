using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damageAmount;

    private void OnCollisionEnter(Collision collision)
    {
        DamageInterface damageable = collision.gameObject.GetComponent<DamageInterface>();
        if (damageable != null)
        {
            damageable.TakeDamage(damageAmount);
        }

        Destroy(gameObject, 15f);
    }

    public void SetDamage(float damage)
    {
        damageAmount = damage;
    }
}
