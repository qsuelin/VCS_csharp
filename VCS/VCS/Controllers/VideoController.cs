using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VCS.Data;
using VCS.Models;
using VCS.ViewModel;

namespace VCS.Controllers
{
    //[Authorize]
    public class VideoController : Controller
    {
        private VideoDbContext context;
        private readonly UserManager<IdentityUser> _userManager;

        public VideoController(VideoDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            context = dbContext;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);

            List<Video> videoList = context.Videos.ToList();
            ListViewModel listViewModel = new ListViewModel(videoList);
            return View(listViewModel);
        }

        //[HttpGet]
        //public IActionResult Search()
        //{
            
        //    return View();
        //}

        //[AllowAnonymous]
        //[HttpPost]
        //public IActionResult Search(SearchViewModel searchViewModel)
        //{
        //    //var userId = _userManager.GetUserId(User);
        //    string _toSearch = searchViewModel.ToSearch;
        //    List<Video> videoList = context.Videos
        //        .Include(e => e.Tags)
        //        .Where(e => e.Title.Contains(_toSearch) || e.Tags.Contains(new Tag(_toSearch)))
        //        .ToList();
        //    return View(videoList);
        //}

        public IActionResult Detail(int id)
        {
            Video theVideo = context.Videos.Find(id);
      
            //DetailViewModel detailViewModel = new DetailViewModel(theVideo);
            return View(theVideo);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Video theVideo = context.Videos.Find(id);
            List<VideoTag> videoTags = context.VideoTags.ToList();

            EditViewModel editViewModel = new EditViewModel(theVideo, videoTags);
            return View(editViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditViewModel editViewModel)
        {
            if (ModelState.IsValid)
            {
                int videoId = editViewModel.VideoId;
                string newTagName = editViewModel.TagName;
                int tagId;

                if (context.Tags.Where(t => t.Name == newTagName).SingleOrDefault() == null)
                {
                    Tag newTag = new Tag(newTagName);
                    tagId = newTag.Id;
                } else
                {
                    tagId = context.Tags.Where(t => t.Name == newTagName).Single().Id;
                }

                VideoTag videoTag = new VideoTag
                {
                    VideoId = videoId,
                    TagId = tagId
                };

                context.VideoTags.Add(videoTag);
                context.SaveChanges();

            }
            return View(editViewModel);
        }

    }
}
