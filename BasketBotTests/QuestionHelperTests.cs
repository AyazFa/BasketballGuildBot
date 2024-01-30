using System.Globalization;
using BasketBotApi.Helpers;

namespace BasketBotTests;

public class QuestionHelperTests
{
    const int daysFromTodayTillThursday = 2;
    
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void GetTrainingDayTest()
    {
        var formattedDate = DateTime.ParseExact("2/1/2024 9:30:00 PM", "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
        var mondayPoll = QuestionHelper.GetTrainingDate(DateTime.Today);
        Assert.AreEqual(DateTime.Today.AddDays(daysFromTodayTillThursday).AddHours(21).AddMinutes(30).ToString(),mondayPoll);
        var tuesdayPoll = QuestionHelper.GetTrainingDate(DateTime.Today.AddDays(1));
        Assert.AreEqual(DateTime.Today.AddDays(daysFromTodayTillThursday).AddHours(21).AddMinutes(30).ToString(),tuesdayPoll);  
        var wednesdayPoll = QuestionHelper.GetTrainingDate(DateTime.Today.AddDays(2));
        Assert.AreEqual(DateTime.Today.AddDays(daysFromTodayTillThursday).AddHours(21).AddMinutes(30).ToString(),wednesdayPoll);
        var thursdayPoll = QuestionHelper.GetTrainingDate(DateTime.Today.AddDays(3));
        Assert.AreEqual(DateTime.Today.AddDays(daysFromTodayTillThursday).AddHours(21).AddMinutes(30).ToString(),thursdayPoll); 
        var fridayPoll = QuestionHelper.GetTrainingDate(DateTime.Today.AddDays(-3));
        Assert.AreEqual(DateTime.Today.AddDays(daysFromTodayTillThursday).AddHours(21).AddMinutes(30).ToString(),fridayPoll);
        var saturdayPoll = QuestionHelper.GetTrainingDate(DateTime.Today.AddDays(-2));
        Assert.AreEqual(DateTime.Today.AddDays(daysFromTodayTillThursday).AddHours(21).AddMinutes(30).ToString(),saturdayPoll); 
        var sundayPoll = QuestionHelper.GetTrainingDate(DateTime.Today.AddDays(-1));
        Assert.AreEqual(DateTime.Today.AddDays(daysFromTodayTillThursday).AddHours(21).AddMinutes(30).ToString(),sundayPoll);  
    }
}