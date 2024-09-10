using UnityEngine;

public class ZombieAI2 : MonoBehaviour
{
    public Transform player; 
    public float detectionRange = 10f; 
    public float attackRange = 2f; 
    public float attackDamage = 10f;
    public float attackCooldown = 1f; 
    private float lastAttackTime;

    public float moveSpeed = 3f; 
    public float rotationSpeed = 5f; 

    private bool isAttacking = false;

    void Update()
    {
        if (player == null) return;

        // Calculate the distance to the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            RotateTowardsPlayer();

            if (distanceToPlayer <= attackRange)
            {
                if (!isAttacking && Time.time - lastAttackTime >= attackCooldown)
                {
                    AttackPlayer();
                }
            }
            else
            {
                // Move towards the player if within detection range but not in attack range
                MoveForward();
            }
        }
    }

    void RotateTowardsPlayer()
    {
        // Calculate the direction to the player
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void MoveForward()
    {
        // Move in the direction the zombie is facing
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void AttackPlayer()
    {
        isAttacking = true;
        lastAttackTime = Time.time;

        // Implement your attack logic here
        // For example, reducing player's health:
        // player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);

        Debug.Log("Zombie attacked the player for " + attackDamage + " damage.");

        // Reset attack state after cooldown
        isAttacking = false;
    }
}
