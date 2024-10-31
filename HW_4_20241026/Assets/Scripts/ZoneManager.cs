using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.Serialization;

public enum ZoneType
{
    RegularAmmoZone,
    GrenadeZone,
    TennisZone
}

[Serializable]
public struct ZoneWithAmmo
{
    public ZoneType zoneType;
    public GameObject ammoPrefab;
    public float shootForce;
}
public class ZoneManager : MonoBehaviour
{
    public static ZoneManager Instance{get; private set;}   
    public ZoneWithAmmo[] zoneWithAmmo;
    private Dictionary<ZoneType, ZoneWithAmmo> zoneMap;
    private Gun _gun;
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
        zoneMap = new Dictionary<ZoneType, ZoneWithAmmo>();
        foreach (var pair in zoneWithAmmo)
        {
            zoneMap[pair.zoneType] = pair;
        }
    }

    public void RegisterGun(Gun gunInstance)
    {
        _gun = gunInstance;
    }

    public void OnPlayerEnterZone(ZoneType zoneType)
    {
        if (_gun != null && zoneMap.ContainsKey(zoneType))
        {
            var pair = zoneMap[zoneType];
            _gun.SetActiveAmmo(pair.ammoPrefab,pair.shootForce);
        }
    }
}
