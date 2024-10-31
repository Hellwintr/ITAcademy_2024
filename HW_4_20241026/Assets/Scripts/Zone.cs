using System;
using UnityEngine;

public class Zone : MonoBehaviour
{
    public ZoneType zoneType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ZoneManager.Instance.OnPlayerEnterZone(zoneType);
        }
    }
}
