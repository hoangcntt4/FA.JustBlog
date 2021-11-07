using FA.JustBlog.Core.Models;
using FA.JustBlog.ViewModels.Category;
using FA.JustBlog.ViewModels.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Services.Categories
{
    public interface ICategoryService
    {
        ResponseResult Create(CreateCategoryViewModel request );

        IEnumerable<CategoryViewModel> GetAll();

        IEnumerable<CategoryDetail> GetAllDetail();

        void Edit(Category category);
        Category GetToEdit(int id);
        void Remove(int id);
        IEnumerable<Category> All();
        Category Find(int id);

        int GetId(string name);
    }
}
