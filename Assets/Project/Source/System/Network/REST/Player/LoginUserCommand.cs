
using System.Threading.Tasks;

public class LoginUserCommand : ICommand
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class LoginUserCommandHandler : ApiCommandHandler, ICommandHandler<LoginUserCommand, PlayerStatsModel>
{
    public LoginUserCommandHandler() : base(WebSettings.GameServerBaseUrl)
    {
    }

    public Task<PlayerStatsModel> Handle(LoginUserCommand command)
    {
        return PostAsync<PlayerStatsModel, LoginUserCommand>("User/Authorize", command);
    }
}
