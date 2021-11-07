using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.ViewModels.Category
{
    public class CreateCategoryViewModel
    {
        [Display(Name = "Tên danh mục")]
        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(225)]
        public string Name { get; set; }

        [Display(Name = "Seo Url")]
        [StringLength(225)]
        public string UrlSlug { get; set; }

        [Display(Name = "Mô tả")]
        [StringLength(1024, ErrorMessage = "Mô tả không được để trống")]
        public string Description { get; set; }

    }
}
