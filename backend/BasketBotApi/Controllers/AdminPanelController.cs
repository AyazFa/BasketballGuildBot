using System.Collections.Generic;
using System.Linq;
using BasketBotApi.Models.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BasketBotApi.Controllers;

[AllowAnonymous]
[Route("/api/[controller]")]
public class AdminPanelController
{
    private List<Person> personList = new List<Person>
    {
        new Person { Id = 1, Name = "Test Player 1" },
        new Person { Id = 2, Name = "Test Player 2" },
        new Person { Id = 3, Name = "Test Player 3" }          
    };
    
    [HttpGet]
    [Route("persons")]
    public List<Person> GetPersons()
    {
        return personList;
    }
    
    [HttpGet]
    [Route("person/{id}")]
    public Person GetPerson(long id)
    {
        return personList.FirstOrDefault(p => p.Id == id)!;
    }    
}