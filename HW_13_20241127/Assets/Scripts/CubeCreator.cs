using UnityEngine;

public class CubeCreator : MonoBehaviour
{
    public CameraUpdate cameraUpdate;
    public MeshCubeGenerator meshCubeGenerator;
    public float cubeHeight = 1.0f;
    public void CreateCube(Vector3 spawnPosition)
    {
        GameObject newCube = new GameObject("Cube"); 
        newCube.AddComponent<MeshFilter>(); 
        newCube.AddComponent<MeshRenderer>(); 

        MeshCubeGenerator cubeGenerator = newCube.AddComponent<MeshCubeGenerator>();
        cubeGenerator.GenerateCube(); 
        newCube.transform.position = spawnPosition;
        CubeMover cubeMover = newCube.AddComponent<CubeMover>();
        cubeMover.StartMoving();
        if (cameraUpdate != null)
        {
            cameraUpdate.MoveUp();
        }
    }
}