using UnityEngine;

public class PingPong : MonoBehaviour
{
    private Vector3 spawnPoint;
    private Vector3 endPoint;
    public Vector3 randomPointRange = new Vector3(10f, 0f, 10f);
    public float speed = 2f;

    void Start()
    {
        spawnPoint = transform.position;
        endPoint = new Vector3(
            Random.Range(-randomPointRange.x, randomPointRange.x),
            Random.Range(-randomPointRange.y, randomPointRange.y),
            Random.Range(-randomPointRange.z, randomPointRange.z)
        );
    }
    void Update()
    {
        transform.position = Vector3.Lerp(spawnPoint, endPoint, Mathf.PingPong(Time.time * speed, 1));
    }
}
