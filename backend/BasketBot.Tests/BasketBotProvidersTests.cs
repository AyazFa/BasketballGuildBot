using BasketBot.Providers;

namespace BasketBot.Tests;

public class BasketBotProvidersTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void BasketBotProvidersTests_GetChatMembersFromFile_Test()
    {
        var provider = new ChatMembersFileProvider();
        var result = provider.GetChatMembersFromFile();
        Assert.NotNull(result);
    }
    
    [Test]
    public void BasketBotProvidersTests_GetPlayersFromFile_Test()
    {
        var provider = new PlayersFileProvider();
        var result = provider.GetPlayers();
        Assert.NotNull(result);
    }    
}