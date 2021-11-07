using FA.JustBlog.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.ViewModels.Comment
{
    public class CommentViewAdmin
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        [MaxLength(225, ErrorMessage = "Tên không được quá 225 kí tự")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        public string Email { get; set; }
       
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime CreatedOn { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]

        public DateTime UpdatedOn { get; set; }

        public Status Status { get; set; }
    }
}
