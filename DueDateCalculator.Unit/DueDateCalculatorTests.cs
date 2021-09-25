using DueDateCalculator.Models;
using DueDateCalculator.Unit.Models;
using DueDateCalculator.Unit.TestData;
using System.Collections.Generic;
using Xunit;

namespace DueDateCalculator.Unit
{
    public class DueDateCalculatorTests
    {
        [Fact]
        public void DefaultDueDates_ShouldBeCorrect()
        {
            var calculator = new DueDateCalculator();

            foreach (var testCase in TestCases.DefaultTestCases)
            {
                var dueDate = calculator.CalculateDueDate(testCase.SubmitDate, testCase.TurnaroundTime);

                Assert.Equal(testCase.ExpectedDueDate, dueDate);
            }
        }

        [Fact]
        public void AssignmentCompanysDueDates_ShouldBeCorrect()
        {
            RunTestCases(Companies.AssignmentCompany, TestCases.AssignmentCompanyTestCases);
        }

        [Fact]
        public void TheFourDayWeekersDueDates_ShouldBeCorrect()
        {
            RunTestCases(Companies.TheFourDayWeekers, TestCases.FourDayWeekerTestCases);
        }

        private void RunTestCases(Company company, List<DueDateCalculatorTestCase> testCases)
        {
            var calculator = new DueDateCalculator().For(company);

            foreach (var testCase in testCases)
            {
                var dueDate = calculator.CalculateDueDate(testCase.SubmitDate, testCase.TurnaroundTime);

                Assert.Equal(testCase.ExpectedDueDate, dueDate);
            }
        }
    }
}