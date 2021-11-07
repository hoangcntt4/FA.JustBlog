using FA.JustBlog.Core.Models;
using FA.JustBlog.ViewModels.Results;
using FA.JustBlog.ViewModels.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Services.Tags
{
    public interface ITagService
    {
        ResponseResult Create(CreateTagViewModel request);
        Tag Find(int id);
        void Remove(int id);
        IEnumerable<CreateTagViewAdminModel> GetAllForAdmin();

        Tag GotoEdit(int id);
        void Edit(Tag tag);
    }
}
