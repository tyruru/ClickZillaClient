using UnityEngine;
using Zenject;

public class GameSceneMonoInstaller : MonoInstaller
{
    [SerializeField] private EnemyView _enemyView;
    [SerializeField] private EnemiesDataDefinition _enemiesDef;

    [SerializeField] private PlayerScoresView _playerScoresView;
    
    public override void InstallBindings()
    {
        EnemyInstaller();

        Container.BindInstance(_playerScoresView).AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<PlayerController>().AsSingle();

    }

    private void EnemyInstaller()
    {
        Container.BindInstance(_enemyView).AsSingle().NonLazy();
        Container.BindInstance(_enemiesDef).AsSingle().NonLazy();
        
        Container.BindInterfacesAndSelfTo<EnemyController>().AsSingle().NonLazy();
    }
}
