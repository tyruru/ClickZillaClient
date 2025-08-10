using System;
using UnityEngine;

public class PlayerStatsModel 
{
    private UpdateScoreUserCommandHandler _updateScoreUserCommandHandler;
    
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public int EnemiesKilled { get; set; }
    public int UserExp { get; set; }
    
    public event Action<int> OnScoreChanged;

    public PlayerStatsModel()
    {
        _updateScoreUserCommandHandler = new UpdateScoreUserCommandHandler();
    }
    
    public async void AddExp(int exp)
    {
        try
        {
            if (exp < 0)
                throw new ArgumentException("Experience points cannot be negative.", nameof(exp));
        
            UserExp += exp;
            EnemiesKilled++;
            
            OnScoreChanged?.Invoke(UserExp);
        
            var isUpdate =  await _updateScoreUserCommandHandler.Handle(
                new UpdateScoreUserCommand(UserId, UserExp, EnemiesKilled));
        
            if(isUpdate != null)
                Debug.Log($"Player {UserName} updated: Exp = {UserExp}, EnemiesKilled = {EnemiesKilled}");
            else
                Debug.LogError($"isUpdate var is false for player {UserName}.");
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to update player {UserName} stats. Error: {e.Message}");
        }
    }
    
}
