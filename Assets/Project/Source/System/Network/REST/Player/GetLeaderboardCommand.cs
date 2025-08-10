using System.Collections.Generic;
using System.Threading.Tasks;

// public class GetLeaderboardCommand : ICommand
// {
//     public string UserName { get; set; }
//     public string UserExp { get; set; }
// }

public class GetLeaderboardCommandHandler : ApiCommandHandler, ICommandHandler<List<LeaderBoardModel>>
{
    public GetLeaderboardCommandHandler() : base(WebSettings.GameServerBaseUrl)
    {
    }

    public Task<List<LeaderBoardModel>> Handle()
    {
        return GetAsync<List<LeaderBoardModel>>("Leaderboard");
    }
}
