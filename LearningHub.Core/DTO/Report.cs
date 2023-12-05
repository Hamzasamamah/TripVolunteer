using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.DTO
{
    public class Report
    {
        public string Tripname { get; set; } = null!;
        // public string? Fullname { get; set; }
        // public string? Gender { get; set; }
        // public string? Phone { get; set; }
        public string Location { get; set; } = null!;
        public decimal Cost { get; set; }
        public string Status { get; set; } = null!;

        public decimal? Paymentamount { get; set; }
        public DateTime? Paymentdate { get; set; }

    }
}
