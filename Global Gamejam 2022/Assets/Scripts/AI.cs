using UnityEngine;
using UnityEngine.AI;

[DisallowMultipleComponent]
public class AI : MonoBehaviour
{
    private NavMeshAgent agent;
    public Vector3 targetBase;
    public string enemyTag;
    public bool isFighting = false;
    private AI currentEnemy;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

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
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 14);
            Collider closestEnemy = null;
            float closestDistance = Mathf.Infinity;
            foreach (Collider hitCollider in hitColliders)
            {
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
                currentEnemy = closestEnemy.GetComponent<AI>();

                // Start attacking the enemy
                MoveToDestination(closestEnemy.transform.position);
                isFighting = true;
            }
        }
    }
}
