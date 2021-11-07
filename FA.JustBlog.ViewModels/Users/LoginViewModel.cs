using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.ViewModels.Users
{
    public class LoginViewModel
    {
        [Display(Name = "UserName")]
        [Required(ErrorMessage = "UserName không được để trống")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password không được để trống")]
        public string Password { get; set; }
    }
}