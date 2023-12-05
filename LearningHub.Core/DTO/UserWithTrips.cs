using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using System;

namespace LearningHub.Core.DTO
{
    public class UserWithTrips
    {

    
        public decimal UserId { get; set; }
        public string Username { get; set; } = null!;
        public string? FullName { get; set; }
        public string? ImagePath { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime? DateJoined { get; set; }
        public bool? IsVolunteer { get; set; }
        public string TripName { get; set; } = null!;
        public DateTime TripStartDate { get; set; }
       
      
    }
}

