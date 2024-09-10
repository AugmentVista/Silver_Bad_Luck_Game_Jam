using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damageAmount = 10f; // Damage amount for the bullet

    private void OnCollisionEnter(Collision collision)
    {
        EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damageAmount);
        }

        // Optionally destroy the bullet after collision
        Destroy(gameObject);
    }

    public void SetDamage(float damage)
    {
        damageAmount = damage;
    }
}
