using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "LocationsDef", menuName = "SO/LocationsDef")]
public class LocationsDataDefinition : ScriptableObject
{
    [SerializeField] private List<LocationData> _locationsList;

    public GameObject GetPrefabById(Guid id)
    {
        return _locationsList.FirstOrDefault(l => l.Id == id)?.Prefab;
    }
}
