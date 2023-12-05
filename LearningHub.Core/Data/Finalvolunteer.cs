using System;
using System.Collections.Generic;

namespace LearningHub.Core.Data
{
    public partial class Finalvolunteer
    {
        public decimal Volunteerid { get; set; }
        public decimal Usertripid { get; set; }
        public DateTime? Datejoined { get; set; }
        public decimal? Tripscount { get; set; }

        public virtual Finalusertrip Usertrip { get; set; } = null!;
    }
}
