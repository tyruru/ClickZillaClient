using System;
using UnityEngine;
using Zenject;

public class GameSceneBootstrap : MonoBehaviour
{
    private EnemyController _enemyController;
    private PlayerController _playerController;
    
    [Inject]
    public void Construct(EnemyController enemyController, PlayerController playerController)
    {
        _enemyController = enemyController;
        _playerController = playerController;
    }
    
    private void Awake()
    {
        _enemyController.Initialize();
        _playerController.Initialize();
    }
}
