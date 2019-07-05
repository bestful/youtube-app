using System;
using System.Collections.Generic;

namespace webapi.Models
{
    public partial class Video
    {
        public Video()
        {
            item = new HashSet<item>();
            VoteforVideo = new HashSet<VoteforVideo>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Thubmail { get; set; }
        public string Description { get; set; }

        public ICollection<item> item { get; set; }
        public ICollection<VoteforVideo> VoteforVideo { get; set; }
    }
}
