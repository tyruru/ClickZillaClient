
using System;
using System.Threading.Tasks;

public class UpdateScoreUserCommand : ICommand
{
    public Guid UserId { get; set; }
    public int? UserExp { get; set; }
    public int? EnemiesKilled { get; set; }
    
    public UpdateScoreUserCommand(Guid userId, int? userExp = null, int? enemiesKilled = null)
    {
        UserId = userId;
        UserExp = userExp;
        EnemiesKilled = enemiesKilled;
    }
}

public class UpdateScoreUserCommandHandler : ApiCommandHandler, ICommandHandler<UpdateScoreUserCommand,UpdateScoreUserCommand>
{
    public UpdateScoreUserCommandHandler() : base(WebSettings.GameServerBaseUrl)
    {
    }

    public async Task<UpdateScoreUserCommand> Handle(UpdateScoreUserCommand command)
    {
        return await PutAsync<UpdateScoreUserCommand, UpdateScoreUserCommand>("User", command);
    }
    
}
