using UnityEngine;
using UnityEngine.AI;

public class SlowDownBoy : MonoBehaviour
{
    private float normalSpeed;
    public float slowSpeedFactor = 2f;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            NavMeshAgent agent = other.GetComponent<NavMeshAgent>();
            if (agent != null)
            {
                normalSpeed = agent.speed;  
                agent.speed /= slowSpeedFactor; 
                Debug.Log("Player is slowed");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            NavMeshAgent agent = other.GetComponent<NavMeshAgent>();
            if (agent != null)
            {
                agent.speed = normalSpeed; 
                Debug.Log("Player's speed restored.");
            }
        }
    }
}