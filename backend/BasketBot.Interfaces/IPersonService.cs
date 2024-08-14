using BasketBot.Contracts;

namespace BasketBot.Interfaces;

public interface IPersonService
{
    List<Person> GetPersons();
    
    List<Player> GetPlayers();
    Person UpdatePerson(Player player);
    void SaveChatMemberAsPlayer(Person person);
}