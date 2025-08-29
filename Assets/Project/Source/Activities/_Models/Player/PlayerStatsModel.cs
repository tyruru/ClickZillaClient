using System;
using UnityEngine;

public class PlayerStatsModel 
{
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public int EnemiesKilled { get; set; }
    public int UserExp { get; set; }
    public Guid CurrentLocationId { get; set; }
    
    public event Action<int> OnScoreChanged;
    
    public void SetExp(int exp)
    {
        if (exp < 0)
            throw new ArgumentException("Experience points cannot be negative.", nameof(exp));
    
        UserExp = exp;
        
        OnScoreChanged?.Invoke(UserExp);
    }
}
