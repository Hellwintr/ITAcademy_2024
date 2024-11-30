using System;
using UnityEngine;

public class DoorTrigger: MonoBehaviour
{
    [SerializeField] GameObject door;
    bool doorOpen = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!doorOpen&&other.CompareTag("Player"))
        {
            Debug.Log("Door was opened");
            door.transform.position += new Vector3(0, 3f, 0);
            doorOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (doorOpen&&other.CompareTag("Player"))
        {
            Debug.Log("Door is closed");
            door.transform.position -= new Vector3(0, 3f, 0);
            doorOpen = false;
        }
    }
}
