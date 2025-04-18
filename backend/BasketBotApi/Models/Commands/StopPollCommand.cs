using System;
using System.Threading.Tasks;
using BasketBotApi.Helpers;
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
    public override async Task<Message> Execute(Message message, TelegramBotClient botClient, long chatId)
    {
        Poll poll;
        try
        {
            poll =  await botClient.StopPollAsync(
                chatId: chatId,
                messageId: PollHelper.GetPollMessageId());
        }
        catch (Exception e)
        {
            return new Message();
        }

        return new Message
        {
            Poll = poll
        };
    }

    public override bool Contains(Message message)
    {
        if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
            return false;

        return message.Text!.Contains(this.Name);
    }
}