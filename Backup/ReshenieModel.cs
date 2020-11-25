using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RosGeoDevOps.Models
{
    public class ReshenieModel
    {
        [Key]
        public int ID_Reshenie { get; set; }

        [Required]
        [StringLength(6)]
        [Display(Name = "Номер")]
        public string Nom { get; set; }

        [Required]
        [StringLength(300)]
        [Display(Name = "Описание")]
        [DataType(DataType.MultilineText)]
        public string Opis { get; set; }

        [Required]
        [Display(Name = "Связанный запрос")]
        public int ID_Zapros { get; set; }

        [Required]
        [Display(Name = "Выполнено сотрудником сотрудником")]
        public int ID_Sotrudnik { get; set; }
    }
}