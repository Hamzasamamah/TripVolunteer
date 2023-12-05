using System;
using System.Collections.Generic;

namespace LearningHub.Core.Data
{
    public partial class Finaltestimonial
    {
        public Finaltestimonial()
        {
            Finalgalleries = new HashSet<Finalgallery>();
        }

        public decimal Testimonialid { get; set; }
        public decimal Userid { get; set; }
        public decimal Tripid { get; set; }
        public string? Message { get; set; }
        public string? Status { get; set; }
        public DateTime? Dateposted { get; set; }

        public virtual Finaltrip Trip { get; set; } = null!;
        public virtual Finaluser User { get; set; } = null!;
        public virtual ICollection<Finalgallery> Finalgalleries { get; set; }
    }
}
