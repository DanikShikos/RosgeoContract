using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RosGeoDevOps.Models
{
    public class MehanizmModel
    {
        [Key]
        public int ID_Mehanizm { get; set; }

        [Required]
        [StringLength(60)]
        [Display(Name = "Наименование механизма")]
        public string Naim { get; set; }

        [Required]
        [StringLength(300)]
        [Display(Name = "Описание")]
        [DataType(DataType.MultilineText)]
        public string Opis { get; set; }

        [Required]
        [Display(Name = "Статус разработки")]
        public int ID_Status { get; set; }

       
    }
}