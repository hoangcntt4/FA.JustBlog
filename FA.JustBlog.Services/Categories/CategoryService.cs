using AutoMapper;
using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.ViewModels.Category;
using FA.JustBlog.ViewModels.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Commom;

namespace FA.JustBlog.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public ResponseResult Create(CreateCategoryViewModel request)
        {
            try
            {
                var category = Mapper.Map<Category>(request);
                category.UrlSlug = SeoUrlHepler.FrientlyUrl(category.Name);
                this.unitOfWork.CategoryRepository.Add(category);
                this.unitOfWork.SaveChange();
                return new ResponseResult();
            }
            catch (Exception ex)
            {

                return new ResponseResult(ex.Message);
            }

        }

        public void Edit(Category category)
        {
            this.unitOfWork.CategoryRepository.Update(category);
            category.UrlSlug = SeoUrlHepler.FrientlyUrl(category.Name);
            category.UpdatedOn = DateTime.Now;
            this.unitOfWork.SaveChange();

        }

        public IEnumerable<CategoryViewModel> GetAll()
        {
            var categories = this.unitOfWork.CategoryRepository.GetAll();
            var categoryViewModels = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);

            return categoryViewModels;
        }
        public IEnumerable<CategoryDetail> GetAllDetail()
        {
            var categories = this.unitOfWork.CategoryRepository.GetAll();
            var categoryDetail = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDetail>>(categories);

            return categoryDetail;
        }

        public Category GetToEdit(int id)
        {
            var category = this.unitOfWork.CategoryRepository.GetAll().Where(c=>c.Id==id).FirstOrDefault();
            return category;
        }

        public void Remove(int id)
        {
            var category = this.unitOfWork.CategoryRepository.GetAll().Where(c => c.Id == id).FirstOrDefault();

            this.unitOfWork.CategoryRepository.Delete(category);
            this.unitOfWork.SaveChange();
        }
        public IEnumerable<Category> All()
        {
            var categies = this.unitOfWork.CategoryRepository.GetAll();

            return categies;
        }

        public Category Find(int id)
        {
            return this.unitOfWork.CategoryRepository.Find(c=>c.Id==id).FirstOrDefault();
        }

        public int GetId(string name)
        {
            var category = this.unitOfWork.CategoryRepository.Find(c=>c.Name==name).FirstOrDefault();
            return category.Id;
        }
    }
}
