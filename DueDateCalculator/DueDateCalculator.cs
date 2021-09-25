using DueDateCalculator.Models;
using System;

namespace DueDateCalculator
{
    public class DueDateCalculator
    {
        private DayOfWeek[] _workDays = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };

        private int _workDaysCount => _workDays.Length;

        private double _workHoursAmount => _endTime - _startTime - _breakAllowance;

        private double _startTime = 9.00;

        private double _endTime = 17.00;

        private double _breakAllowance = 0.00;

        public DueDateCalculator()
        {

        }

        public DueDateCalculator For(Company company)
        {
            _workDays = company.WorkingDays;
            _startTime = company.StartTime;
            _endTime = company.EndTime;
            _breakAllowance = company.BreakAllowance;

            return this;
        }

        public DateTime CalculateDueDate(DateTime submitDate, TimeSpan turnaroundTime)
        {
            var endTime = CalculateExpectedEndTime(submitDate, turnaroundTime);

            var turnaroundTimeWorkDays = CalculateTurnaroundDays(submitDate, turnaroundTime);

            var dueDate = GetNextWorkingDayAfterPeriod(submitDate, (int)Math.Round(turnaroundTimeWorkDays + 0.49)).Date;

            var dueDateTime = dueDate.AddHours(endTime);

            return dueDateTime;
        }

        public DateTime CalculateDueDate(Issue issue) => CalculateDueDate(issue.SubmitDate, issue.TurnaroundTime);

        public void CalculateAndSetDueDate(Issue issue) => issue.DueDate = CalculateDueDate(issue.SubmitDate, issue.TurnaroundTime);

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
            var weeks = days > 7 ? Math.Round(days / 7.00) : 0;
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
