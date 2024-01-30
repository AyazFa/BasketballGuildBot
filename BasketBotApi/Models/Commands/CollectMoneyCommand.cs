using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BasketBotApi.Models.Commands;

public class CollectMoneyCommand : Command
{
    public override string Name => @"/cm";

    public override bool Contains(Message message)
    {
        if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
            return false;

        return message.Text!.Contains(this.Name);
    }

    public override async Task Execute(Message message, TelegramBotClient botClient)
    {
        await botClient.SendTextMessageAsync(AppSettings.GuildChatIds[1],
            "Скидывайте по 330\u20bd @AyazFaizullin на карту Тиньков по номеру телефона +79279277179",
            parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
    }      
}