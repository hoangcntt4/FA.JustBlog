using FA.JustBlog.Core.Models;
using FA.JustBlog.ViewModels.Comment;
using FA.JustBlog.ViewModels.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Services.Comments
{
    public interface ICommentService
    {
        ResponseResult Create(CreateCommentViewAdminModel request);
        Comment Find(int id);
        //IEnumerable<PostViewClientModel> GetAll();
        //IEnumerable<PostViewModel> GetAllForAdmin();

        void Remove(int id);
        void Edit(Comment post);

        Comment GoToEdit(int id);
        IEnumerable<CommentViewAdmin> GetAllForAdmin();
    }
}
