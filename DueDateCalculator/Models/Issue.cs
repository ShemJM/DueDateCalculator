using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DueDateCalculator.Models
{
    public class Issue
    {
        public int Id { get; set; }
        public DateTime SubmitDate { get; set; }
        public TimeSpan TurnaroundTime { get; set; }
        public DateTime DueDate { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }

        public Issue(TimeSpan turnaroundTime, DateTime? submitDate = null)
        {
            SubmitDate = submitDate ?? DateTime.Now;
            TurnaroundTime = turnaroundTime;
        }
    }
}