using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/EnemiesDef", fileName = "EnemiesDef")]
public class EnemiesDataDefinition : ScriptableObject
{
    [SerializeField] private List<EnemyData> _enemiesList;

    public IEnumerable<EnemyData> EnemyList => _enemiesList;
}
