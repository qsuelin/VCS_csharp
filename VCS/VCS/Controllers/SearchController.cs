using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VCS.Data;
using VCS.Models;
using VCS.ViewModel;

namespace VCS.Controllers
{
    public class SearchController: Controller
    {
        private VideoDbContext context;
        private readonly UserManager<IdentityUser> _userManager;

        public SearchController(VideoDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            context = dbContext;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Results(string searchTerm)
        {
            List<Video> videos;
            List<ListViewModel> displayVideos = new List<ListViewModel>();

            if (string.IsNullOrEmpty(searchTerm))
            {
                videos = context.Videos
                    .ToList();

                foreach (var video in videos)
                {
                    List<VideoTag> videoTags = context.VideoTags
                        .Where(vt => vt.VideoId == video.Id)
                        .Include(vt => vt.Tag)
                        .ToList();

                    ListViewModel newDisplayVideo = new ListViewModel(video, videoTags);
                    displayVideos.Add(newDisplayVideo);
                }
            }

            else
            {
                List<Video> titleOrChannelFoundVideos = context.Videos
                    .Where(v => v.Title.Contains(searchTerm) || v.Channel.Contains(searchTerm))
                    .ToList();

                //List<Video> channelFoundVideos = context.Videos
                //    .Where(v => v.Channel.Contains(searchTerm))
                //    .ToList();

                List<VideoTag> videoTags = context.VideoTags
                    .Include(v => v.Video)
                    .Where(v => v.Tag.Name.Contains(searchTerm))
                    .ToList();

                List<Video> tagFoundVideos = new List<Video>();

                foreach (var video in videoTags)
                {
                    Video tagFoundVideo = context.Videos
                        .Single(v => v.Id == video.VideoId);

                    tagFoundVideos.Add(tagFoundVideo);
                }

                // union of 2 lists


                // only search in tags
                foreach (var video in videoTags)
                {
                    Video foundVideo = context.Videos
                        .Single(v => v.Id == video.VideoId);

                    List<VideoTag> displayTags = context.VideoTags
                        .Where(vt => vt.VideoId == foundVideo.Id)
                        .Include(vt => vt.Tag)
                        .ToList();

                    ListViewModel newDisplayVideo = new ListViewModel(foundVideo, displayTags);
                    displayVideos.Add(newDisplayVideo);
                }
            }

            ViewBag.videos = displayVideos;

            return View("Index");
        }

    }
}
