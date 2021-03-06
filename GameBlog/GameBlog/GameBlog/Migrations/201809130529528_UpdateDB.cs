namespace GameBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "UserId", c => c.Int());
            AddColumn("dbo.Articles", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Articles", "ApplicationUser_Id");
            AddForeignKey("dbo.Articles", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Articles", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Articles", "ApplicationUser_Id");
            DropColumn("dbo.Articles", "UserId");
        }
    }
}
