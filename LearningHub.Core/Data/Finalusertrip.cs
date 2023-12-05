using System;
using System.Collections.Generic;

namespace LearningHub.Core.Data
{
    public partial class Finalusertrip
    {
        public Finalusertrip()
        {
            Finalvolunteers = new HashSet<Finalvolunteer>();
        }

        public decimal Usertripid { get; set; }
        public decimal Isvolunteer { get; set; }
        public decimal Userid { get; set; }
        public decimal Tripid { get; set; }

        public virtual Finaltrip? Trip { get; set; } = null!;
        public virtual Finaluser? User { get; set; } = null!;
        public virtual ICollection<Finalvolunteer> Finalvolunteers { get; set; }
    }
}
