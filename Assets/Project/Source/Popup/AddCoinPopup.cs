using UnityEngine;

public class AddCoinPopup : BasePopup
{
    private int _addCoin;

    public AddCoinPopup(int addCoin, PopupManager manager, string message) : base(manager, message)
    {
        _addCoin = addCoin;
    }
    
    public override void Execute()
    {
       Debug.Log("add " +_addCoin + " coin. " + _message );
       
       base.Execute();
    }
}
