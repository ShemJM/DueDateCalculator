using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DueDateCalculator.Unit.Models
{
    public class TestIssue
    {
        public DateTime SubmitDate { get; set; }
        public double TurnaroundTime { get; set; }
        public DateTime ExpectedDueDate { get; set; }
        public TestIssue(DateTime submitDate, double turnaroundTime, DateTime expectedDueDate)
        {
            SubmitDate = submitDate;
            TurnaroundTime = turnaroundTime;
            ExpectedDueDate = expectedDueDate;
        }
    }
}
