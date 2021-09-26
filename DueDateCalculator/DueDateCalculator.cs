using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DueDateCalculator
{
    public class DueDateCalculator
    {
        private readonly DayOfWeek[] _workDays = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };

        private int _workDaysCount => _workDays.Length;

        private double _workHoursAmount => _endTime - _startTime;

        private readonly double _startTime = 9.00;

        private readonly double _endTime = 17.00;

        public DueDateCalculator()
        {

        }

        public DateTime CalculateDueDate(DateTime submitDate, double turnaroundTimeHours)
        {
            var endDateTime = submitDate.AddHours(turnaroundTimeHours);
            var endOfDay = submitDate.Date.AddHours(_endTime);

            if(endDateTime > endOfDay)
            {
                var remainingTime = endDateTime - endOfDay;
                var remainingHours = remainingTime.TotalHours;
                var remainingDays = (int)Math.Round(remainingHours / _workHoursAmount + 0.49);
                var excessHours = remainingHours % _workHoursAmount;
                var endTime = excessHours > 0 ? _startTime + excessHours : _endTime;
                endDateTime = GetNextWorkingDayAfterPeriod(submitDate, remainingDays).Date.AddHours(endTime);

            }

            return endDateTime;
        }

        public DateTime GetNextWorkingDayAfterPeriod(DateTime date, int days)
        {
            var weeks = days > _workDaysCount ? Math.Round((days / (double)_workDaysCount) - 0.49) : 0;
            var dayIndex = (int)date.DayOfWeek + days;

            while (dayIndex > _workDaysCount)
            {
                dayIndex -= _workDaysCount;
            }

            while (date.DayOfWeek != _workDays[dayIndex - 1])
            {
                date = date.AddDays(1);
            }

            return date.AddDays(weeks * 7);
        }
    }
}