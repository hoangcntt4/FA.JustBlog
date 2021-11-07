using FA.JustBlog.Core.Models;
using FA.JustBlog.Services.Categories;
using FA.JustBlog.Services.Posts;
using FA.JustBlog.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Web.Areas.Admin.Controllers
{
    public class PostController : BaseController
    {
        // GET: Admin/Post
        private readonly IPostService postService;
        private readonly ICategoryService categoryService;

        public PostController(IPostService postService, ICategoryService categoryService)
        {
            this.postService = postService;
            this.categoryService = categoryService;
        }
        public ActionResult Index()
        {
            var list = this.postService.GetAllForAdmin();
            return View(list);
        }
        public ActionResult Create()
        {
            var categories = this.categoryService.GetAll();
          //  ViewBag.categories = categoryIds;
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(CreatePostViewModel post)
        {
            if (!ModelState.IsValid)
            {
                return View(post);
            }
            var categories = this.categoryService.GetAll();
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name", post.CategoryId);
            var response = this.postService.Create(post);
            if (response.IsSuccessed)
            {

                return RedirectToAction(nameof(Index));
            }
            
            ModelState.AddModelError(string.Empty, response.ErrorMessage);
            return View(post);
        }

        public ActionResult Details(int id)
        {

            var post = this.postService.Find(id);
            var category = this.categoryService.Find((int)post.CategoryId);
            ViewBag.categoryName = category.Name;
            return View(post);
        }

        public ActionResult Delete(int id)
        {
            this.postService.Remove(id);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {

            var post = this.postService.GoToEdit(id);
            ViewBag.status = post.Status;
            ViewBag.published = post.Published;
            ViewBag.Modifiled = post.Modified;
            ViewBag.postedOn = post.PostedOn;
            ViewBag.viewCount = post.ViewCount;
            ViewBag.rateCount = post.RateCount;
            ViewBag.totalRate = post.TotalRate;
            ViewBag.createdOn = post.CreatedOn;

            var categories = this.categoryService.GetAll();
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name", post.CategoryId);
            return View(post);
        }
        [HttpPost]
        public ActionResult Edit(Post post)
        {
            var categories = this.categoryService.GetAll();
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name", post.CategoryId);
            this.postService.Edit(post);
            return RedirectToAction("Index");
        }
        public ActionResult Login()
        {
            return View();
        }

        
    }
}