using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Respositories
{
    public interface IPostRespository:IGenericRepository<Post>
    {
        IList<Post> GetPublishedPosts();
        IList<Post> GetUnpublishedPosts();
        IList<Post> GetLastestPosts(int size);
        IList<Post> GetPostsByMonth(DateTime monthYear);
        int CountPostsForCategory(string category);
        IList<Post> GetPostsByCategory(string category);
        int CountPostsForTag(string tag);
        IList<Post> GetPostsByTag(string tag);
        IList<Post> GetMostViewedPost(int size);
        IList<Post> GetHighestPost(int size);


    }
}
