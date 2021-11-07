using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.ViewModels.Users
{
    public class CreateUserViewModel
    {
        [Display(Name ="Email")]
        [Required(ErrorMessage ="Email không được để trống")]
        public string Email { get; set; }

        [Display(Name = "Tài khoản")]
        [Required(ErrorMessage = "Tài khoản không được để trống")]
        public string UserName { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string Password { get; set; }
    }
}