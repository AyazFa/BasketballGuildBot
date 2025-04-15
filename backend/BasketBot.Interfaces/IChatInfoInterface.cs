using BasketBot.Contracts.Poll;

namespace BasketBot.Interfaces;

public interface IChatInfoInterface
{
    PollInfo GetLastPollInfo();
}