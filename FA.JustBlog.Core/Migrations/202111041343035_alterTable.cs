namespace FA.JustBlog.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Categories", "CategoryId");
            DropColumn("dbo.Posts", "PostId");
            DropColumn("dbo.Tags", "TagId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tags", "TagId", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "PostId", c => c.Int(nullable: false));
            AddColumn("dbo.Categories", "CategoryId", c => c.Int(nullable: false));
        }
    }
}
