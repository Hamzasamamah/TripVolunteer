using System;
using System.Collections.Generic;

namespace LearningHub.Core.Data
{
    public partial class Finalvisacard
    {
        public int Visaid { get; set; }
        public long? Cardnumber { get; set; }
        public byte? Cvv { get; set; }
        public decimal? Amount { get; set; }
        public string? Holdname { get; set; }
    }
}
