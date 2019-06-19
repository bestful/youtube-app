using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webapi_core2.Models;

    public class myConnection : DbContext
    {
        public myConnection (DbContextOptions<myConnection> options)
            : base(options)
        {
        }

        public DbSet<webapi_core2.Models.Counter> Counter { get; set; }

        public DbSet<webapi_core2.Models.IteminVideosforUser> IteminVideosforUser { get; set; }

        public DbSet<webapi_core2.Models.User> User { get; set; }

        public DbSet<webapi_core2.Models.Video> Video { get; set; }

        public DbSet<webapi_core2.Models.VoteforVideo> VoteforVideo { get; set; }
    }
