using UnityEngine;
using Zenject;

public class GameSceneMonoInstaller : MonoInstaller
{
    [SerializeField] private EnemyView _enemyView;
    [SerializeField] private EnemiesDataDefinition _enemiesDef;
    [SerializeField] private LocationsDataDefinition _locationsDef;
    
    [SerializeField] private PlayerScoresView _playerScoresView;
    
    public override void InstallBindings()
    {
        EnvironmentInstaller();
        
        EnemyInstaller();

        PlayerInstaller();

        PopupInstaller();
        Container.BindInterfacesAndSelfTo<BattleManager>().AsSingle().NonLazy();
        
        Container.BindInterfacesAndSelfTo<PopupCommandFactory>().AsSingle().NonLazy();
    }

    private void PopupInstaller()
    {
        Container.BindInterfacesAndSelfTo<PopupManager>().AsSingle().NonLazy();
    }

    private void EnvironmentInstaller()
    {
        Container.BindInstance(_locationsDef).AsSingle().NonLazy();
    }

    private void PlayerInstaller()
    {
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
