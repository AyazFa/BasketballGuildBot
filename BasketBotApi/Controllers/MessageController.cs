using System.Threading.Tasks;
using BasketBotApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;

namespace BasketBotApi.Controllers;

[Route("/")]
public class MessageController : ControllerBase
{
    private ILogger<MessageController> logger;

    public MessageController(ILogger<MessageController> logger)
    {
        this.logger = logger;
    }

    [HttpGet]
    public string Get() 
    {
        logger.LogInformation("Telegram bot was started");
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