using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using webapi.Models;

namespace webapi.Models
{
    public partial class youtubeappContext : DbContext
    {
        public youtubeappContext()
        {
        }

        public youtubeappContext(DbContextOptions<youtubeappContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Counter> Counter { get; set; }
        public virtual DbSet<item> item { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Video> Video { get; set; }
        public virtual DbSet<VoteforVideo> VoteforVideo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=root;database=youtube-app;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Counter>(entity =>
            {
                entity.HasKey(e => new { e.Type, e.Fun, e.Id });

                entity.ToTable("counter", "youtube-app");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Fun)
                    .HasColumnName("fun")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<item>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.VideoId });

                entity.ToTable("itemin_videosfor_user", "youtube-app");

                entity.HasIndex(e => e.VideoId)
                    .HasName("fk_itemIn_videosFor_user_video1_idx");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.VideoId)
                    .HasColumnName("video_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.item)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_itemIn_videosFor_user_user1");

                entity.HasOne(d => d.Video)
                    .WithMany(p => p.item)
                    .HasForeignKey(d => d.VideoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_itemIn_videosFor_user_video1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user", "youtube-app");

                entity.HasIndex(e => e.Username)
                    .HasName("username_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Video>(entity =>
            {
                entity.ToTable("video", "youtube-app");

                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasColumnName("link")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Thubmail)
                    .HasColumnName("thubmail")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(90)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VoteforVideo>(entity =>
            {
                entity.HasKey(e => new { e.VideoId, e.UserId });

                entity.ToTable("votefor_video", "youtube-app");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_vote_user_idx");

                entity.Property(e => e.VideoId)
                    .HasColumnName("video_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Mark)
                    .HasColumnName("mark")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.VoteforVideo)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_vote_user");

                entity.HasOne(d => d.Video)
                    .WithMany(p => p.VoteforVideo)
                    .HasForeignKey(d => d.VideoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_vote_video1");
            });

            modelBuilder.Query<Favourite>(query =>
            {
                query.ToView("favourite");

                query.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                query.Property(e => e.VideoId)
                    .HasColumnName("video_id")
                    .HasColumnType("int(11)");

                query.Property(e => e.Avg)
                    .HasColumnName("avg")
                    .HasColumnType("double");

                // Pasted from video
                query.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                query.Property(e => e.Link)
                    .IsRequired()
                    .HasColumnName("link")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                query.Property(e => e.Thubmail)
                    .HasColumnName("thubmail")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                query.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(90)
                    .IsUnicode(false);
            });


        }

        public virtual DbQuery<Favourite> Favourite {get; set;}

    }
}
