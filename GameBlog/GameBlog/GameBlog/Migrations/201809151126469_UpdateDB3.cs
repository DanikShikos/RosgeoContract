namespace GameBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Articles", "ApplicationUserId");
            AddForeignKey("dbo.Articles", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Articles", new[] { "ApplicationUserId" });
            DropColumn("dbo.Articles", "ApplicationUserId");
        }
    }
}
