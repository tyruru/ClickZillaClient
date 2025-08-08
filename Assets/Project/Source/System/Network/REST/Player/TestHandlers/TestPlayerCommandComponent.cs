using System;
using UnityEngine;

public class TestPlayerCommandComponent 
{
    private GetTestPlayerCommandHandler _commandHandler;

    public async void Construct(GetTestPlayerCommandHandler commandHandler)
    {
        _commandHandler = commandHandler;
    
        PlayerDto dto = await _commandHandler.Handle(new GetTestPlayerCommand("df"));
        if (dto != null)
        {
            Debug.Log("Test player data fetched successfully: " + dto.ToString());
        }
        else
        {
            Debug.LogWarning("Test player data is null.");
        }
    }
}