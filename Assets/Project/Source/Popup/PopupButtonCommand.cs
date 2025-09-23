
public class PopupButtonCommand : ButtonCommand
{
    private IPopupCommand _command;

    public void Initialize(IPopupCommand command)
    {
        _command = command;
    }

    public override void Execute()
    {
        _command?.Execute();
        
        Destroy(gameObject); 
    }
}
