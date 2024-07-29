﻿using System.Net.Http;
using System.Threading.Tasks;
using BasketBotApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;

namespace BasketBotApi.Controllers;

[AllowAnonymous]
[Route("/")]
public class MessageController : ControllerBase
{
    [HttpGet]
    public Task<string> Get() 
    {
        return SetWebHook();
    }
    
    [Route("api/message/update")]
    [HttpPost]
    public async Task<OkResult> Post([FromBody]Update update)
    {
        if (update == null) return Ok();

        var commands = Bot.Commands;
        var message = update.Message;
        var botClient = await Bot.GetBotClientAsync();
        await SetWebHook();

        foreach (var command in commands)
        {
            if (command.Contains(message))
            {
                await command.Execute(message, botClient);
                break;
            }
        }
        return Ok();
    }

    private async Task<string> SetWebHook()
    {
        var client = new HttpClient();
        var queryString = $"https://api.telegram.org/bot{AppSettings.Key}/setwebhook?url={AppSettings.Url}/api/message/update";
        var response = await client.GetAsync(queryString);
        return await response.Content.ReadAsStringAsync();
    }
}