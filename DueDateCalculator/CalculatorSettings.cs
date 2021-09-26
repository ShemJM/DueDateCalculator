using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DueDateCalculator
{
    public class CalculatorSettings
    {
        public DayOfWeek[] WorkDays { get; set; } = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };

        public double StartTime { get; set; } = 9.00;

        public double EndTime { get; set; } = 17.00;

        public double WorkHoursAmount => EndTime - StartTime;
    }
}