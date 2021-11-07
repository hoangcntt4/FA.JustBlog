using FA.JustBlog.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Web.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session["USER"] = null;
            return View("Index");
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            Session.Add("USER", model);
            return RedirectToAction("Index", "Home");
        }
    }
}