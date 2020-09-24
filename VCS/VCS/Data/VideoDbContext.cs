using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VCS.Models;

namespace VCS.Data
{
    public class VideoDbContext: IdentityDbContext<IdentityUser>
    {
        public DbSet<Video> Videos { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<VideoTag> VideoTags { get; set; }
        public DbSet<WatchDir> WatchDirs { get; set; }

        public VideoDbContext(DbContextOptions<VideoDbContext> options)
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VideoTag>()
                .HasKey(et => new { et.VideoHash, et.TagId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
