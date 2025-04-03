using System;
using System.Threading.Tasks;
using BasketBotApi.Helpers;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BasketBotApi.Models.Commands;

/// <summary>
/// Команда создания опроса для посещения тренировки
/// /cp1 - опрос для АСФ; /cp2 - опрос для Твой зал
/// </summary>
public class CreatePollCommand : Command
{
    public override string Name => @"/cp";
    public override async Task Execute(Message message, TelegramBotClient client, long chatId)
    {
        var messageText = message.Text;
        var gymCharCode = messageText![3].ToString();
        if (!Int32.TryParse(gymCharCode, out var gymCode))
        {
            throw new Exception("Не получилось определить код зала");
        }
        
        await client.SendPollAsync(
            chatId: chatId,
            isAnonymous: false,
            question: QuestionHelper.GetPollQuestionForPlace((GymType)gymCode, DateTime.Today),
            options: new []
            {
                "Иду",
                "Не иду"
            });
    }

    public override bool Contains(Message message)
    {
        if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
            return false;

        return message.Text!.Contains(this.Name);
    }
}