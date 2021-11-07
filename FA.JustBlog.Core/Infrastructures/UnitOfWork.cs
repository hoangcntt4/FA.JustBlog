
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Respositories;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JustBlogContext context;
        private ICategoryRespository categoryRespository;
        private IPostRespository postRespository;
        private ITagRespository tagRespository;
        private ICommentRespository commentRespository;

        public UnitOfWork(JustBlogContext context)
        {
            this.context = context;
        }

        public ICategoryRespository CategoryRespository
        {
            get
            {
                if (this.categoryRespository == null)
                {
                    this.categoryRespository = new CategoryRepository(this.context);
                }
                return this.categoryRespository;
            }
        }

        public IPostRespository PostRespository
        {
            get
            {
                if (this.postRespository == null)
                {
                    this.postRespository = new PostRepository(this.context);
                }
                return this.postRespository;
            }
        }

        public ITagRespository TagRespository
        {
            get
            {
                if (this.tagRespository == null)
                {
                    this.tagRespository = new TagRespository(this.context);
                }
                return this.tagRespository;
            }
        }

        public JustBlogContext JustBlogContext => this.context;

        public ICommentRespository CommentRespository
        {
            get
            {
                if (this.commentRespository == null)
                {
                    this.commentRespository = new CommentRespository(this.context);
                }
                return this.commentRespository;
            }
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

        public int SaveChange()
        {
            return this.context.SaveChanges();
        }

        public async Task<int> SaveChangeAsync()
        {
            return await this.context.SaveChangesAsync();
        }
    }
}