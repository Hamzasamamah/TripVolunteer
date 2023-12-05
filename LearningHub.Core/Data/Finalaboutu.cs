using System;
using System.Collections.Generic;

namespace LearningHub.Core.Data
{
    public partial class Finalaboutu
    {
        public decimal ABOUT_US_ID { get; set; }
        public string? Paragraph { get; set; }
        public decimal? HOME_ID { get; set; }

        public virtual Finalhome? Home { get; set; }
    }
}
