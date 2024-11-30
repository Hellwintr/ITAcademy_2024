using UnityEngine;
using UnityEngine.AI;

public class PlayerSpeedControl : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent agent;  
    private float normalSpeed;
    public float slowSpeedFactor = 2f;

    void OnTriggerEnter(Collider other)
    {
        agent = player.GetComponent<NavMeshAgent>();
        normalSpeed = agent.speed;
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player is slowed");
            agent.speed /= slowSpeedFactor;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player's speed restored.");
            agent.speed = normalSpeed;
        }
    }
}