using FA.JustBlog.Core.Models;
using FA.JustBlog.Services.Posts;
using FA.JustBlog.Services.Tags;
using FA.JustBlog.ViewModels.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Web.Areas.Admin.Controllers
{
    public class TagController : BaseController
    {
        // GET: Admin/Tag
        private readonly ITagService tagService;
        private readonly IPostService postService;
        public TagController(ITagService tagService, IPostService postService)

        {
            this.tagService = tagService;
            this.postService = postService;
        }

        public ActionResult Index()
        {
            var tags = this.tagService.GetAllForAdmin();
            return View(tags);
        }

        public ActionResult Details(int id)
        {
            var tag = this.tagService.Find(id);
            return View(tag);
        }
        public ActionResult Edit(int id)
        {
            var tag = this.tagService.GotoEdit(id);
            ViewBag.status = tag.Status;
            ViewBag.createdOn = tag.CreatedOn;
            var posts = this.postService.GetDopList();
            ViewBag.dropListPost = posts;
            return View(tag);
        }
        [HttpPost]
        public ActionResult Edit(Tag tag)
        {
            this.tagService.Edit(tag);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            this.tagService.Remove(id);
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(CreateTagViewModel tag)
        {
            if (!ModelState.IsValid)
            {
                return View(tag);
            }
            var response = this.tagService.Create(tag);
            if (response.IsSuccessed)
            {

                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError(string.Empty, response.ErrorMessage);
            return View(tag);
        }
    }
}