using UnityEngine;
using UnityEngine.AI;

public class MovingObstacle : MonoBehaviour
{
    public float speed = 2f;
    public float maxDistance = 5f;
    public float navMeshCheckRadius = 2f;

    private Vector3 initialPosition; 
    private Vector3 targetPosition;  

    void Start()
    {
        initialPosition = transform.position;
        GenerateRandomTarget();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            GenerateRandomTarget(); 
        }
    }
    void GenerateRandomTarget()
    {
        bool isValidPoint = false;
        while (!isValidPoint)
        {
            Vector3 randomDirection = Random.insideUnitSphere * maxDistance;
            Vector3 checkPosition = initialPosition + new Vector3(randomDirection.x, 0, randomDirection.z);
            if (NavMesh.SamplePosition(checkPosition, out NavMeshHit hit, navMeshCheckRadius, NavMesh.AllAreas))
            {
                isValidPoint = true;
                targetPosition = checkPosition;
            }
        }
    }
}