
using System.Threading.Tasks;

public interface ICommandHandler<TCommand, TCommandResult>
    where TCommand : ICommand
{
    Task<TCommandResult> Handle(TCommand command);
}
