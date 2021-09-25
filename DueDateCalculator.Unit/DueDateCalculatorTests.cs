using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DueDateCalculator.Unit
{
    public class DueDateCalculatorTests
    {
        [Fact]
        public void DueDate_ShouldBeCorrect()
        {
            var calculator = new DueDateCalculator();

            foreach (var testCase in TestCases)
            {
                var dueDate = calculator.CalculateDueDate(testCase.SubmitDate, testCase.TurnaroundTime);

                Assert.Equal(testCase.ExpectedDueDate, dueDate);
            }
        }

        private List<DueDateCalculatorTestCase> TestCases => new()
        {
            new DueDateCalculatorTestCase(new DateTime(2021, 9, 21, 14, 00, 0), new TimeSpan(00, 10, 30), new DateTime(2021, 9, 21, 14, 10, 30)),
            new DueDateCalculatorTestCase(new DateTime(2021, 9, 21, 14, 12, 0), new TimeSpan(16, 00, 0), new DateTime(2021, 9, 23, 14, 12, 0)),
            new DueDateCalculatorTestCase(new DateTime(2021, 9, 21, 16, 59, 0), new TimeSpan(8, 0, 0), new DateTime(2021, 9, 22, 16, 59, 0)),
            new DueDateCalculatorTestCase(new DateTime(2021, 9, 21, 16, 59, 0), new TimeSpan(16, 0, 0), new DateTime(2021, 9, 23, 16, 59, 0)),
            new DueDateCalculatorTestCase(new DateTime(2021, 9, 24, 12, 00, 0), new TimeSpan(12, 00, 0), new DateTime(2021, 9, 27, 16, 0, 0)),
            new DueDateCalculatorTestCase(new DateTime(2021, 9, 27, 12, 00, 0), new TimeSpan(8, 30, 0), new DateTime(2021, 9, 28, 12, 30, 0)),
            new DueDateCalculatorTestCase(new DateTime(2021, 9, 27, 9, 00, 0), new TimeSpan(120, 00, 0), new DateTime(2021, 10, 15, 17, 0, 0)),
            new DueDateCalculatorTestCase(new DateTime(2021, 9, 27, 9, 00, 0), new TimeSpan(8, 00, 0), new DateTime(2021, 9, 27, 17, 0, 0)),
            new DueDateCalculatorTestCase(new DateTime(2021, 9, 27, 9, 00, 0), new TimeSpan(40, 00, 0), new DateTime(2021, 10, 1, 17, 0, 0)),
            new DueDateCalculatorTestCase(new DateTime(2021, 9, 27, 9, 00, 0), new TimeSpan(160, 00, 0), new DateTime(2021, 10, 22, 17, 0, 0)),
            new DueDateCalculatorTestCase(new DateTime(2021, 9, 27, 9, 00, 0), new TimeSpan(2, 00, 30), new DateTime(2021, 9, 27, 11, 00, 30)),
            new DueDateCalculatorTestCase(new DateTime(2021, 9, 27, 9, 00, 0), new TimeSpan(2, 00, 0), new DateTime(2021, 9, 27, 11, 00, 0)),
            new DueDateCalculatorTestCase(new DateTime(2021, 9, 27, 9, 00, 0), new TimeSpan(1, 45, 0), new DateTime(2021, 9, 27, 10, 45, 0)),
            new DueDateCalculatorTestCase(new DateTime(2021, 9, 27, 9, 00, 0), new TimeSpan(1, 00, 0), new DateTime(2021, 9, 27, 10, 00, 0)),
            new DueDateCalculatorTestCase(new DateTime(2021, 9, 27, 9, 00, 0), new TimeSpan(0, 45, 0), new DateTime(2021, 9, 27, 9, 45, 0)),
            new DueDateCalculatorTestCase(new DateTime(2021, 12, 31, 9, 00, 0), new TimeSpan(15, 00, 0), new DateTime(2022, 01, 03, 16, 00, 0)),
            new DueDateCalculatorTestCase(new DateTime(2021, 12, 24, 9, 00, 0), new TimeSpan(40, 00, 0), new DateTime(2021, 12, 30, 17, 00, 0))
        };

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
}
