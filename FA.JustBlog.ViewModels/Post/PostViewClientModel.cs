using FA.JustBlog.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.ViewModels.Post
{
    public class PostViewClientModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title không được để trống")]
        [StringLength(255, ErrorMessage = "Title không vượt quá 255 kí tự")]
        public string Title { get; set; }

        [Required]
        public DateTime PostedOn { get; set; }

        public int ViewCount { get; set; }

        public decimal rate;


        public string PostContent { get; set; }


    }
}
