using System.Collections.Generic;
using BasketBotApi.Models.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BasketBotApi.Controllers;

[AllowAnonymous]
[Microsoft.AspNetCore.Components.Route("/api/admin")]
public class AdminPanelController
{
    [HttpGet]
    public List<Player> GetPlayers() 
    {
        return new List<Player>
        {
            new Player
            {
                Id = 1,
                Name = "Test Player"
            }
        };
    }
}