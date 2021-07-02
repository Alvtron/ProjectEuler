using System;
using ProjectEuler.Library;

namespace ProjectEuler.Solvers
{
    public class Solver_0019 : ISolver
    {
        public Answer Solve()
        {
            var start = new DateTime(1901, 1, 1);
            var end = new DateTime(2000, 12, 31);

            return CountWeekDayEveryDayOfTheMonth(start, end, 1, DayOfWeek.Sunday);
        }

        private static int CountWeekDayEveryDayOfTheMonth(DateTime start, DateTime end, int day, DayOfWeek dayOfWeek)
        {
            if (start > end)
            {
                throw new ArgumentException("start date is later than end date.", nameof(start));
            }

            var numDaysOfWeek = 0;
            var current = new DateTime(start.Year, start.Month, day);

            while (current < end)
            {
                if (current.DayOfWeek == dayOfWeek)
                {
                    numDaysOfWeek++;
                }

                current = current.AddMonths(1);
            }

            return numDaysOfWeek;
        }
    }
}
