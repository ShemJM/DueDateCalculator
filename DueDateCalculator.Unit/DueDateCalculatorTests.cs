using DueDateCalculator.Unit.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace DueDateCalculator.Unit
{
    public class DueDateCalculatorTests
    {
        [Fact]
        public void DueDates_ShouldBeCorrect() => TestData.TestCases.ForEach(t => t.TestIssues.ForEach(i => Assert.Equal(i.ExpectedDueDate, t.Calculator.CalculateDueDate(i.SubmitDate, i.TurnaroundTime))));
    }
}