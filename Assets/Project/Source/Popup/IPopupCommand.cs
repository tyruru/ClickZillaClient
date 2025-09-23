
public interface IPopupCommand : ICommand
{
    void Execute();
    string Message { get; }
}
