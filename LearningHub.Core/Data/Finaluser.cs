using System;
using System.Collections.Generic;

namespace LearningHub.Core.Data
{
    public partial class Finaluser
    {
        public Finaluser()
        {
            Finalinvoices = new HashSet<Finalinvoice>();
            Finalpayments = new HashSet<Finalpayment>();
            Finaltestimonials = new HashSet<Finaltestimonial>();
            Finalusertrips = new HashSet<Finalusertrip>();
        }

        public decimal Userid { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Fullname { get; set; }
        public string? Imagepath { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime? Datejoined { get; set; }
        public decimal? Roleid { get; set; }

        public virtual Finaluserrole? Role { get; set; } = null!;
        public virtual ICollection<Finalinvoice> Finalinvoices { get; set; }
        public virtual ICollection<Finalpayment> Finalpayments { get; set; }
        public virtual ICollection<Finaltestimonial> Finaltestimonials { get; set; }
        public virtual ICollection<Finalusertrip> Finalusertrips { get; set; }
    }
}
