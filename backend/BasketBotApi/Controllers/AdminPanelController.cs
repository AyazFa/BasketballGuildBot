using System;
using System.Collections.Generic;
using System.Linq;
using BasketBot.Contracts;
using BasketBot.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BasketBotApi.Controllers;

[AllowAnonymous]
[Route("/api/[controller]")]
public class AdminPanelController
{
    private IPersonService personService;
    
    public AdminPanelController(IPersonService personService)
    {
        this.personService = personService ?? throw new ArgumentNullException(nameof(personService));
    }
    
    [HttpGet]
    [Route("persons")]
    public List<Player> GetPersons()
    {
        return personService.GetPlayers();
    }
    
    [HttpGet]
    [Route("person/{id}")]
    public Player GetPerson(long id)
    {
        return personService.GetPlayers().FirstOrDefault(p => p.Id == id)!;
    }
    
    [HttpPut]
    [Route("person/{id}")]
    public Person UpdatePerson([FromBody] Player person)
    {
        return personService.UpdatePerson(person);
    }     
}