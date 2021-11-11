using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models;
using System.Collections.Generic;

namespace FA.JustBlog.Core.Repositories
{
    public interface ITagRepository : IGenericRepository<Tag>
    {
        Tag GetTagByUrlSlug(string urlSlug);
        IEnumerable<int> AddTagByString(string tags);
    }
}