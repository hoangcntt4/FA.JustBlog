using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.ViewModels.Category
{
    public class CategoryDetail
    {
        public int Id { get; set; }

        [Display(Name = "Tên danh mục")]
        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        [StringLength(225)]
        public string Name { get; set; }

        [Display(Name = "Seo Url")]
        [StringLength(225)]
        public string UrlSlug { get; set; }

        [Display(Name = "Mô tả")]
        [StringLength(1024, ErrorMessage = "Mô tả không được vượt quá 1024 ký tự")]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime CreatedOn { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]

        public DateTime UpdatedOn { get; set; }
    }
}
