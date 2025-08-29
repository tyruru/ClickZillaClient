using System;
using System.Threading.Tasks;
using UnityEngine;

public class GetTestPlayerCommandHandler : ApiCommandHandler, ICommandHandler<GetTestPlayerCommand, TestPlayerDto>
{
    public GetTestPlayerCommandHandler() : base(WebSettings.GameServerBaseUrl)
    {
    }

    public async Task<TestPlayerDto> Handle(GetTestPlayerCommand command)
    {
        try
        {
            return await GetAsync<TestPlayerDto>($"User"); // /{command.PlayerId}
        }
        catch (Exception e)
        {
            Debug.LogException(e);
            return null;
        }
    }
}

