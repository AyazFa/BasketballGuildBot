﻿namespace BasketBotApi.Models;

public class AppSettings
{
    // public static string Url { get; set; } = "https://2d94-188-234-148-249.ngrok-free.app/{0}";
    
    public static string Url { get; set; } = "http://BasketballGuildBot.somee.com/{0}";
    
    public static string Key { get; set; } = "5109422101:AAEG6S0XNhimPs6C3MPPSHifM4LBV8fYMYM";

    /// <summary>
    /// -1001730302996 - баскетбольная группа
    /// -654532921 - тестовая группа с ботом
    /// -956790495 - идентификатор бота
    /// </summary>
    public static long[] GuildChatIds { get; set; } = new[] { -1001730302996, -654532921, -654532922};
}