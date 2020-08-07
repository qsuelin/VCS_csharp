using System;
using Microsoft.AspNetCore.Mvc;

namespace VCS.Controllers
{
    public class VideoController: Controller
    {
        private VideoDbContext context;

        public VideoController()
        {
        }
    }
}
