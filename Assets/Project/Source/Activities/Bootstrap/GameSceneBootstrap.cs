using UnityEngine;
using Zenject;

public class GameSceneBootstrap : MonoBehaviour
{
    private EnemyController _enemyController;
    private PlayerController _playerController;
    private EnemiesDataDefinition _enemiesDef;
    
    [Inject]
    public void Construct(EnemyController enemyController, PlayerController playerController, EnemiesDataDefinition enemiesDef)
    {
        _enemyController = enemyController;
        _playerController = playerController;
        _enemiesDef = enemiesDef;
    }
    
    private void Awake()
    {
        _enemyController.SetEnemyData(_enemiesDef.GetRandomEnemy());
        _playerController.Initialize();
    }
}
