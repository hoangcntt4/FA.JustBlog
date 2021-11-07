using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.ViewModels.Tag
{
   public  class CreateTagViewModel
    {
        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(225)]
        public string Name { get; set; }
        [StringLength(225)]

        [Display(Name = "Seo Url")]
        public string UrlSlug { get; set; }
        [Display(Name = "Mô tả")]
        [StringLength(1024, ErrorMessage = "Mô tả không được vượt quá 1024 ký tự")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Số lượng không được để trống !")]
        public int Count { get; set; }
       
    }
}
