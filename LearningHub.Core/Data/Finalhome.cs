using System;
using System.Collections.Generic;

namespace LearningHub.Core.Data
{
    public partial class Finalhome
    {
        public Finalhome()
        {
            Finalaboutus = new HashSet<Finalaboutu>();
            Finalcontactus = new HashSet<Finalcontactu>();
        }

        public decimal HOME_ID { get; set; }
        public string? Paragraph { get; set; }

        public virtual ICollection<Finalaboutu> Finalaboutus { get; set; }
        public virtual ICollection<Finalcontactu> Finalcontactus { get; set; }
    }
}
