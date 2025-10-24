using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5CMCS.Models
{
    public class Claim
    {
        public int ClaimId { get; set; }
        public int LecturerId { get; set; }

        public string Month { get; set; } = "";
        public double HoursWorked { get; set; }
        public double HourlyRate { get; set; }
        public string Notes { get; set; } = "";
        public string? DocumentName { get; set; }
        public string Status { get; set; } = "Pending";

        public double TotalAmount => HoursWorked * HourlyRate;

        // here Navigation
        public Lecturer? Lecturer { get; set; }
    }
}
