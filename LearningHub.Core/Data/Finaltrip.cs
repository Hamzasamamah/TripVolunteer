using System;
using System.Collections.Generic;

namespace LearningHub.Core.Data
{
    public partial class Finaltrip
    {
        public Finaltrip()
        {
            Finalgalleries = new HashSet<Finalgallery>();
            Finalinvoices = new HashSet<Finalinvoice>();
            Finalpayments = new HashSet<Finalpayment>();
            Finaltestimonials = new HashSet<Finaltestimonial>();
            Finalusertrips = new HashSet<Finalusertrip>();
        }

        public decimal Tripid { get; set; }
        public string Tripname { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public string? Startdestination { get; set; }
        public string? Finaldestination { get; set; }
        public string Location { get; set; } = null!;
        public decimal Maximumparticipants { get; set; }
        public decimal? Currentparticipants { get; set; }
        public decimal Cost { get; set; }
        public string? Maplink { get; set; }
        public string Status { get; set; } = null!;
        public decimal Categoryid { get; set; }
        // Add these properties for latitude and longitude
        public decimal? Lat { get; set; }
        public decimal? Lng { get; set; }
        public string? Imagepath { get; set; }
        public virtual Finalcategory? Category { get; set; } = null!;
        public virtual ICollection<Finalgallery> Finalgalleries { get; set; }
        public virtual ICollection<Finalinvoice> Finalinvoices { get; set; }
        public virtual ICollection<Finalpayment> Finalpayments { get; set; }
        public virtual ICollection<Finaltestimonial> Finaltestimonials { get; set; }
        public virtual ICollection<Finalusertrip> Finalusertrips { get; set; }
    }
}
