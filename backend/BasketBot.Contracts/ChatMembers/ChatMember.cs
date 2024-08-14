using Newtonsoft.Json;

namespace BasketBot.Contracts.ChatMembers;

public class ChatMember
{
    [JsonProperty("user")]
    public User User { get; set; }
}