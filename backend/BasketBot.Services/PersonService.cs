using BasketBot.Contracts;
using BasketBot.Interfaces;

namespace BasketBot.Services;

public class PersonService : IPersonService
{
    private IChatMembersFileInterface chatMembersFileInterface;

    public PersonService(IChatMembersFileInterface chatMembersFileInterface)
    {
        this.chatMembersFileInterface = chatMembersFileInterface ?? throw new ArgumentNullException(nameof(chatMembersFileInterface));
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
}