using DueDateCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DueDateCalculator.Unit.TestData
{
    public static class Companies
    {
        public readonly static Company AssignmentCompany = new("AssignmentCompany", new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday }, 09.00, 17.00, 0);

        public readonly static Company TheFourDayWeekers = new("TheFourDayWeekers", new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday }, 09.00, 17.00, 0);

        public readonly static Company TheWeekenders = new("TheWeekenders", new DayOfWeek[] { DayOfWeek.Saturday, DayOfWeek.Sunday }, 09.00, 17.00, 0);
    }
}