using FA.JustBlog.Commom;
using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Respositories
{
    public class TagRespository: GenericRepository<Tag>,ITagRespository
    {
        public TagRespository(JustBlogContext context):base(context)
        {

        }

        public IEnumerable<int> AddTagByString(string tags)
        {
            var tagNames = tags.Split(';');

            foreach (var tagName in tagNames)
            {
                var tagExisting = this.dbSet.Where(t => t.Name.Trim().ToLower() == tagName.Trim().ToLower()).Count();
                if (tagExisting == 0)
                {
                    var tag = new Tag()
                    {
                        Name = tagName,
                        UrlSlug = SeoUrlHepler.FrientlyUrl(tagName)
                    };
                    this.dbSet.Add(tag);
                }
            }
            this.context.SaveChanges();

            foreach (var tagName in tagNames)
            {
                var tagExisting = this.dbSet.FirstOrDefault(t => t.Name.Trim().ToLower() == tagName.Trim().ToLower());
                if (tagExisting != null)
                {
                    yield return tagExisting.Id;
                }
            }
        }

        public Tag GetTagByUrlSlug(string urlSlug)
        {
            return base.dbSet.FirstOrDefault(p => p.UrlSlug == urlSlug);
        }
       
    }
}
