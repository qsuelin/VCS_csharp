using System;
using Microsoft.EntityFrameworkCore;

namespace VCS.Data
{
    public class VideoDbContext:DbContext
    {
        public VideoDbContext(DbContextOptions<VideoDbContext> options):base(options)
        {
        }
    }
}
