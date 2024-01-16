using System.Threading.Tasks;
using BasketBotApi.Models;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;

namespace BasketBotApi.Controllers;

[Route("/")]
public class MessageController : ControllerBase
{
    [HttpGet]
    public string Get() 
    {
        //Здесь мы пишем, что будет видно если зайти на адрес,
        //указаную в ngrok и launchSettings
        return "Telegram bot was started";
    }
    
    [Route("api/message/update")]
    [HttpPost]
    public async Task<OkResult> Post([FromBody]Update update)
    {
        if (update == null) return Ok();

        var commands = Bot.Commands;
        var message = update.Message;
        var botClient = await Bot.GetBotClientAsync();

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
}