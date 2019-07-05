using System;
using System.Collections.Generic;

namespace webapi.Models
{
    public partial class Favourite
    {
        public int UserId { get; set; }
        public int VideoId { get; set; }

        public double Avg {get; set;}

        // public int OwnerMark {get; set;}

        // Copy from video model
        
        public string Title { get; set; }
        public string Link { get; set; }
        public string Thubmail { get; set; }
        public string Description { get; set; }
    }
}
