using System;
using UnityEngine;

[CreateAssetMenu(fileName = "LocationData", menuName = "SO/LocationData")]
public class LocationData : ScriptableObject
{
    [field: SerializeField] public GameObject Prefab { get; private set; }
    [SerializeField] private string _id;
    public Guid Id => string.IsNullOrEmpty(_id) ? Guid.Empty : new Guid(_id);
    
}
