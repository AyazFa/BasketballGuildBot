using BasketBot.Contracts;

namespace BasketBot.Interfaces;

public interface IPlayersFileInterface
{
    List<Player> GetPlayers();
}