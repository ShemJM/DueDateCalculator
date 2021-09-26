using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DueDateCalculator.Unit.Models
{
    public class DueDateCalculatorTestCase
    {
        public DueDateCalculator Calculator { get; set; } = new();

        public List<TestIssue> TestIssues { get; set; }
    }
}
