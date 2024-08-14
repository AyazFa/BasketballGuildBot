using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BasketBotApi.Models.Commands;

/// <summary>
/// Команда напоминания необходимости взять темную и светлую формы
/// </summary>
public class TakeJerseyCommand : Command
{
    public override string Name => @"/tj";

    public override bool Contains(Message message)
    {
        if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
            return false;

        return message.Text!.Contains(this.Name);
    }

    public override async Task Execute(Message message, TelegramBotClient botClient)
    {
        await botClient.SendTextMessageAsync(AppSettings.GuildChatIds[0],
            "\u2757\ufe0fВозьмите по светлой и темной футболке (не цветные)",
            parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
    }    
}