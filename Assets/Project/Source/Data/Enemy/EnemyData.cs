using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "SO/EnemyData")]
public class EnemyData : ScriptableObject
{
    [field: SerializeField] private List<Mesh> _buildingMeshes { get; set; }
    [field: SerializeField] private int _hp { get; set; }
    [field: SerializeField] private string _name { get; set; }
    
    public List<Mesh> BuildingMeshes => _buildingMeshes;
    public int Hp => _hp;
    public string Name => _name;
    
    public EnemyData Clone()
    {
        var instance = CreateInstance<EnemyData>();
        
        instance._buildingMeshes = _buildingMeshes;
        instance._hp = _hp;
        instance._name = _name;
        
        return instance;
    }
}