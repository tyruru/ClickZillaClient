
using System;

public abstract class BasePopup : IPopupCommand
{
    protected PopupManager _manager;
    protected string _message;
    protected string _reward;
    protected string _iconPath;
    protected PopupType _type;
    protected Guid _id;
    
    public BasePopup(PopupManager manager, string message)
    {
        _manager = manager;
        _message = message;
        
        _manager.AddPopup(this);
    }

    public virtual void Execute()
    {
        // isRewardGot = Server.GetReward(_id)
        //if(isRewardGor)
        _manager.RemovePopup(this);
        //else
        //...
    }

    public string Message => _message;
}
