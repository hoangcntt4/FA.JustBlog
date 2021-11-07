using FA.JustBlog.Core.Models;
using FA.JustBlog.Services.Categories;
using FA.JustBlog.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Web.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public ActionResult Index()
        {

            var categories = this.categoryService.GetAll();

            return View(categories);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateCategoryViewModel category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            var response = this.categoryService.Create(category);
            if (response.IsSuccessed)
            {

                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError(string.Empty, response.ErrorMessage);
            return View(category);
        }
        public ActionResult Details(int id)
        {
            var category = this.categoryService.GetAllDetail().Where(c => c.Id == id).FirstOrDefault();
            return View(category);
        }

        public ActionResult Edit(int id)
        {
            var category = this.categoryService.GetToEdit(id);
            ViewBag.status = category.Status;
            ViewBag.createdOn = category.CreatedOn;
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            this.categoryService.Edit(category);
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Delete(int id)
        {

            this.categoryService.Remove(id);
            return RedirectToAction("Index");

        }
    }
}