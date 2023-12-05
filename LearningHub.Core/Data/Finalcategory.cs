using System;
using System.Collections.Generic;

namespace LearningHub.Core.Data
{
    public partial class Finalcategory
    {
        public Finalcategory()
        {
            Finaltrips = new HashSet<Finaltrip>();
        }

        public decimal Categoryid { get; set; }
        public string Categoryname { get; set; } = null!;

        public virtual ICollection<Finaltrip> Finaltrips { get; set; }
    }
}
