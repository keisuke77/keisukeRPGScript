using UnityEngine;
using UnityEngine.AI;

public class Escape : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent navMeshAgent;
    public float checkDistance = 5.0f;
    public int checkAngleIncrement = 10;
    public LayerMask raycastLayerMask;

    private int walkableMask;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        
        // Ensure that the "Walkable" area exists before retrieving its mask
        int walkableArea = NavMesh.GetAreaFromName("Walkable");
        if (walkableArea >= 0) 
        {
            walkableMask = 1 << walkableArea;
        }
        else 
        {
            Debug.LogWarning("No NavMesh area named 'Walkable' found.");
            walkableMask = -1;  // All areas
        }
    }

    void Update()
    {
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
        {
            Flee();
        }
    }
void Flee()
{
    Vector3 bestDirection = transform.forward;
    float bestScore = float.MinValue;

    for (int i = 0; i < 360 - checkAngleIncrement; i += checkAngleIncrement)
    {
        Vector3 testDir = Quaternion.Euler(0, i, 0) * transform.forward;
        Vector3 testPos = transform.position + testDir * checkDistance;

        if (NavMesh.SamplePosition(testPos, out NavMeshHit hit, checkDistance, walkableMask))
        {
            float score = ScorePosition(hit.position);

            // Check for potential dead-ends or traps by sampling some points ahead
            for (float distance = 1.0f; distance <= checkDistance; distance += 1.0f)
            {
                Vector3 furtherTestPos = hit.position + testDir * distance;
                if (NavMesh.SamplePosition(furtherTestPos, out NavMeshHit furtherHit, 1.0f, walkableMask))
                {
                    score += ScorePosition(furtherHit.position) * 0.5f;  // Give less weight to further points
                }
                else
                {
                    score -= 10.0f;  // Penalize if a point isn't on the NavMesh, indicating a potential dead-end
                }
            }

            if (score > bestScore)
            {
                bestScore = score;
                bestDirection = testDir;
            }
        }
    }

    navMeshAgent.SetDestination(transform.position + bestDirection * checkDistance);
}

    float ScorePosition(Vector3 testPos)
    {
        float score = 0.0f;

        float playerDist = (player.position - testPos).magnitude;
        score += playerDist;

        if (Physics.Raycast(testPos, player.position - testPos, out RaycastHit hit, playerDist, raycastLayerMask) && hit.distance < playerDist)
        {
            score -= hit.distance;
        }

        return score;
    }
}
