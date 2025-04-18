using System.Threading.Tasks;
using BasketBotApi.Helpers;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BasketBotApi.Models.Commands;

/// <summary>
/// Команда формирования команд на основе рейтинга игроков
/// </summary>
public class MakeTeamsCommand : Command
{
    public override string Name => "/mt";
    public override async Task<Message> Execute(Message message, TelegramBotClient botClient, long chatId)
    {
        var messageText = message.Text;
        var lastPoll = MakeTeamsHelper.GetLastPoll();
        var resultMessage = "Список участников опроса был разделен на N команд.\n" +
                            $"Вот как распределились игроки по командам: {lastPoll}";
        return await botClient.SendTextMessageAsync(chatId,
            resultMessage,
            parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
    }

    public override bool Contains(Message message)
    {
        if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
            return false;

        return message.Text!.Contains(this.Name);
    }
}