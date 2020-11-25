using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RosGeoDevOps.Models
{
    public class SotrudnikModel
    {
        [Key]
        public int ID_Sotrudnik { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Фамилия")]
        public string Fam { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Имя")]
        public string Im { get; set; }

        [StringLength(30)]
        [Display(Name = "Отчество (если есть)")]
        public string Otch { get; set; }

        [Required]
        [StringLength(4)]
        [Display(Name = "Серия паспорта")]
        public string Ser { get; set; }

        [Required]
        [StringLength(6)]
        [Display(Name = "Номер паспорта")]
        public string Nom { get; set; }

        [Required]
        [Display(Name = "Адрес электронной почты")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",
                   ErrorMessage = "Неверный формат электронной почты")]
        public string Mail { get; set; }
    }
}