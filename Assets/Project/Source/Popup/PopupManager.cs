using System;
using System.Collections.Generic;

public class PopupManager
{
    private readonly Guid _userId;
    
    public PopupManager(PlayerStatsModel playerStatsModel)
    {
        _userId = playerStatsModel.UserId;
    }
    
    private List<IPopupCommand> _storage = new();
    
    public List<IPopupCommand> Storage => _storage;

    public void Initialize(List<IPopupCommand> notifications)
    {
       _storage = notifications;
    }
    
    public void AddPopup(IPopupCommand command)
    {
        _storage.Add(command);
    }
    
    public void RemovePopup(IPopupCommand command)
    {
        _storage.Remove(command);
    }

    private List<IPopupCommand> GetTestPopups()
    {
        AddCoinPopup popup = new AddCoinPopup(5, this," TestMEsasge");
        AddCoinPopup popup2 = new AddCoinPopup(10, this," Now more");
        AddExpPopup popup3 = new AddExpPopup(5, this,"Now more");
        List<IPopupCommand> list = new List<IPopupCommand>();
        list.Add(popup);
        list.Add(popup2);
        list.Add(popup3);
        
        return list;
    }
}
