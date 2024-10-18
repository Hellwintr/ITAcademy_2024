using UnityEngine;

public class Teleport : MonoBehaviour
{
    public float teleportInterval = 3f;
    public Vector3 teleportDistance = new Vector3(10f, 0f, 10f);
    private float nextTeleportTime;
    void Start()
    {
        nextTeleportTime = Time.time + teleportInterval;
    }

    void Update()
    {
        if (Time.time >= nextTeleportTime)
        {
            Teleporter();
            nextTeleportTime = Time.time + teleportInterval;
        }
    }
    void Teleporter()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(-teleportDistance.x, teleportDistance.x),
            Random.Range(-teleportDistance.y, teleportDistance.y),
            Random.Range(-teleportDistance.z, teleportDistance.z)
        );
        transform.position = randomPosition;
    }
}
