using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

    public class youtubeappContect : DbContext
    {
        public youtubeappContect (DbContextOptions<youtubeappContect> options)
            : base(options)
        {
        }

        public DbSet<webapi.Models.Favourite> Favourite { get; set; }
    }
