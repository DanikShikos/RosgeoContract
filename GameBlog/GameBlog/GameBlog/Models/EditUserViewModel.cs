using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameBlog.Models
{
    public class EditUserViewModel
    {
        public string Email { get; set; }

        public string UserName { get; set; }
        public int Year { get; set; }
    }
}