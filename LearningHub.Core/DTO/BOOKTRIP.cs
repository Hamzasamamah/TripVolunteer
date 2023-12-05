using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.DTO
{
    public class BOOKTRIP
    {
        public decimal Paymentid { get; set; }
        public decimal Userid { get; set; }
        public decimal Tripid { get; set; }
        public decimal? Paymentamount { get; set; }
        public long? Cardnumber { get; set; }
        public byte? Cvv { get; set; }
        public decimal? Amount { get; set; }
        public string? Holdname { get; set; }
        public bool? Isvolunteer { get; set; }
        public decimal Cost { get; set; }

        public string? Email { get; set; }


    }
}
