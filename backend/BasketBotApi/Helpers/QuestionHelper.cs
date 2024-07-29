using System;

namespace BasketBotApi.Helpers
{
    public static class QuestionHelper
    {
        public static string GetPollQuestionForPlace(GymType gymType, DateTime todayDate)
        {
            var trainingDate = GetTrainingStringDate(gymType, todayDate);
            var day = trainingDate.Day < 10 ? string.Concat("0", trainingDate.Day) : trainingDate.Day.ToString();
            var month = trainingDate.Month < 10 ? string.Concat("0", trainingDate.Month) : trainingDate.Month.ToString();            
            switch (gymType)
            {
                case GymType.Asf:
                    return  $"В четверг {day}.{month}.{trainingDate.Year} в 21:30 тренировка на АСФ:";                    
                case GymType.YourGym:
                    return  $"Во вторник {day}.{month}.{trainingDate.Year} в 22:00 тренировка в с/з Твой Зал:";                    
                default:
                    return $"Пока нет тренировки в это время";
            }
        }

        public static DateTime GetTrainingStringDate(GymType gymType, DateTime todayDate)
        {
            int delta;
            switch (gymType)
            {
                case GymType.Asf:
                    delta = DayOfWeek.Thursday - todayDate.DayOfWeek;
                    return todayDate.AddDays(delta >= 0 ? delta : (7 + delta)).AddHours(21).AddMinutes(30);
                case GymType.YourGym:
                    delta = DayOfWeek.Tuesday - todayDate.DayOfWeek;
                    return todayDate.AddDays(delta >= 0 ? delta : (7 + delta)).AddHours(20).AddMinutes(0);                    
                default:
                    return DateTime.Today;
            }
        }
    }
}