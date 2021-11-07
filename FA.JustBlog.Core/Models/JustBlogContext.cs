using FA.JustBlog.Core.EntityBase;
using FA.JustBlog.Core.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Models
{
    public class JustBlogContext : DbContext
    {
        public JustBlogContext()
           : base("name=JustBlogContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<PostTagMap> PostTagMaps { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Posts)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.PostTagMaps)
                .WithRequired(e => e.Post)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tag>()
                .HasMany(e => e.PostTagMaps)
                .WithRequired(e => e.Tag)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Post>()
               .HasMany(e => e.Comments)
               .WithRequired(e => e.Post)
               .WillCascadeOnDelete(false);
        }
        public override int SaveChanges()
        {
            BeforSaveChanges();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync()
        {
            BeforSaveChanges();
            return base.SaveChangesAsync();
        }

        private void BeforSaveChanges()
        {
            var entities = ChangeTracker.Entries();
            var now = DateTime.UtcNow;

            foreach (var entity in entities)
            {
                if (entity.Entity is IBaseEntity baseEntity)
                {
                    switch (entity.State)
                    {
                        case EntityState.Added:
                            baseEntity.Status = Status.Active;
                            baseEntity.CreatedOn = now;
                            baseEntity.UpdatedOn = now;
                            break;
                        case EntityState.Modified:
                            baseEntity.UpdatedOn = now;
                            break;
                    }
                }

            }
        }
    }
}
