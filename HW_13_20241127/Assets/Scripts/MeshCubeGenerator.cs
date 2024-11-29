using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class MeshCubeGenerator : MonoBehaviour
{
    public float cubeWidth = 1.0f;
    public float cubeHeight = 1.0f;
    public float cubeDepth = 1.0f;
    void Update()
    {
        GenerateCube();
    }

    public void GenerateCube()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(-cubeWidth / 2, -cubeHeight / 2, cubeDepth / 2),  
            new Vector3(cubeWidth / 2, -cubeHeight / 2, cubeDepth / 2),   
            new Vector3(cubeWidth / 2, cubeHeight / 2, cubeDepth / 2),    
            new Vector3(-cubeWidth / 2, cubeHeight / 2, cubeDepth / 2),   
            new Vector3(-cubeWidth / 2, -cubeHeight / 2, -cubeDepth / 2), 
            new Vector3(cubeWidth / 2, -cubeHeight / 2, -cubeDepth / 2),  
            new Vector3(cubeWidth / 2, cubeHeight / 2, -cubeDepth / 2),   
            new Vector3(-cubeWidth / 2, cubeHeight / 2, -cubeDepth / 2)
        };
        int[] triangles = new int[]
        {
            0, 1, 2, 0, 2, 3,  
            4, 6, 5, 4, 7, 6,  
            4, 5, 1, 4, 1, 0,  
            3, 2, 6, 3, 6, 7,  
            3, 7, 4, 3, 4, 0,  
            1, 5, 6, 1, 6, 2   
        };
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        meshFilter.mesh = mesh;
    }
    public void SetCubeSize(float width, float height, float depth)
    {
        cubeWidth = width;
        cubeHeight = height;
        cubeDepth = depth;
    }
}