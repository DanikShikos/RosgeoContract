using Microsoft.AspNet.Identity.EntityFramework;
namespace GameBlog.Models
{
    public class ApplicationUser:IdentityUser
    {
        public int Year { get; set; }
        public ApplicationUser()
        {

        }

    }
}