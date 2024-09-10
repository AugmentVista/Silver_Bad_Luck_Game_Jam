using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    public Transform player; 
    public float detectionRange; 
    public float attackRange; 
    public float attackDamage; 
    public float attackCooldown; 
    private float lastAttackTime;

    private NavMeshAgent navMeshAgent;
    private bool isAttacking = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (player == null) return;
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            // Move towards the player if within detection range
            navMeshAgent.SetDestination(player.position);

            if (distanceToPlayer <= attackRange)
            {
                // Stop moving and attack the player if within attack range
                navMeshAgent.isStopped = true;
                if (!isAttacking && Time.time - lastAttackTime >= attackCooldown)
                {
                    AttackPlayer();
                }
            }
            else
            {
                // Continue moving towards the player if not within attack range
                navMeshAgent.isStopped = false;
            }
        }
        else
        {
            navMeshAgent.isStopped = true;
        }
    }

    void AttackPlayer()
    {
        isAttacking = true;
        lastAttackTime = Time.time;
        //player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);

        Debug.Log("Zombie attacked the player for " + attackDamage + " damage.");

        isAttacking = false;
    }
}
