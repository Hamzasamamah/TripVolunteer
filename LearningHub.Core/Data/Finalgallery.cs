using System;
using System.Collections.Generic;

namespace LearningHub.Core.Data
{
    public partial class Finalgallery
    {
        public decimal Galleryid { get; set; }
        public decimal Tripid { get; set; }
        public decimal Testimonialid { get; set; }
        public string? Imagepath { get; set; }

        public virtual Finaltestimonial Testimonial { get; set; } = null!;
        public virtual Finaltrip Trip { get; set; } = null!;
    }
}
