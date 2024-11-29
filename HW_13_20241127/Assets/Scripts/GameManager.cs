using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CubeCreator cubeCreator;
    public static GameManager Instance { get; private set; }
    private Vector3 lastSpawnPosition;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        lastSpawnPosition = new Vector3(0, 0, 0);
    }

    void Start()
    {
        CreateCube();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (cubeCreator != null)
            {
                CreateCube();
            }
        }
    }
    public void CreateCube()
    {
        if (cubeCreator != null)
        {
            cubeCreator.CreateCube(lastSpawnPosition);
            UpdateSpawnPosition();
        }
    }
    private void UpdateSpawnPosition()
    {
        lastSpawnPosition = new Vector3(lastSpawnPosition.x, lastSpawnPosition.y + 1.0f, lastSpawnPosition.z);
    }
}