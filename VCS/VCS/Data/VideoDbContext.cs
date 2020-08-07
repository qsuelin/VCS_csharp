using System;
using Microsoft.EntityFrameworkCore;
using VCS.Models;

namespace VCS.Data
{
    public class VideoDbContext:DbContext
    {
        public DbSet<Video> Videos { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<VideoTag> VidioTags { get; set; }

        public VideoDbContext(DbContextOptions<VideoDbContext> options)
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VideoTag>()
                .HasKey(et => new { et.VideoId, et.TagId });
        }
    }
}
