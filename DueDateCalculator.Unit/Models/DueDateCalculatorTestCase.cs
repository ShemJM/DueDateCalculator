using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DueDateCalculator.Unit.Models
{
    public class DueDateCalculatorTestCase
    {
        public DueDateCalculatorTestCase(DateTime submitDate, TimeSpan turnaroundTime, DateTime expectedDueDate)
        {
            SubmitDate = submitDate;
            TurnaroundTime = turnaroundTime;
            ExpectedDueDate = expectedDueDate;
        }

        public DateTime SubmitDate { get; set; }
        public TimeSpan TurnaroundTime { get; set; }
        public DateTime ExpectedDueDate { get; set; }
    }
}
