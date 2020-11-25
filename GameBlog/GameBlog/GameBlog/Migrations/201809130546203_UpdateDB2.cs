namespace GameBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Articles", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Articles", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Articles", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Articles", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Articles", "ApplicationUser_Id");
            AddForeignKey("dbo.Articles", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
