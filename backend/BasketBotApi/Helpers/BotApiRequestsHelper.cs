using System.Net.Http;
using System.Threading.Tasks;
using BasketBotApi.Models;

namespace BasketBotApi.Helpers;

public static class BotApiRequestsHelper
{
    static HttpClient httpClient = new HttpClient();
    public static string HostAddress;
    
    internal static async Task<string> SetWebHook(string url)
    {
        HostAddress = url;
        return await GetWebHookResponse($"setwebhook?url={url}/api/message/update");
    }
    
    internal static async Task<string> RemoveWebHook()
    {
        return await GetWebHookResponse("setwebhook?remove");
    }
    
    internal static async Task<string> GetUpdates()
    {
        return await GetWebHookResponse("getUpdates");
    }    

    internal static async Task<string> GetWebHookResponse(string queryPath)
    {
        var queryString = $"https://api.telegram.org/bot{AppSettings.Key}/{queryPath}";
        var response = await httpClient.GetAsync(queryString);
        return await response.Content.ReadAsStringAsync();        
    }
}