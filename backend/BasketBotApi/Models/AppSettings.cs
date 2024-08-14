namespace BasketBotApi.Models;

public abstract class AppSettings
{
    public static string Url { get; set; } = "https://BasketballGuildBot.somee.com";
    
    public static string Key { get; set; } = "5109422101:AAEG6S0XNhimPs6C3MPPSHifM4LBV8fYMYM";

    /// <summary>
    /// -1001730302996 - баскетбольная группа DreamTeam Ufa
    /// -1002211978434 - баскетбольная группа ГПН
    /// -654532921 - тестовая группа с ботом
    /// -956790495 - идентификатор бота
    /// </summary>
    public static long[] GuildChatIds { get; set; } = new[] { -1001730302996, -1002211978434, -654532921, -654532922};
}