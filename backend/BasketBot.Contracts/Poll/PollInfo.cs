namespace BasketBot.Contracts.Poll;

public class PollInfo
{
    public string Id { get; set; }
    public string Question { get; set; }
    public List<Option> Options { get; set; }
    public short TotalVoterCount { get; set; }
    public bool IsClosed { get; set; }
    public bool IsAnonymous { get; set; }
    public string Type { get; set; }
    public bool AllowsMultipleAnswers { get; set; }    
}