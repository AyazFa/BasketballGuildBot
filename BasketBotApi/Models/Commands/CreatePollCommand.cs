using System;
using System.Threading.Tasks;
using BasketBotApi.Helpers;
using Microsoft.Extensions.Configuration;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BasketBotApi.Models.Commands;

public class CreatePollCommand : Command
{
    public override string Name => @"/cp";
    public override async Task Execute(Message message, TelegramBotClient client)
    {
        var chatId = message.Chat.Id;
        var messageText = message.Text;
        
        await client.SendPollAsync(
            chatId: AppSettings.GuildChatIds[0],
            isAnonymous: false,
            question: QuestionHelper.GetPollQuestionForPlace(GymType.Asf, DateTime.Today),
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