using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DueDateCalculator.Models
{
    public class Company
    {
        public string Name { get; private set; }

        public DayOfWeek[] WorkingDays { get; private set; } = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };

        public double StartTime { get; private set; }
        public double EndTime { get; private set; }
        public double BreakAllowance { get; private set; }
        public double DailyWorkingHours => EndTime - StartTime - BreakAllowance;

        private List<Issue> _submittedIssues = new();
        public ReadOnlyCollection<Issue> Issues { get => _submittedIssues.AsReadOnly(); }

        public DueDateCalculator IssueDueDateCalculator => new DueDateCalculator().For(this);

        public Company(string name, DayOfWeek[] workingDays, double startTime, double endTime, double breakAllowance)
        {
            Name = name;
            WorkingDays = workingDays;
            StartTime = startTime;
            EndTime = endTime;
            BreakAllowance = breakAllowance;
        }

        public Issue SubmitIssue(Issue issue)
        {
            IssueDueDateCalculator.CalculateAndSetDueDate(issue);
            issue.Id = _submittedIssues.OrderBy(i => i.Id).Last().Id + 1;
            _submittedIssues.Add(issue);
            return issue;
        }
    }
}