using System;
using System.Collections.Generic;

namespace webapi.Models
{
    public partial class IteminVideosforUser
    {
        public int UserId { get; set; }
        public int VideoId { get; set; }

        public User User { get; set; }
        public Video Video { get; set; }
    }
}
