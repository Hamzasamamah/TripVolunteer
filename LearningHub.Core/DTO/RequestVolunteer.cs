using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.DTO
{
    public class RequestVolunteer
    {
        public decimal userid { get; set; }
        public decimal Tripid { get; set; }
        public decimal Usertripid { get; set; }
        public decimal  Isvolunteer { get; set; }
    }
}
