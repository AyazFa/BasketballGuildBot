using System;
using System.Globalization;

namespace BasketBotApi.Helpers
{
    public static class QuestionHelper
    {
        public static string GetPollQuestionForPlace(GymType gymType, DateTime todayDate)
        {
            if (gymType == GymType.Asf)
            {
                var trainingDate = GetTrainingDate(todayDate);
                var day = trainingDate.Day < 10 ? string.Concat("0", trainingDate.Day) : trainingDate.Day.ToString();
                var month = trainingDate.Month < 10 ? string.Concat("0", trainingDate.Month) : trainingDate.Month.ToString();
                return $"В четверг {day}.{month}.{trainingDate.Year} в 21:30 тренировка на АСФ:";
            }

            return $"Пока нет тренировки в это время";
        }

        public static DateTime GetTrainingDate(DateTime todayDate)
        {
            var delta = DayOfWeek.Thursday - todayDate.DayOfWeek;
            return todayDate.AddDays(delta >= 0 ? delta : (7 + delta)).AddHours(21).AddMinutes(30);
        }
    }
}