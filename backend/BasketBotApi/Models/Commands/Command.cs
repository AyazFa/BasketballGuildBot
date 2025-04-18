﻿using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BasketBotApi.Models.Commands;

public abstract class Command
{
    public abstract string Name { get; }

    public abstract Task Execute(Message message, TelegramBotClient client, long chatId);

    public abstract bool Contains(Message message);
}