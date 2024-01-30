using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using BasketBotApi.Models.Commands;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;

namespace BasketBotApi.Models;

public class Bot
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

        botClient = new TelegramBotClient(AppSettings.Key);
        InputFileStream certFile = new InputFileStream(File.OpenRead(@".\cert\wild_.BasketballGuildBot.somee.com.pfx"));
        await botClient.SetWebhookAsync("https://BasketballGuildBot.somee.com/api/message/update", certFile, allowedUpdates: new List<UpdateType>());
        return botClient;
    }
}