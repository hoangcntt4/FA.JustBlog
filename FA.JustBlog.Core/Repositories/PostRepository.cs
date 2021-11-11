using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(JustBlogContext context) : base(context)
        {

        }
        public int CountPostsForCategory(string category)
        {
            return GetPostsByCategory(category).Count();
        }

        public int CountPostsForTag(string tag)
        {
            return GetPostsByTag(tag).Count();
        }

        public IList<Post> GetHighestPost(int size)
        {
            return base.dbSet.OrderByDescending(p => p.Rate()).Take(size).ToList();
        }

        public IList<Post> GetLastestPosts(int size)
        {
            return base.dbSet.OrderBy(p => p.PostedOn).Take(size).ToList();
        }

        public IList<Post> GetMostViewedPost(int size)
        {
            return base.dbSet.OrderByDescending(p => p.ViewCount).Take(size).ToList();
        }

        public IList<Post> GetPostsByCategory(string category)
        {
            return base.dbSet.Where(p => p.Category.Name == category).ToList();
        }

        public IList<Post> GetPostsByMonth(DateTime monthYear)
        {
            return base.dbSet.Where(p => p.PostedOn.Value.Year== monthYear.Year && p.PostedOn.Value.Month == monthYear.Month).ToList();
        }

        public IList<Post> GetPostsByTag(string tag)
        {
            return base.dbSet.ToList();
        }

        public IList<Post> GetPublishedPosts()
        {
            return base.dbSet.Where(p => p.Published == true).ToList();
        }

        public IList<Post> GetUnpublishedPosts()
        {
            return base.dbSet.Where(p => p.Published == false).ToList();
        }
        public override void Update(Post entity)
        {
            base.Update(entity);
        }
    }
}
