using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
namespace GameBlog.Models
{
    public class ApplicationContext:IdentityDbContext<ApplicationUser>
    {

       public ApplicationContext() : base("BlogContext") { }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
                        
       public DbSet<Article> Articles { get; set; }
       public DbSet<Category> Categories { get; set; }

    }
}