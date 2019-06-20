using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace webapi_core2.Models
{
    public partial class VoteforVideo
    {
        [Key]
        public int VideoId { get; set; }
        [Key]
        public int UserId { get; set; }
        public int? Mark { get; set; }

        public User User { get; set; }
        public Video Video { get; set; }
    }
}
