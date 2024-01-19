using System;

namespace BasketBotApi.Helpers
{
    public static class QuestionHelper
    {
        public static string GetPollQuestionForPlace(GymType gymType)
        {
            if (gymType == GymType.Asf)
            {
                return $"В четверг {GetTrainingDate(gymType)} тренировка на АСФ:";
            }

            return $"Пока нет тренировки в это время";
        }

        private static DateTime GetTrainingDate(GymType gymType)
        {
            DateTime trainingDate = new DateTime();
            if (gymType == GymType.Asf)
            {
                var today = DateTime.Today.DayOfWeek;
                switch (today)
                {
                    case DayOfWeek.Thursday:
                        trainingDate = DateTime.Today;
                        break;
                    case < DayOfWeek.Thursday:
                        trainingDate = DateTime.Today.AddDays((double) DateTime.Today.DayOfWeek +
                                                              (DayOfWeek.Thursday - today));
                        break;
                    case > DayOfWeek.Thursday:
                        trainingDate = DateTime.Today.AddDays((double) DateTime.Today.DayOfWeek +
                                                              (DayOfWeek.Saturday - today));
                        break;
                }
            }

            return trainingDate.AddHours(21).AddMinutes(30);
        }
    }
}