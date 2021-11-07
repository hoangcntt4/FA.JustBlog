using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.ViewModels.Comment
{
    public class CreateCommentViewAdminModel
    {
        [Required(ErrorMessage = "Tên không được để trống")]
        [MaxLength(225, ErrorMessage = "Tên không được quá 225 kí tự")]
      
        public string Name { get; set; }

        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        public string Email { get; set; }

        public int PostId { get; set; }

        public string CommentHeader { get; set; }

        [Required(ErrorMessage = "Comment không được để trống")]
        [MaxLength(225, ErrorMessage = "Comment được vượt quá 225 kí tự")]
      
        public string CommentText { get; set; }
        public DateTime CommentTime { get; set; }

       
    }
}
