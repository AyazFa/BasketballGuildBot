using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BasketBotApi.Models.Commands;

/// <summary>
/// Команда для сообщения со сбором денег
/// /cmamount, где amount - сумма для сбора
/// Например /cm300
/// </summary>
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
        var messageText = message.Text;
        var amount = messageText!.Substring(messageText.IndexOf(Name, StringComparison.Ordinal) + Name.Length);
        if (string.IsNullOrEmpty(amount))
        {
            amount = "330";
        }
        await botClient.SendTextMessageAsync(AppSettings.GuildChatIds[0],
            $"Скидывайте по {amount}\u20bd @AyazFaizullin на карту Тиньков по номеру телефона +79279277179",
            parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
    }      
}