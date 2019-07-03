using System;
using System.Collections.Generic;

namespace webapi.Models
{
    public partial class Favourite
    {
        public int UserId { get; set; }
        public int VideoId { get; set; }

        public double Avg {get; set;}

        // Copy from video model

        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Thubmail { get; set; }
        public string Description { get; set; }
    }
}
