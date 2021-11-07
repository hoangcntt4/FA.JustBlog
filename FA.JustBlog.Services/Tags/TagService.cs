using AutoMapper;
using FA.JustBlog.Commom;
using FA.JustBlog.Core.Infrastructures;
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
    public class TagService : ITagService
    {
        private readonly IUnitOfWork unitOfWork;

        public TagService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public ResponseResult Create(CreateTagViewModel request)
        {

            try
            {
                var tag = Mapper.Map<Tag>(request);
                tag.UrlSlug = SeoUrlHepler.FrientlyUrl(tag.Name);
                this.unitOfWork.TagRespository.Add(tag);
                this.unitOfWork.SaveChange();
                return new ResponseResult();
            }
            catch (Exception ex)
            {

                return new ResponseResult(ex.Message);
            }
        }

        public Tag Find(int id)
        {
            return this.unitOfWork.TagRespository.Find(t => t.Id == id).FirstOrDefault();
        }

        public IEnumerable<CreateTagViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            var tag = this.unitOfWork.TagRespository.Find(t => t.Id == id).FirstOrDefault();
            this.unitOfWork.TagRespository.Delete(tag);
            this.unitOfWork.SaveChange();
        }
        public IEnumerable<CreateTagViewAdminModel> GetAllForAdmin()
        {
            var tags = this.unitOfWork.TagRespository.GetAll();
            var tagViewModels = Mapper.Map<IEnumerable<Tag>, IEnumerable<CreateTagViewAdminModel>>(tags);
            return tagViewModels;
        }
        public Tag GotoEdit(int id)
        {
            return this.unitOfWork.TagRespository.Find(t => t.Id == id).FirstOrDefault();
        }

        public void Edit(Tag tag)
        {
            this.unitOfWork.TagRespository.Update(tag);
            tag.UrlSlug = SeoUrlHepler.FrientlyUrl(tag.Name);
            tag.UpdatedOn = DateTime.Now;
            this.unitOfWork.SaveChange();
        }
    }
}
