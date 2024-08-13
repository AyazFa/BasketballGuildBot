using BasketBot.Contracts;
using BasketBot.Interfaces;

namespace BasketBot.Services;

public class PersonService : IPersonService
{
    private IChatMembersFileInterface chatMembersFileInterface;
    private IPlayersFileInterface playersFileInterface;

    public PersonService(IChatMembersFileInterface chatMembersFileInterface, IPlayersFileInterface playersFileInterface)
    {
        this.chatMembersFileInterface = chatMembersFileInterface ?? throw new ArgumentNullException(nameof(chatMembersFileInterface));
        this.playersFileInterface = playersFileInterface ?? throw new ArgumentNullException(nameof(playersFileInterface));
    }

    public List<Person> GetPersons()
    {
        List<Person> personList = new List<Person>();
        var chatMembers = chatMembersFileInterface.GetChatMembersFromFile();
        foreach (var chatMember in chatMembers)
        {
            var user = chatMember.User;
            personList.Add(new Person
            {
                Id = user.Id,
                UserName = user.UserName,
                Name = $"{user.FirstName} {user.LastName}"
            });
        }

        return personList;
    }

    public List<Player> GetPlayers()
    {
        return playersFileInterface.GetPlayers();
    }
}