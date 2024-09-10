
using UnityEngine;

public class EnemyHealth : MonoBehaviour, DamageInterface
{
    public float maxHealth;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Handle the enemy's death (e.g., play animation, destroy object)
        Destroy(gameObject);
    }
}
