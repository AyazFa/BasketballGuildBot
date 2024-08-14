using System;
using System.Net.Http;
using System.Threading.Tasks;
using BasketBot.Contracts;
using BasketBot.Interfaces;
using BasketBotApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BasketBotApi.Controllers;

[AllowAnonymous]
[Route("/")]
public class MessageController : ControllerBase
{
    private IPersonService personService;

    public MessageController(IPersonService personService)
    {
        this.personService = personService ?? throw new ArgumentNullException(nameof(personService));
    }

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

        if (message.Type == MessageType.ChatMembersAdded)
        {
            var chatMember = message.NewChatMembers![0];
            if (chatMember.IsBot)
            {
                return Ok();
            }

            var person = new Person
            {
                Id = chatMember.Id,
                Name = $"{chatMember.FirstName} {chatMember.LastName}",
                UserName = chatMember.Username,
            };
            personService.SaveChatMemberAsPlayer(person);
            return Ok();
        }
        
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