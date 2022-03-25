using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BasketBot.Helpers;
using Microsoft.Extensions.Configuration;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BasketBot
{
    public class Handlers
    {
        static readonly int[] guildChatIds = Program.Configuration.GetSection("GuildChatIds").Get<int[]>();
        
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var handler = update.Type switch
            {
                // UpdateType.Unknown:
                // UpdateType.ChannelPost:
                // UpdateType.EditedChannelPost:
                // UpdateType.ShippingQuery:
                // UpdateType.PreCheckoutQuery:
                // UpdateType.Poll:
                UpdateType.Message            => BotOnMessageReceived(botClient, update.Message!, cancellationToken),
                UpdateType.MyChatMember       => BotOnActionToChat(botClient, update.MyChatMember, cancellationToken),
                // UpdateType.EditedMessage      => BotOnMessageReceived(botClient, update.EditedMessage!),
                // UpdateType.CallbackQuery      => BotOnCallbackQueryReceived(botClient, update.CallbackQuery!),
                // UpdateType.InlineQuery        => BotOnInlineQueryReceived(botClient, update.InlineQuery!),
                // UpdateType.ChosenInlineResult => BotOnChosenInlineResultReceived(botClient, update.ChosenInlineResult!),
                // _                             => UnknownUpdateHandlerAsync(botClient, update)
            };

            try
            {
                await handler;
            }
            catch (Exception exception)
            {
                await HandleErrorAsync(botClient, exception, cancellationToken);
            }
        }

        private static async Task BotOnActionToChat(ITelegramBotClient botClient, ChatMemberUpdated myChat, CancellationToken cancellationToken)
        {
            var chatId = myChat.Chat.Id;
            var botChatId = myChat.From.Id;
            
            await botClient.SendTextMessageAsync(
                chatId: botChatId,
                text: "Bot added to Chat with Id:\n" + chatId,
                cancellationToken: cancellationToken);
        }

        public static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }

        private static async Task BotOnMessageReceived(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
        {
            // Only process text messages
            if (message.Type != MessageType.Text)
                return;

            var chatId = message.Chat.Id;
            var messageText = message.Text;

            Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");

            var sentMessage = messageText switch
            {
                "/sp" => await botClient.SendPollAsync(
                    chatId: guildChatIds[0],
                    isAnonymous: false,
                    question: QuestionHelper.GetPollQuestionForPlace(GymType.Asf),
                    options: new []
                    {
                        "Иду",
                        "Не иду"
                    },
                    cancellationToken: cancellationToken),
                _ => await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: "You said:\n" + messageText,
                    cancellationToken: cancellationToken),
            };
        }
    }
}