using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.DTO
{
    public class TestimonialRequest
    {
        public decimal Userid { get; set; }
        public string Username { get; set; } = null!;
        public string? Imagepath { get; set; }

        public string? Fullname { get; set; }
        public string? Email { get; set; }
        public decimal Testimonialid { get; set; }
        public decimal Tripid { get; set; }
        public string? Message { get; set; }
        public string? Status { get; set; }
        public DateTime? Dateposted { get; set; }
       
        public string Tripname { get; set; } = null!;
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
       
       
    }
}
