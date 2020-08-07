using System;
using Microsoft.AspNetCore.Mvc;
using VCS.Data;

namespace VCS.Controllers
{
    public class VideoController: Controller
    {
        private VideoDbContext context;

        public VideoController(VideoDbContext dbContext)
        {
            context = dbContext;
        }
    }
}
