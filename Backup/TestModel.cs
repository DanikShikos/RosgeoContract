using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RosGeoDevOps.Models
{
    public class TestModel
    {
        [Key]
        int ID_Test { get; set; }

        [Required]
        [StringLength(6)]
        [Display(Name = "Номер теста")]
        string Nom { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Наименование теста")]
        string Naim  {get;set;}

        [Required]
        [StringLength(300)]
        [Display(Name = "Результат теста")]
        [DataType(DataType.MultilineText)]
        string Rezult { get; set; }

        [Required]
        [Display(Name = "Тип")]
        int ID_TypeTest { get; set; }
    }
}