using BasketBot.Contracts.ChatMembers;

namespace BasketBot.Interfaces;

public interface IChatMembersFileInterface
{
    List<ChatMember>? GetChatMembersFromFile();
}