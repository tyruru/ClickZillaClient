
using System;

public class PlayerController : IInitializable
{
    private PlayerStatsModel _playerStatsModel;
    private PlayerScoresView _playerScoresView;
    
    public PlayerController(PlayerStatsModel playerStatsModelModel, PlayerScoresView playerScoresView, EnemyView enemyView)
    {
        _playerStatsModel = playerStatsModelModel;
        _playerScoresView = playerScoresView;
        _playerStatsModel.OnScoreChanged += _playerScoresView.UpdateScoreView;
    }
    
    public void Initialize()
    {
        _playerScoresView.UpdateScoreView(_playerStatsModel.UserExp);
    }
    
    public void SetExp(int exp)
    {
        if (exp < 0)
            throw new ArgumentException("Experience points cannot be negative.", nameof(exp));
        
        _playerStatsModel.SetExp(exp);
    }
    
    public void SetEnemiesKilled(int enemiesKilled)
    {
        if (enemiesKilled < 0)
            throw new ArgumentException("Enemies killed cannot be negative.", nameof(enemiesKilled));
        
        _playerStatsModel.EnemiesKilled = enemiesKilled;
    }
    
    public Guid GetUserId()
    {
       return _playerStatsModel.UserId;
    }
}
