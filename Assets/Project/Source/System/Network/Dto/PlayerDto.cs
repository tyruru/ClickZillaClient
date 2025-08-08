using Newtonsoft.Json;
public class PlayerDto
{
    [JsonProperty] public string UserName { get; private set; }
    [JsonProperty] public string EnemiesKilled { get; private set; }
    [JsonProperty] public int UserExp { get; private set; }
    
    [JsonConstructor]
    public PlayerDto()
    {
    }
    
    public PlayerDto(string userName, int userExp, string enemiesKilled)
    {
        UserName = userName;
        UserExp = userExp;
        EnemiesKilled = enemiesKilled;
    }

    public override string ToString()
    {
        return $"PlayerModel: UserName = {UserName}, UserExp = {UserExp}";
    }
}
