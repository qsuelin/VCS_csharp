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
using X.PagedList;

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
        public IActionResult Index(int? page) //Add page para
        {
            var userId = _userManager.GetUserId(User);

            var pageNumber = page ?? 1;
            int pageSize = 30;
            //var videoList = context.Videos.ToPagedList(pageNumber, pageSize);

            List<Video> videoList = context.Videos.ToList();
            List<ListViewModel> displayVideos = new List<ListViewModel>();

            foreach (var video in videoList)
            {
                List<VideoTag> videoTags = context.VideoTags
                    .Where(vt => vt.VideoHash == video.Hash)
                    .Include(vt => vt.Tag)
                    .Include(vt => vt.Video)
                    .ToList();

                ListViewModel newDisplayJob = new ListViewModel(video, videoTags);
                displayVideos.Add(newDisplayJob);
            }

            ViewBag.videos = displayVideos;
            var onePageofVideos = displayVideos.ToPagedList(pageNumber, pageSize);
            
            return View(onePageofVideos);
        }

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
            List<VideoTag> videoTags = context.VideoTags
                .Where(vt => vt.VideoHash == theVideo.Hash)
                .Include(vt => vt.Video)
                .Include(vt => vt.Tag)
                .ToList();

            EditViewModel editViewModel = new EditViewModel(theVideo, videoTags);
            return View(editViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditViewModel editViewModel)
        {
            string hash = editViewModel.Hash;
            if (ModelState.IsValid)
            {
                string newTagName = editViewModel.TagName;
                int tagId;
                VideoTag videoTag;

                //input tag nonexists
                if (context.Tags.Where(t => t.Name == newTagName).SingleOrDefault() == null)
                {
                    Tag newTag = new Tag(newTagName);
                    tagId = newTag.Id;

                    videoTag = new VideoTag
                    {
                        VideoHash = hash,
                        Tag = newTag,
                        TagId = tagId
                    };

                    context.VideoTags.Add(videoTag);
                    context.SaveChanges();
                }
                // input tag exists
                else
                {
                    tagId = context.Tags.Where(t => t.Name == newTagName).Single().Id;

                    List<VideoTag> existingVideoTags = context.VideoTags
                    .Where(vt => vt.VideoHash == hash)
                    .Where(vt => vt.TagId == tagId)
                    .ToList();

                    // if pair nonexsits, add pair
                    if (existingVideoTags.Count == 0)
                    {
                        videoTag = new VideoTag
                        {
                            VideoHash = hash,
                            TagId = tagId
                        };

                        context.VideoTags.Add(videoTag);
                        context.SaveChanges();
                    }
                    
                }
            }
            return Redirect("/Video/Edit/" + editViewModel.VideoId);
        }

        //public IActionResult Results(string searchTerm)
        //{
        //    List<Video> videos;
        //    List<ListViewModel> displayVideos = new List<ListViewModel>();

        //    if (string.IsNullOrEmpty(searchTerm))
        //    {
        //        videos = context.Videos
        //            .ToList();

        //        foreach (var video in videos)
        //        {
        //            List<VideoTag> videoTags = context.VideoTags
        //                .Where(vt => vt.VideoId == video.Id)
        //                .Include(vt => vt.Tag)
        //                .ToList();

        //            ListViewModel newDisplayVideo = new ListViewModel(video, videoTags);
        //            displayVideos.Add(newDisplayVideo);
        //        }
        //    }

        //    else
        //    {
        //        videos = context.Videos
        //            .Where(v => v.Title.Contains(searchTerm))
        //            .ToList();

        //        List<VideoTag> videoTags = context.VideoTags
        //            .Where(v => v.Tag.Name.Contains(searchTerm))
        //            .Include(v => v.Video)
        //            .ToList();

        //        foreach (var video in videoTags)
        //        {
        //            Video foundVideo = context.Videos
        //                .Single(v => v.Id == video.VideoId);

        //            List<VideoTag> displayTags = context.VideoTags
        //                .Where(vt => vt.VideoId == foundVideo.Id)
        //                .Include(vt => vt.Tag)
        //                .ToList();

        //            ListViewModel newDisplayVideo = new ListViewModel(foundVideo, displayTags);
        //            displayVideos.Add(newDisplayVideo);
        //        }
        //    }

        //    ViewBag.videos = displayVideos;

        //    return View("Index");
        //}


    }
}
