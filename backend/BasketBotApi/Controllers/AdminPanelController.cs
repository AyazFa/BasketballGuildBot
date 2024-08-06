﻿using System;
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
    public List<Person> GetPersons()
    {
        return personService.GetPersons();
    }
    
    [HttpGet]
    [Route("person/{id}")]
    public Person GetPerson(long id)
    {
        return personService.GetPersons().FirstOrDefault(p => p.Id == id)!;
    }    
}