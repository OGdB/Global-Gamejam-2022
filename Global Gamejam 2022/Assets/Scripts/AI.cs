using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[DisallowMultipleComponent]
public class AI : MonoBehaviour
{
    private Strength strength;
    private NavMeshAgent agent;
    public Vector3 targetBase;
    public string enemyTag;
    private Health currentEnemy;
    private bool attackCooldown = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        strength = GetComponent<Strength>();
        MoveToDestination(targetBase);

        if (gameObject.tag == "Dark")
        {
            enemyTag = "Light";
        }
        else
        {
            enemyTag = "Dark";
        }
    }
    private void MoveToDestination(Vector3 destination)
    {
        agent.destination = destination;
    }
    private void Update()
    {
        if (!currentEnemy) // Look for enemy if not fighting one
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
                // ADD currentEnemy is either AI or TowerAI
                currentEnemy = closestEnemy.GetComponent<Health>();

                // Start attacking the enemy
                MoveToDestination(closestEnemy.transform.position);
            }
        }

        // if there is an enemy
        if (currentEnemy != null)
        {
            MoveToDestination(currentEnemy.transform.position);

            // If close enough, hurt each other
            if (Vector3.Distance(transform.position, currentEnemy.transform.position) < 1.5f && !attackCooldown)
            {
                StartCoroutine(AttackCooldown());
                // Damage returns whether the enemy was killed or not
                bool killed = currentEnemy.Damage((int)(10 * strength.Power));

                if (killed)
                {
                    currentEnemy = null;
                    MoveToDestination(targetBase); // Continue moving towards enemy base
                }
            }
        }
    }
    private IEnumerator AttackCooldown()
    {
        attackCooldown = true;
        float randomFloat = Random.Range(1.5f, 2.25f);
        yield return new WaitForSeconds(randomFloat);
        attackCooldown = false;
    }
}
