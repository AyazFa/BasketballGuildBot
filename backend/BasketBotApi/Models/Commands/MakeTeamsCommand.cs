using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BasketBotApi.Models.Commands;

/// <summary>
/// Команда формирования команд на основе рейтинга игроков
/// </summary>
public class MakeTeamsCommand : Command
{
    public override string Name => "/mt";
    public override Task Execute(Message message, TelegramBotClient client, long chatId)
    {
        throw new System.NotImplementedException();
    }

    public override bool Contains(Message message)
    {
        if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
            return false;

        return message.Text!.Contains(this.Name);
    }
}