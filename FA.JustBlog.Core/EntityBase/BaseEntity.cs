
using FA.JustBlog.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.EntityBase
{
    public class BaseEntity : IBaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Status Status { get ; set ; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime CreatedOn { get ; set ; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime UpdatedOn { get ; set ; }
    }
}
