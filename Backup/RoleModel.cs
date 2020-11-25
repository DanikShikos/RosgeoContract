using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RosGeoDevOps.Models
{
    public class RoleModel
    {
        [Key]
        public int ID_Role { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Наименование роли")]
        public string Naim { get; set; }

        [Required]
        [StringLength(6)]
        [Display(Name = "Доступ")]
        public string Dostup { get; set; }
    }
}