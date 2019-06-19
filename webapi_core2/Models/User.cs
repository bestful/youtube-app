using System;
using System.Collections.Generic;

namespace webapi_core2.Models
{
    public partial class User
    {
        public User()
        {
            IteminVideosforUser = new HashSet<IteminVideosforUser>();
            VoteforVideo = new HashSet<VoteforVideo>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ICollection<IteminVideosforUser> IteminVideosforUser { get; set; }
        public ICollection<VoteforVideo> VoteforVideo { get; set; }
    }
}
