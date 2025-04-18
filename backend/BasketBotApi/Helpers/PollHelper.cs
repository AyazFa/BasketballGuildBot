using System.IO;

namespace BasketBotApi.Helpers;

public static class PollHelper
{
    private static string fileName = "PollMessageId.txt";
    
    public static void SavePollMessageIdToFile(int messageId)
    {
        File.WriteAllText(fileName, messageId.ToString());
    }    
    
    public static int GetPollMessageId()
    {
        using StreamReader reader = new StreamReader(fileName);
        string text = reader.ReadToEnd();  
        return int.TryParse(text, out int i) ? i : 0;
    }
}