using System;
using System.Collections.Generic;

namespace LearningHub.Core.Data
{
    public partial class Finalpayment
    {
        public decimal Paymentid { get; set; }
        public decimal Userid { get; set; }
        public decimal Tripid { get; set; }
        public decimal? Paymentamount { get; set; }
        public DateTime? Paymentdate { get; set; }
        public decimal? Invoiceid { get; set; }

        public virtual Finalinvoice? Invoice { get; set; }
        public virtual Finaltrip Trip { get; set; } = null!;
        public virtual Finaluser User { get; set; } = null!;
    }
}
