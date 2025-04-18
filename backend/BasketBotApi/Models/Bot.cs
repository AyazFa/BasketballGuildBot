using System.Collections.Generic;
using System.Threading.Tasks;
using BasketBotApi.Models.Commands;
using Telegram.Bot;

namespace BasketBotApi.Models;

public static class Bot
{
    private static TelegramBotClient botClient;
    private static List<Command> commandsList;

    public static IReadOnlyList<Command> Commands => commandsList.AsReadOnly();

    public static async Task<TelegramBotClient> GetBotClientAsync()
    {
        if (botClient != null)
        {
            return botClient;
        }

        commandsList = new List<Command>();
        commandsList.Add(new StartCommand());
        commandsList.Add(new CreatePollCommand()); 
        commandsList.Add(new TakeJerseyCommand());  
        commandsList.Add(new CollectMoneyCommand());
        commandsList.Add(new MakeTeamsCommand()); 
        commandsList.Add(new StopPollCommand());  

        botClient = new TelegramBotClient(AppSettings.Key);
        return botClient;
    }
}