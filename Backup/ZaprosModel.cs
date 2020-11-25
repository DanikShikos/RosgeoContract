using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RosGeoDevOps.Models
{
    public class ZaprosModel
    {
        [Key]
        int ID_Zapros { get; set; }

        [Required]
        [StringLength(6)]
        [Display(Name = "Номер")]
        string Nom { get; set; }

        [Required]
        [StringLength(60)]
        [Display(Name = "Наименование")]
        string Naim { get; set; }

        [Required]
        [StringLength(300)]
        [Display(Name = "Описание")]
        [DataType(DataType.MultilineText)]
        string Opis { get; set; }

        [Required]
        [Display(Name = "Назначить сотрудника")]
        int ID_Sotrudnik { get; set; }

        [Required]
        [StringLength(60)]
        [Display(Name = "Тип")]
        int ID_TypeZapros { get; set; }

        [Required]
        [StringLength(60)]
        [Display(Name = "Дата и Время")]
        [DataType(DataType.DateTime)]
        string DateZapr { get; set; }

        [Required]
        [Display(Name = "Связанный тест (если необходим)")]
        int  ID_Test { get; set; }
    }
}