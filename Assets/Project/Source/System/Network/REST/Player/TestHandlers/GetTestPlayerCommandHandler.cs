using System;
using System.Threading.Tasks;
using UnityEngine;

public class GetTestPlayerCommandHandler : ApiCommandHandler, ICommandHandler<GetTestPlayerCommand, PlayerDto>
{
    public GetTestPlayerCommandHandler() : base(WebSettings.GameServerBaseUrl)
    {
    }

    public async Task<PlayerDto> Handle(GetTestPlayerCommand command)
    {
        try
        {
            return await GetAsync<PlayerDto>($"User"); // /{command.PlayerId}
        }
        catch (Exception e)
        {
            Debug.LogException(e);
            return null;
        }
    }
}

