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
        var mondayPoll = QuestionHelper.GetTrainingDate(DateTime.Today);
        Assert.AreEqual(DateTime.Today.AddDays(daysFromTodayTillThursday).AddHours(21).AddMinutes(30),mondayPoll);
        var tuesdayPoll = QuestionHelper.GetTrainingDate(DateTime.Today.AddDays(1));
        Assert.AreEqual(DateTime.Today.AddDays(daysFromTodayTillThursday).AddHours(21).AddMinutes(30),tuesdayPoll);  
        var wednesdayPoll = QuestionHelper.GetTrainingDate(DateTime.Today.AddDays(2));
        Assert.AreEqual(DateTime.Today.AddDays(daysFromTodayTillThursday).AddHours(21).AddMinutes(30),wednesdayPoll);
        var thursdayPoll = QuestionHelper.GetTrainingDate(DateTime.Today.AddDays(3));
        Assert.AreEqual(DateTime.Today.AddDays(daysFromTodayTillThursday).AddHours(21).AddMinutes(30),thursdayPoll); 
        var fridayPoll = QuestionHelper.GetTrainingDate(DateTime.Today.AddDays(-3));
        Assert.AreEqual(DateTime.Today.AddDays(daysFromTodayTillThursday).AddHours(21).AddMinutes(30),fridayPoll);
        var saturdayPoll = QuestionHelper.GetTrainingDate(DateTime.Today.AddDays(-2));
        Assert.AreEqual(DateTime.Today.AddDays(daysFromTodayTillThursday).AddHours(21).AddMinutes(30),saturdayPoll); 
        var sundayPoll = QuestionHelper.GetTrainingDate(DateTime.Today.AddDays(-1));
        Assert.AreEqual(DateTime.Today.AddDays(daysFromTodayTillThursday).AddHours(21).AddMinutes(30),sundayPoll);        
    }
}