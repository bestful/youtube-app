using System;
using System.Collections.Generic;

namespace webapi.Models
{
    public partial class User
    {
        public User()
        {
            item = new HashSet<item>();
            VoteforVideo = new HashSet<VoteforVideo>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ICollection<item> item { get; set; }
        public ICollection<VoteforVideo> VoteforVideo { get; set; }
    }
}
