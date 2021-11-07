using FA.JustBlog.Core.Models;
using FA.JustBlog.Services.Comments;
using FA.JustBlog.Services.Posts;
using FA.JustBlog.ViewModels.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Web.Areas.Admin.Controllers
{
    public class CommentController : BaseController
    {
        // GET: Admin/Comment
        private readonly ICommentService commentService;
        private readonly IPostService postService;

        public CommentController(ICommentService commentService, IPostService postService)
        {
            this.commentService = commentService;
            this.postService = postService;
        }
        public ActionResult Index()
        {
            var comments = this.commentService.GetAllForAdmin();
            return View(comments);
        }
        [ValidateInput(true)]
        public ActionResult Create()
        {
            var posts = this.postService.GetAll();
            ViewBag.PostId = new SelectList(posts, "Id", "Title"); 
            return View();
        }
        [HttpPost]
        public ActionResult Create(CreateCommentViewAdminModel comment)
        {
            if (!ModelState.IsValid)
            {
                return View(comment);
            }
            var posts = this.postService.GetAll();
            ViewBag.PostId = new SelectList(posts, "Id", "Title", comment.PostId);
            var response = this.commentService.Create(comment);
            if (response.IsSuccessed)
            {

                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError(string.Empty, response.ErrorMessage);
            return View(comment);

        }
        public ActionResult Edit(int id)
        {
            var comment = this.commentService.GoToEdit(id);
            ViewBag.createdOn = comment.CreatedOn;
            ViewBag.status = comment.Status;
            ViewBag.CommentTime = comment.CommentTime;
            var posts = this.postService.GetAll();
            ViewBag.PostId = new SelectList(posts, "Id", "Title", comment.PostId);
            return View(comment);
        }
        [HttpPost]
        public ActionResult Edit(Comment comment)
        {
            var posts = this.postService.GetAll();
            ViewBag.PostId = new SelectList(posts, "Id", "Title", comment.PostId);
            this.commentService.Edit(comment);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var comment = this.commentService.Find(id);
            return View(comment);
        }

        public ActionResult Delete(int id)
        {
            var comment = this.commentService.Find(id);
            this.commentService.Remove(comment.Id);
            return RedirectToAction("Index");
        }
    }
}