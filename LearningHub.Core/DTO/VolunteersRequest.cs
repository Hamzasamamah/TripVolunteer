using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.DTO
{
    public class VolunteersRequest
    {
        public decimal Userid { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Fullname { get; set; }
        public string? Imagepath { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime? Datejoined { get; set; }
        public decimal? Roleid { get; set; }
        public decimal Usertripid { get; set; }
        public decimal Isvolunteer { get; set; }
        public decimal Tripid { get; set; }
        public string Tripname { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public string? Startdestination { get; set; }
        public string? Finaldestination { get; set; }
        public string Location { get; set; } = null!;
        public decimal Maximumparticipants { get; set; }
        public decimal? Currentparticipants { get; set; }
        public decimal Cost { get; set; }
        public string? Maplink { get; set; }
        public string Status { get; set; } = null!;
        public decimal Categoryid { get; set; }

    }
}
