using System;
using System.Collections.Generic;

namespace LearningHub.Core.Data
{
    public partial class Finalinvoice
    {
        public Finalinvoice()
        {
            Finalpayments = new HashSet<Finalpayment>();
        }

        public decimal Invoiceid { get; set; }
        public decimal Userid { get; set; }
        public decimal Tripid { get; set; }
        public decimal Amount { get; set; }
        public string? Invoicecontent { get; set; }
        public DateTime? Timestamp { get; set; }

        public virtual Finaltrip Trip { get; set; } = null!;
        public virtual Finaluser User { get; set; } = null!;
        public virtual ICollection<Finalpayment> Finalpayments { get; set; }
    }
}
