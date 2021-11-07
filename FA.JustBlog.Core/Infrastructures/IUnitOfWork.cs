
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Respositories;
using System;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Infrastructures
{
    public interface IUnitOfWork : IDisposable
    {

        ICategoryRespository CategoryRespository { get; }
        IPostRespository PostRespository { get; }
        ITagRespository TagRespository { get; }
        ICommentRespository CommentRespository { get; }

        JustBlogContext JustBlogContext { get; }

        int SaveChange();

        Task<int> SaveChangeAsync();
    }
}