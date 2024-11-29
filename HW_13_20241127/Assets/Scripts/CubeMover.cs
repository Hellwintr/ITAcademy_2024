using UnityEngine;

public class CubeMover : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    private bool isMoving = false;
    private static float lastCubePositionX;
    private MeshFilter meshFilter;
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
        meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh.MarkDynamic();
        CheckAndTrim();
    }
    private void CheckAndTrim()
    {
        if (lastCubePositionX != 0)
        {
            float currentCubeLeftX = transform.position.x - GetWidth() / 2;
            float currentCubeRightX = transform.position.x + GetWidth() / 2;
            float lastCubeLeftX = lastCubePositionX - GetWidth() / 2;
            float lastCubeRightX = lastCubePositionX + GetWidth() / 2;
            if (currentCubeRightX > lastCubeRightX)
            {
                float trimWidth = currentCubeRightX - lastCubeRightX;
                TrimCube(trimWidth, "right");
            }

            if (currentCubeLeftX < lastCubeLeftX)
            {
                float trimWidth = lastCubeLeftX - currentCubeLeftX;
                TrimCube(trimWidth, "left");
            }
        }
        lastCubePositionX = transform.position.x;
    }

    private void TrimCube(float trimWidth, string side)
    {
        Vector3[] vertices = meshFilter.mesh.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            if (side == "right")
            {
                vertices[i] = new Vector3(transform.position.x + trimWidth / 2, vertices[i].y, vertices[i].z);
            }
            else if (side == "left")
            {
                vertices[i] = new Vector3(transform.position.x - trimWidth / 2, vertices[i].y, vertices[i].z);
            }
        }
        meshFilter.mesh.vertices = vertices;
        meshFilter.mesh.RecalculateNormals();
    }

    private float GetWidth()
    {
        return meshFilter.mesh.bounds.size.x;
    }
}