
using System;

public class PlayerStatsModel 
{
    public string UserId { get; set; }
    public string UserName { get; set; }
    public string EnemiesKilled { get; set; }
    public int UserExp { get; set; }
    
    public event Action<int> OnScoreChanged;
    
    public void AddExp(int exp)
    {
        if (exp < 0)
            throw new ArgumentException("Experience points cannot be negative.", nameof(exp));
        UserExp += exp;
        OnScoreChanged?.Invoke(UserExp);
    }
    
}
