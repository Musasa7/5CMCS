using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5CMCS.ViewModels
{
    public class ClaimReviewViewModel
    {
        public int ClaimId { get; set; }
        public string Lecturer { get; set; } = "";
        public string Month { get; set; } = "";
        public double HoursWorked { get; set; }
        public double HourlyRate { get; set; }
        public double TotalAmount { get; set; }
        public string? Notes { get; set; }
        public string? DocumentName { get; set; }
        public string Status { get; set; } = "Pending";
    }
}