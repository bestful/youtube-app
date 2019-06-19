using System;
using System.Collections.Generic;

namespace webapi_core2.Models
{
    public partial class VoteforVideo
    {
        public int VideoId { get; set; }
        public int UserId { get; set; }
        public int? Mark { get; set; }

        public User User { get; set; }
        public Video Video { get; set; }
    }
}
