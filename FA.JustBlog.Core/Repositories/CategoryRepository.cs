using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Respositories
{
    class CategoryRepository: GenericRepository<Category>,ICategoryRespository
    {
        public CategoryRepository(JustBlogContext context) : base(context)
        {

        }
        public override void Update(Category entity)
        {
            base.Update(entity);
        }
    }
}
