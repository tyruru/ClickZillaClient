
using UnityEngine;

public class PopupCommandFactory
{
    private PopupManager _manager;
    
    public PopupCommandFactory(PopupManager manager)
    {
        _manager = manager;
    }
    
    public IPopupCommand Create(NotificationModel model)
    {
        IPopupCommand command = null;
        
        switch (model.RewardType)
        {
            case 1:
                command = new AddCoinPopup(model.RewardCount, _manager, model.Message);
                break;
            case 2:
                command = new AddExpPopup(model.RewardCount, _manager, model.Message);
                break;
            default:
                Debug.LogWarning($"Unknown reward type: {model.RewardType}");
                break;
        }

        return command;
    }
}
