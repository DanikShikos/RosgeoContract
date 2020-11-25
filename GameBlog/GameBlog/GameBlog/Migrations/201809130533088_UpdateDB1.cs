namespace GameBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Articles", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Articles", "UserId", c => c.Int());
        }
    }
}
