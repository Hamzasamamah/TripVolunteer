using System;
using System.Collections.Generic;

namespace LearningHub.Core.Data
{
    public partial class Finalcontactu
    {
        public decimal CONTACT_US_ID { get; set; }
        public string? Paragraph { get; set; }
        public decimal? HOME_ID { get; set; }
        public string? phone_num { get; set; }
        public string? Email { get; set; }

        public virtual Finalhome? Home { get; set; }
    }
}
