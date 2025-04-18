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
    public override async Task<Message> Execute(Message message, TelegramBotClient botClient, long chatId)
    {
        var messageText = message.Text;
        string gymCharCode;
        try
        {
            gymCharCode = messageText![3].ToString();
        }
        catch (Exception e)
        {
            if (messageText == Name)
            {
                gymCharCode = "1";
            }
            else
            {
                throw new Exception($"Не получилось обработать код зала. Ошибка: {e.Message}");
            }
        }
        
        if (!Int32.TryParse(gymCharCode, out var gymCode))
        {
            throw new Exception("Не получилось определить код зала");
        }
        
        var responseMessage = await botClient.SendPollAsync(
            chatId: chatId,
            isAnonymous: false,
            question: QuestionHelper.GetPollQuestionForPlace((GymType)gymCode, DateTime.Today),
            options: new []
            {
                "Иду",
                "Не иду"
            });
        
        PollHelper.SavePollMessageIdToFile(responseMessage.MessageId);
        return responseMessage;
    }

    public override bool Contains(Message message)
    {
        if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
            return false;

        return message.Text!.Contains(this.Name);
    }
}