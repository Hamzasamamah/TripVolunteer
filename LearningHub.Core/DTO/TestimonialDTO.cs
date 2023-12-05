using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.DTO
{
    public class TestimonialDTO
    {
        public decimal UserId { get; set; }
        public decimal TripId { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
    }
}
