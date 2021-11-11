using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repositories
{
    public class CommentRepository: GenericRepository<Comment>,ICommentRepository
    {
        public CommentRepository(JustBlogContext context):base(context)
        {

        }

        public IList<Comment> GetCommentsForPost(int postId)
        {
            return base.dbSet.Where(p => p.PostId == postId).ToList();
        }

        public IList<Comment> GetCommentsForPost(Post post)
        {
            return base.dbSet.Where(p => p.PostId == post.Id).ToList();
        }
        public override void Update(Comment entity)
        {
            base.Update(entity);
        }
    }
}
