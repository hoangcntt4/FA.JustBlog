using FA.JustBlog.Services.Categories;
using FA.JustBlog.Services.Posts;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Web.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        private readonly IPostService postService;
        private readonly ICategoryService categoryService;

        public PostController(IPostService postService, ICategoryService categoryService)
        {
            this.postService = postService;
            this.categoryService = categoryService;
        }
        public ActionResult Index(int? page)
        {
            var postViewModels = this.postService.GetAll();
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(postViewModels.ToPagedList(pageNumber,pageSize));
        }

    }
}