
using System;

public class PlayerController : IInitializable, IDisposable
{
    private PlayerStatsModel _playerStatsModel;
    private PlayerScoresView _playerScoresView;
    private EnemyView _enemyView;
    
    public PlayerController(PlayerStatsModel playerStatsModelModel, PlayerScoresView playerScoresView, EnemyView enemyView)
    {
        _playerStatsModel = playerStatsModelModel;
        _playerScoresView = playerScoresView;
        _playerStatsModel.OnScoreChanged += _playerScoresView.UpdateScoreView;
        
        _enemyView = enemyView;
        _enemyView.OnGiveExp += _playerStatsModel.AddExp;
        
    }
    
    public void Initialize()
    {
        _playerScoresView.UpdateScoreView(_playerStatsModel.UserExp);
    }

    public void Dispose()
    {
        _enemyView.OnGiveExp -= _playerStatsModel.AddExp;
    }
}
