using BasketBot.Contracts;
using BasketBot.Interfaces;
using Newtonsoft.Json;

namespace BasketBot.Providers;

public class PlayersFileProvider : IPlayersFileInterface
{
    public List<Player> GetPlayers()
    {
        return GetPlayersFromFile();
    }

    public Person UpdatePlayer(Player player)
    {
        var players = GetPlayersFromFile();
        
        if (players.Count == 0)
        {
            throw new Exception("Список игроков пустой");
        }
        
        var playerForUpdate = players.FirstOrDefault(p => p.Id == player.Id);
        
        if (playerForUpdate == null)
        {
            throw new Exception($"Не найден игрок с идентификатором {player.Id} в файле с игроками");
        }
        
        playerForUpdate.Position = player.Position;
        playerForUpdate.Rating = player.Rating;
        
        var updatedPlayersList = JsonConvert.SerializeObject(players, Formatting.Indented);
        File.WriteAllText("Players.json", updatedPlayersList);
        
        return playerForUpdate;
    }

    private List<Player> GetPlayersFromFile()
    {
        List<Player>? players = new List<Player>();

        using StreamReader reader = new StreamReader("Players.json");
        string json = reader.ReadToEnd();  
        players = JsonConvert.DeserializeObject<List<Player>>(json);
        
        return players;        
    }
}