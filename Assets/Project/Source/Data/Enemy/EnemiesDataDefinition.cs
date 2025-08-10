using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/EnemiesDef", fileName = "EnemiesDef")]
public class EnemiesDataDefinition : ScriptableObject
{
    [SerializeField] private List<EnemyData> _enemiesList;

    public EnemyData GetRandomEnemy()
    {
        if (_enemiesList == null || _enemiesList.Count == 0)
        {
            Debug.LogWarning("Enemies list is empty or not initialized.");
            return null;
        }

        int randomIndex = Random.Range(0, _enemiesList.Count);
        return _enemiesList[randomIndex].Clone();
    }
}
