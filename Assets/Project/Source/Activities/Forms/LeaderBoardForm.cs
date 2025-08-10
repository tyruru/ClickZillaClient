using UnityEngine;

public class LeaderBoardForm : MonoBehaviour
{
    [SerializeField] private LeaderboardItemComponent _itemListPrefab;
    [SerializeField] private Transform _itemListContent;

    private async void Awake()
    {
        GetLeaderboardCommandHandler commandHandler = new GetLeaderboardCommandHandler();
        var leaderBoardModels = await commandHandler.Handle();

        foreach (var model in leaderBoardModels)
        {
            var itemGo = Instantiate(_itemListPrefab, _itemListContent);
            itemGo.SetData(model.UserName, model.UserExp, null); // add icon later
        }
    }
}
