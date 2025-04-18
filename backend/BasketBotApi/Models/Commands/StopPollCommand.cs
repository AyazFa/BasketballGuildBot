using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BasketBotApi.Models.Commands;

/// <summary>
/// Команда завершения опроса для посещения тренировки
/// /sp - Stop Poll
/// </summary>
public class StopPollCommand : Command
{
    public override string Name => @"/sp";
    public override Task Execute(Message message, TelegramBotClient botClient, long chatId)
    {
        throw new System.NotImplementedException();
    }

    public override bool Contains(Message message)
    {
        throw new System.NotImplementedException();
    }
}