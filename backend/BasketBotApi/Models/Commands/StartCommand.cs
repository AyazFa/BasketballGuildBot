using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

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

    public override async Task Execute(Message message, TelegramBotClient botClient, long chatId)
    {
        const string usageText = """
                                 <b><u>Commands</u></b>:
                                 /cp    - CreatePoll. Создать опрос. /cp1 - опрос для АСФ; /cp2 - опрос для Твой зал
                                 /tj    - TakeJersey. Отправка напоминания необходимости взять темную и светлую формы
                                 /cm    - CollectMoney. Отправка сообщения со сбором денег, /cmamount, где amount - сумма для сбора, например /cm300
                                 /sp    - StopPoll. Остановить опрос.
                                 /mt    - MakeTeams. Сформировать команды из проголосовавших в опросе.
                             """;
        var messageChatId = message.Chat.Id;
        await botClient.SendTextMessageAsync(messageChatId,
            usageText,
            parseMode: ParseMode.Html);
    }
}