using AutoMapper;
using FA.JustBlog.Commom;
using FA.JustBlog.Core.Infrastructures;
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
    public class PostService : IPostService

    {
        private readonly IUnitOfWork unitOfWork;

        public PostService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public ResponseResult Create(CreatePostViewModel request)
        {
            try
            {
                //1. add tag vao database
                var tagIds = this.unitOfWork.TagRepository.AddTagByString(request.Tags);
                // 2. create postTag
                var postTags = new List<PostTagMap>();
                foreach (var tagId in tagIds)
                {
                    var postTag = new PostTagMap()
                    {
                        TagId = tagId
                    };
                    postTags.Add(postTag);
                }
                var post = new Post()
                {
                    Title = request.Title,
                    UrlSlug = SeoUrlHepler.FrientlyUrl(request.Title),
                    PostContent = request.PostContent,
                    CategoryId = request.CategoryId,
                    ViewCount = request.ViewCount,
                    RateCount = request.RateCount,
                    TotalRate = request.TotalRate,
                    ShortDescription = request.ShortDescription,
                    PostTagMaps=postTags
                };
                this.unitOfWork.PostRepository.Add(post);
                this.unitOfWork.SaveChange();
                return new ResponseResult();

            }
            catch (Exception ex)
            {

                return new ResponseResult(ex.Message);
            }

        }

        public IEnumerable<PostViewClientModel> GetAll()
        {
            var posts = this.unitOfWork.PostRepository.GetAll();
            var postViewModels = Mapper.Map<IEnumerable<Post>, IEnumerable<PostViewClientModel>>(posts);

            return postViewModels;
        }

        public IEnumerable<PostViewModel> GetAllForAdmin()
        {
            var posts = this.unitOfWork.PostRepository.GetAll();
            var postViewModels = Mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(posts);

            return postViewModels;
        }

        public Post Find(int id)
        {
            return this.unitOfWork.PostRepository.Find(p => p.Id == id).FirstOrDefault();

        }

        public void Remove(int id)
        {
            var post = this.unitOfWork.PostRepository.Find(p => p.Id == id).FirstOrDefault();
            this.unitOfWork.PostRepository.Delete(post);
            this.unitOfWork.SaveChange();

        }

        public void Edit(Post post)
        {
            this.unitOfWork.PostRepository.Update(post);
            post.UrlSlug = SeoUrlHepler.FrientlyUrl(post.Title);
            post.UpdatedOn = DateTime.Now;
            this.unitOfWork.SaveChange();
        }

        public Post GoToEdit(int id)
        {
            return this.unitOfWork.PostRepository.Find(p => p.Id == id).FirstOrDefault();
        }

        public IEnumerable<DropListPost> GetDopList()
        {
            var posts = this.unitOfWork.PostRepository.GetAll();
            var DropListPost = Mapper.Map<IEnumerable<Post>, IEnumerable<DropListPost>>(posts);
            return DropListPost;
        }

        public IEnumerable<PostViewClientModel> LastestPost()
        {
            var posts = this.unitOfWork.PostRepository.GetAll().OrderByDescending(p => p.PostedOn).Take(5);
            var postViewModels = Mapper.Map<IEnumerable<Post>, IEnumerable<PostViewClientModel>>(posts);
            return postViewModels;
        }

        public IEnumerable<PostViewClientModel> MostViewedPosts()
        {
            var posts = this.unitOfWork.PostRepository.GetAll().OrderByDescending(p => p.ViewCount).Take(5);
            var postViewModels = Mapper.Map<IEnumerable<Post>, IEnumerable<PostViewClientModel>>(posts);
            return postViewModels;
        }

        public IEnumerable<PostViewClientModel> GetPostFromCategory(int categoryId)
        {
            var posts = this.unitOfWork.PostRepository.GetAll().Where(p => p.CategoryId == categoryId);
            return Mapper.Map<IEnumerable<Post>, IEnumerable<PostViewClientModel>>(posts);

        }
    }
}
