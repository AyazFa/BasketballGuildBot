using System;

namespace BasketBotApi.Helpers
{
    public static class QuestionHelper
    {
        public static string GetPollQuestionForPlace(GymType gymType, DateTime todayDate)
        {
            if (gymType == GymType.Asf)
            {
                return $"В четверг {GetTrainingDate(todayDate)} тренировка на АСФ:";
            }

            return $"Пока нет тренировки в это время";
        }

        public static DateTime GetTrainingDate(DateTime todayDate)
        {
            var delta = DayOfWeek.Thursday - todayDate.DayOfWeek;
            return todayDate
                .AddDays(delta >= 0 ? delta : (7 + delta)).AddHours(21).AddMinutes(30);
        }
    }
}