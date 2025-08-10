
using System.Threading.Tasks;

public interface ICommandHandler<TCommand, TCommandResult>
    where TCommand : ICommand
{
    Task<TCommandResult> Handle(TCommand command);
}


public interface ICommandHandler<TResult>
{
    Task<TResult> Handle();
}