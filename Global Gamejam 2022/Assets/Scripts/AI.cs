using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[DisallowMultipleComponent]
public class AI : MonoBehaviour
{
    private Health health;
    private Strength strength;
    private NavMeshAgent agent;
    public Vector3 targetBase;
    public string enemyTag;
    public bool isFighting = false;
    private AI currentEnemy;
    private bool attackCooldown = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        health = GetComponent<Health>();
        strength = GetComponent<Strength>();
        MoveToDestination(targetBase);
    }
    private void MoveToDestination(Vector3 destination)
    {
        agent.destination = destination;
    }
    private void Update()
    {
        if (!isFighting)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 4f);
            Collider closestEnemy = null;
            float closestDistance = Mathf.Infinity;

            for (int i = 0; i < hitColliders.Length; i++)
            {
                Collider hitCollider = hitColliders[i];
                if (hitCollider.tag == enemyTag)
                {
                    float distance = Vector3.Distance(transform.position, hitCollider.transform.position);
                    if (distance < closestDistance)
                    {
                        closestEnemy = hitCollider;
                        closestDistance = distance;
                    }
                }
            }

            if (closestEnemy != null)
            {
                isFighting = true;
                print(closestEnemy.GetComponent<AI>());

                // ADD currentEnemy is either AI or TowerAI
                currentEnemy = closestEnemy.GetComponent<AI>();

                // Start attacking the enemy
                MoveToDestination(closestEnemy.transform.position);
            }
        }

        if (currentEnemy)
        {
            MoveToDestination(currentEnemy.transform.position);

            // If close enough, hurt each other
            if (Vector3.Distance(transform.position, currentEnemy.transform.position) < 1.5f && !attackCooldown)
            {
                StartCoroutine(AttackCooldown());
                health.Damage(10);
                if (currentEnemy.isActiveAndEnabled)
                {
                    isFighting = false;
                    currentEnemy = null;
                }
            }
        }
    }
    private IEnumerator AttackCooldown()
    {
        attackCooldown = true;
        yield return new WaitForSeconds(2f);
        attackCooldown = false;
    }
}
