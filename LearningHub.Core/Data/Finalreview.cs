using System;
using System.Collections.Generic;

namespace LearningHub.Core.Data
{
    public partial class Finalreview
    {
        public decimal Reviewid { get; set; }
        public string? Message { get; set; }
        public string? Stars { get; set; }
        public string? Status { get; set; }
        public DateTime? Dateposted { get; set; }
    }
}
