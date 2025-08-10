using System;
using UnityEngine;

public class PlayerStatsModel 
{
    private EnemyDeadCommandHandler _enemyDeadCommandHandler;
    
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public int EnemiesKilled { get; set; }
    public int UserExp { get; set; }
    
    public event Action<int> OnScoreChanged;

    public PlayerStatsModel()
    {
        _enemyDeadCommandHandler = new EnemyDeadCommandHandler();
    }
    
    public void SetExp(int exp)
    {
        if (exp < 0)
            throw new ArgumentException("Experience points cannot be negative.", nameof(exp));
    
        UserExp = exp;
        
        OnScoreChanged?.Invoke(UserExp);
    }
}
