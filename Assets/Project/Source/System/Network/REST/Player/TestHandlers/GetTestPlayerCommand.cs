
public class GetTestPlayerCommand : ICommand
{
    public string PlayerId { get; private set; } // not really used, just for consistency
    
    public GetTestPlayerCommand(string playerId)
    {
        PlayerId = playerId;
    }
}
