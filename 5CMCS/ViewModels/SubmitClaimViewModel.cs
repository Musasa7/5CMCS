using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace _5CMCS.ViewModels
{
    public class SubmitClaimViewModel
    {
        [Required, RegularExpression(@"^\d{4}-\d{2}$", ErrorMessage = "Use YYYY-MM (e.g., 2025-09)")]
        public string Month { get; set; } = "";

        [Required, Range(0.5, 300)]
        public double HoursWorked { get; set; }

        [Required, Range(1, 5000)]
        public double HourlyRate { get; set; }

        [MaxLength(500)]
        public string? Notes { get; set; }


        public string? DocumentPath { get; set; }

        public double TotalAmount => System.Math.Round(HoursWorked * HourlyRate, 2);
    }
}