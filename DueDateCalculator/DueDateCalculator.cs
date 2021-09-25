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

        private readonly int _workHoursAmount = 8;

        private readonly double _startTime = 9.00;

        private readonly double _endTime = 17.00;

        public DueDateCalculator()
        {

        }

        public DateTime CalculateDueDate(DateTime submitDate, TimeSpan turnaroundTime)
        {
            var endTime = CalculateExpectedEndTime(submitDate, turnaroundTime);

            var turnaroundTimeWorkDays = CalculateTurnaroundDays(submitDate, turnaroundTime);

            var dueDate = GetNextWorkingDayAfterPeriod(submitDate, (int)Math.Round(turnaroundTimeWorkDays + 0.49)).Date;

            var dueDateTime = dueDate.AddHours(endTime);

            return dueDateTime;
        }

        public double CalculateExpectedEndTime(DateTime submitDate, TimeSpan turnaroundTime)
        {
            var remainingTurnaroundTime = CalculateRemainingTurnaroundTime(submitDate, turnaroundTime);

            var excessHours = remainingTurnaroundTime % _workHoursAmount;

            var endTime = excessHours > 0 ? _startTime + excessHours : _endTime;

            endTime = excessHours < 0 ? _endTime + excessHours : endTime;

            return endTime;
        }

        public double CalculateTurnaroundDays(DateTime submitDate, TimeSpan turnaroundTime)
        {
            var remainingTurnaroundTime = CalculateRemainingTurnaroundTime(submitDate, turnaroundTime);

            var turnaroundTimeWorkDays = remainingTurnaroundTime / _workHoursAmount;

            return turnaroundTimeWorkDays;
        }

        public double CalculateRemainingTurnaroundTime(DateTime submitDate, TimeSpan turnaroundTime)
        {
            var hoursRemainingInSubmittedDate = _endTime - submitDate.TimeOfDay.TotalHours;

            var remainingTurnaroundTime = turnaroundTime.TotalHours - hoursRemainingInSubmittedDate;

            return remainingTurnaroundTime;
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
