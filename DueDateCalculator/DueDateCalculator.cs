using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DueDateCalculator
{
    public class DueDateCalculator
    {
        public CalculatorSettings Settings { get; set; }

        public DueDateCalculator()
        {
            Settings = new();
        }

        public DueDateCalculator(CalculatorSettings settings)
        {
            Settings = settings;
        }

        public DateTime CalculateDueDate(DateTime submitDate, double turnaroundTimeHours)
        {
            var endDateTime = submitDate.AddHours(turnaroundTimeHours);
            var endOfDay = submitDate.Date.AddHours(Settings.EndTime);

            if(endDateTime > endOfDay)
            {
                var remainingTime = endDateTime - endOfDay;
                var remainingHours = remainingTime.TotalHours;
                var remainingDays = (int)Math.Round(remainingHours / Settings.WorkHoursAmount + 0.49);
                var excessHours = remainingHours % Settings.WorkHoursAmount;
                var endTime = excessHours > 0 ? Settings.StartTime + excessHours : Settings.EndTime;
                endDateTime = GetNextWorkingDayAfterPeriod(submitDate, remainingDays).Date.AddHours(endTime);
            }

            return endDateTime;
        }

        public DateTime GetNextWorkingDayAfterPeriod(DateTime date, int days)
        {
            var weeks = days > Settings.WorkDays.Length ? Math.Round((days / (double)Settings.WorkDays.Length) - 0.49) : 0;
            var dayIndex = (int)date.DayOfWeek + days;

            while (dayIndex > Settings.WorkDays.Length)
            {
                dayIndex -= Settings.WorkDays.Length;
            }

            while (date.DayOfWeek != Settings.WorkDays[dayIndex - 1])
            {
                date = date.AddDays(1);
            }

            return date.AddDays(weeks * 7);
        }
    }
}