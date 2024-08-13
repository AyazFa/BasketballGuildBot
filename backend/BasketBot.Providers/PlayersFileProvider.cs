using BasketBot.Contracts;
using BasketBot.Interfaces;
using Newtonsoft.Json;

namespace BasketBot.Providers;

public class PlayersFileProvider : IPlayersFileInterface
{
    public List<Player> GetPlayers()
    {
        List<Player>? players = new List<Player>();

        using StreamReader reader = new StreamReader("Players.json");
        string json = reader.ReadToEnd();  
        players = JsonConvert.DeserializeObject<List<Player>>(json);
        
        return players;
    }
}