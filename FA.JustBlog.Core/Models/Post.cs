using FA.JustBlog.Core.EntityBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Models
{
   public class Post : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Post()
        {
            PostTagMaps = new HashSet<PostTagMap>();
        }


        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(1024)]
        public string ShortDescription { get; set; }

        [Column(TypeName = "ntext")]
        public string PostContent { get; set; }

        [StringLength(255)]
        public string UrlSlug { get; set; }

        public bool? Published { get; set; }

        public DateTime? PostedOn { get; set; }

        public DateTime? Modified { get; set; }
        public int ViewCount { get; set; }
        public int RateCount { get; set; }
        public int TotalRate { get; set; }
        public decimal Rate()
        {
            if (TotalRate == 0 || RateCount == 0)
                return 0;
            return Convert.ToDecimal(1.0 * TotalRate / RateCount);
        }
        public int CategoryId { get; set; }
        
        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PostTagMap> PostTagMaps { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
