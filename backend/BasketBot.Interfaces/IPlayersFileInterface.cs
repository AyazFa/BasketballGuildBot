using BasketBot.Contracts;

namespace BasketBot.Interfaces;

public interface IPlayersFileInterface
{
    List<Player> GetPlayers();
    Person UpdatePlayer(Player player);
    void SavePersonAsPlayer(Person person);
}