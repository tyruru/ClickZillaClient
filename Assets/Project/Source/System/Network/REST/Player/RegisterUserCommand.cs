using System;
using System.Threading.Tasks;
using UnityEngine;

public class RegisterUserCommand : ICommand
{
    public string UserName { get; private set; } 
    public string Password { get; private set; } 
    
    public RegisterUserCommand(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }
}

public class RegisterUserCommandHandler : ApiCommandHandler, ICommandHandler<RegisterUserCommand, RegisterUserCommand>
{
    public RegisterUserCommandHandler() : base(WebSettings.GameServerBaseUrl)
    {
    }

    public Task<RegisterUserCommand> Handle(RegisterUserCommand command)
    {
        try
        {
            return PostAsync<RegisterUserCommand, RegisterUserCommand>("User/Register", command);
        }
        catch (Exception e)
        {
            Debug.LogException(e);
            return null;
        }
    }
}
