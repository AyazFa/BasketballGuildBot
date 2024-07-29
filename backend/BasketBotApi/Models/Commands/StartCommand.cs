using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BasketBotApi.Models.Commands;

public class StartCommand : Command
{
    public override string Name => @"/start";

    public override bool Contains(Message message)
    {
        if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
            return false;

        return message.Text!.Contains(this.Name);
    }

    public override async Task Execute(Message message, TelegramBotClient botClient)
    {
        var chatId = message.Chat.Id;
        await botClient.SendTextMessageAsync(chatId, "Basketball is the best game with ball", parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
    }
}