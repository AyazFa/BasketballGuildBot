using BasketBot.Contracts.ChatMembers;
using BasketBot.Interfaces;
using Newtonsoft.Json;

namespace BasketBot.Providers;

public class ChatMembersFileProvider : IChatMembersFileInterface
{
    public List<ChatMember>? GetChatMembersFromFile()
    {
        List<ChatMember>? chatMembers = new List<ChatMember>();

        using StreamReader reader = new StreamReader("Members.json");
        string json = reader.ReadToEnd();  
        chatMembers = JsonConvert.DeserializeObject<List<ChatMember>>(json);
        
        return chatMembers;
    }
}