using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameSceneBootstrap : MonoBehaviour
{
    [SerializeField] private PopupForm _popupForm;
    
    private EnemyController _enemyController;
    private PlayerController _playerController;
    private EnemiesDataDefinition _enemiesDef;
    private LocationsDataDefinition _locationsDef;
    private PopupCommandFactory _popupCommandFactory;
    
    private PopupManager _popupManager;
    
    [Inject]
    public void Construct(EnemyController enemyController, PlayerController playerController,
        EnemiesDataDefinition enemiesDef, LocationsDataDefinition locationsDef,
        PopupManager popupManager, PopupCommandFactory popupCommandFactory)
    {
        _enemyController = enemyController;
        _playerController = playerController;
        _enemiesDef = enemiesDef;
        _locationsDef = locationsDef;
        _popupManager = popupManager;
        _popupCommandFactory = popupCommandFactory;
    }
    
    private void Awake()
    {
        _enemyController.SetEnemyData(_enemiesDef.GetRandomEnemy());
        _playerController.Initialize();

        Instantiate(_locationsDef.GetPrefabById(_playerController.GetCurrentLocationId())); // change to api request
        
        DownloadNotifications();
        
    }

    private async void DownloadNotifications()
    {
        var handler = new GetNotificationsCommandHandler();
        var models = await handler.Handle(new NotificationCommand(_playerController.GetUserId()));

        List<IPopupCommand> notifications = new();
        foreach (var model in models)
        {
            notifications.Add(_popupCommandFactory.Create(model));
        }
        
        _popupManager.Initialize(notifications); 
        _popupForm.Initialize();
    }
    
}
