using Telegram.Bot;

namespace BasketBotApi.Helpers;

public static class MakeTeamsHelper
{
    public static string GetLastPoll()
    {
        BotApiRequestsHelper.RemoveWebHook();
        var updates = BotApiRequestsHelper.GetUpdates();
        BotApiRequestsHelper.SetWebHook(BotApiRequestsHelper.HostAddress);
        return updates.Result; 
    }
}