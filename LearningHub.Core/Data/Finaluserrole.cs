using System;
using System.Collections.Generic;

namespace LearningHub.Core.Data
{
    public partial class Finaluserrole
    {
        public Finaluserrole()
        {
            Finalusers = new HashSet<Finaluser>();
        }

        public decimal Roleid { get; set; }
        public string Rolename { get; set; } = null!;

        public virtual ICollection<Finaluser> Finalusers { get; set; }
    }
}
