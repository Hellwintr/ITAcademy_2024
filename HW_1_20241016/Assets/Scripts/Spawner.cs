using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs;        
    private GameObject tempPrefabInstance;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnRandomPrefab();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("Application closed");
        }
    }

    void SpawnRandomPrefab()
    {
        if (tempPrefabInstance != null)
        {
            Destroy(tempPrefabInstance);
        }
        if (prefabs.Length > 0)
        {
            var randomIndex = Random.Range(0, prefabs.Length);
            var rotation = Quaternion.identity;
            var position = new Vector3(Random.Range(-5.0f,5.0f),Random.Range(-5.0f,5.0f),Random.Range(-5.0f,5.0f));
            tempPrefabInstance = Instantiate(prefabs[randomIndex],position,rotation);
        }
        else
        {
            Debug.LogWarning("List of prefabs is empty!");
        }
    }
}


