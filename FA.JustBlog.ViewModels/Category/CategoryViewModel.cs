using FA.JustBlog.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.ViewModels.Category
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Tên danh mục")]
        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        [StringLength(225)]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime CreatedOn { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]

        public DateTime UpdatedOn { get; set; }
        [Required]
        public Status Status { get; set; }


    }
}
