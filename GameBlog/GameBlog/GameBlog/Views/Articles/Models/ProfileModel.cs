using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameBlog.Models
{
    public class ProfileModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Role { get; set; }
    }
}