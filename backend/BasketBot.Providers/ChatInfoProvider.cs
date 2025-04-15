using System.Text.Json;
using BasketBot.Contracts.Poll;
using BasketBot.Interfaces;
using Newtonsoft.Json;

namespace BasketBot.Providers;

public class ChatInfoProvider : IChatInfoInterface
{
    public PollInfo GetLastPollInfo()
    {
        using StreamReader reader = new StreamReader("ChatUpdates.json");
        string json = reader.ReadToEnd();
        var lastPollInfo = JsonConvert.DeserializeObject<PollInfo>(json);
        return lastPollInfo!;   
    }
}