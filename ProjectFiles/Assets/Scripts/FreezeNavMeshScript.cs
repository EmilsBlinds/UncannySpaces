using UnityEngine;
using UnityEngine.AI;

public class FreezeNavMeshScript : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float stopDistance = 2f;

    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (playerTransform != null)
        {
            navMeshAgent.destination = playerTransform.position;

            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
            if (distanceToPlayer < stopDistance && IsPlayerLookingAtObject())
            {
                navMeshAgent.isStopped = true;
            }
            else
            {
                navMeshAgent.isStopped = false;
            }
        }
    }

    private bool IsPlayerLookingAtObject()
    {
        Vector3 directionToObject = transform.position - Camera.main.transform.position;
        return Vector3.Dot(Camera.main.transform.forward, directionToObject) > 0;
    }
}
