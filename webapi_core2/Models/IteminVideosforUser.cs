using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace webapi_core2.Models
{
    public partial class IteminVideosforUser
    {
        [Key]
        public int UserId { get; set; }
        [Key]
        public int VideoId { get; set; }

        public User User { get; set; }
        public Video Video { get; set; }
    }
}
