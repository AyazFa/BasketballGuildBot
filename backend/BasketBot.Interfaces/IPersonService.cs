using BasketBot.Contracts;

namespace BasketBot.Interfaces;

public interface IPersonService
{
    List<Person> GetPersons();
}