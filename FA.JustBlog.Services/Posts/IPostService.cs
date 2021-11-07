using FA.JustBlog.Core.Models;
using FA.JustBlog.ViewModels.Post;
using FA.JustBlog.ViewModels.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Services.Posts
{
    public interface IPostService
    {
        ResponseResult Create(CreatePostViewModel request);
        Post Find(int id);
        IEnumerable<PostViewClientModel> GetAll();
        IEnumerable<PostViewClientModel> LastestPost(); 
        IEnumerable<PostViewClientModel> MostViewedPosts(); 
        IEnumerable<PostViewClientModel> GetPostFromCategory(int categoryId); 
        IEnumerable<DropListPost> GetDopList(); 
        IEnumerable<PostViewModel> GetAllForAdmin();

        void Remove(int id);
        void Edit(Post post);

        Post GoToEdit(int id);



    }
}
