using System;
using UnityEngine;

public class BattleManager : IDisposable
{
    private readonly PlayerController _playerController;
    private readonly EnemyController _enemyController;
    private readonly EnemiesDataDefinition _enemiesDef;
    private readonly EnemyDeadCommandHandler _enemyDeadCommandHandler = new EnemyDeadCommandHandler();
    
    public BattleManager(EnemyController enemyController, EnemiesDataDefinition enemiesDef, PlayerController playerController)
    {
        _enemyController = enemyController;
        _enemiesDef = enemiesDef;
        _playerController = playerController;

        _enemyController.OnEnemyDead += HandleEnemyKilled;
    }

    private async void HandleEnemyKilled(string enemyName)
    {
        try
        {
            var result = await _enemyDeadCommandHandler.Handle(new EnemyDeadCommand
            {
                UserId = _playerController.GetUserId(),
                EnemyName = _enemyController.EnemyName,
            });

            if (result == null)
            {
                Debug.LogWarning("EnemyDeadCommandResult is null, cannot update player stats.");
                return;
            }

            _playerController.SetExp(result.Exp);
            _playerController.SetEnemiesKilled(result.EnemiesKilled);
            _enemyController.SetEnemyData(_enemiesDef.GetRandomEnemy()); // then set enemy by CurrentEnemyName from result
            // and implement new location unlock logic if IsNewLocateUnlocked is true
        }
        catch (Exception e)
        {
            Debug.LogError($"Error handling enemy killed: {e.Message}");
        }
    }

    public void Dispose()
    {
        _enemyController.OnEnemyDead -= HandleEnemyKilled;
    }
}
