using UnityEngine;

public class CubeMover : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    private bool isMoving = false;
    void Update()
    {
        if (isMoving)
        {
            MoveCube();
        }

        if (Input.GetMouseButtonDown(0))
        {
            StopMoving();
        }
    }

    public void StartMoving()
    {
        isMoving = true;
    }

    private void MoveCube()
    {
        transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y,
            transform.position.z);
    }

    private void StopMoving()
    {
        isMoving = false;
    }
}