using System;
using System.Collections.Generic;

namespace webapi.Models
{
    public partial class Counter
    {
        public string Type { get; set; }
        public string Fun { get; set; }
        public int Id { get; set; }
        public int? Value { get; set; }
    }
}
