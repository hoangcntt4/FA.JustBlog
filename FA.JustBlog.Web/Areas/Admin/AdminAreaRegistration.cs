using System.Web.Mvc;

namespace FA.JustBlog.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
              //  new { action = "Index", id = UrlParameter.Optional },
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "FA.JustBlog.Web.Areas.Admin.Controllers" }
            );
        }
    }
}