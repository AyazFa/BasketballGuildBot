using System.Net.Http;
using System.Threading.Tasks;
using BasketBotApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;

namespace BasketBotApi.Controllers;

[AllowAnonymous]
[Route("/")]
public class MessageController : ControllerBase
{
    private ILogger<MessageController> logger;

    public MessageController(ILogger<MessageController> logger)
    {
        this.logger = logger;
    }

    [HttpGet]
    public async Task<string> Get() 
    {
        var client = new HttpClient();
        var queryString = $"https://api.telegram.org/bot{AppSettings.Key}/setwebhook?url={AppSettings.Url}/api/message/update";
        var response = await client.GetAsync(queryString);
        var content = await response.Content.ReadAsStringAsync(); 
        return content;
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