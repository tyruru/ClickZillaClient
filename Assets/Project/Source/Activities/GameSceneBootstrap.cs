using System;
using UnityEngine;
using Zenject;

public class GameSceneBootstrap : MonoBehaviour
{
    private EnemyController _enemyController;
    
    [Inject]
    public void Construct(EnemyController enemyController)
    {
        _enemyController = enemyController;
    }
    
    private void Awake()
    {
        _enemyController.Initialize();
    }
}
