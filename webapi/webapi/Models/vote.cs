//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace webapi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class vote
    {
        public int video_id { get; set; }
        public int user_id { get; set; }
        public Nullable<int> mark { get; set; }
    }
}