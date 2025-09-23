
using UnityEngine;

public class AddExpPopup : BasePopup
{
    private int _exp;
    
    public AddExpPopup(int exp, PopupManager manager, string message) : base(manager, message)
    {
        _exp = exp;
    }

    public override void Execute()
    {
        Debug.Log("Add some exp: " + _exp);
        
       base.Execute();
    }
}
