
using System;
using System.Threading.Tasks;

public class EnemyDeadCommand : ICommand
{
    public Guid UserId { get; set; }
    public string EnemyName { get; set; }
}

public class EnemyDeadCommandResult
{
    public int Exp { get; set; }
    public int EnemiesKilled { get; set; }
    public string CurrentEnemyName { get; set; }
    public bool IsNewLocateUnlocked { get; set; }
}

public class EnemyDeadCommandHandler : ApiCommandHandler, ICommandHandler<EnemyDeadCommand,EnemyDeadCommandResult>
{
    public EnemyDeadCommandHandler() : base(WebSettings.GameServerBaseUrl)
    {
    }

    public async Task<EnemyDeadCommandResult> Handle(EnemyDeadCommand command)
    {
        return await PutAsync<EnemyDeadCommandResult, EnemyDeadCommand>("MobKilled", command);
    }
    
}
