//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RosGeoDevOps
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Zapro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Zapro()
        {
            this.Reshenies = new HashSet<Reshenie>();
        }
    
        public int ID_Zapros { get; set; }
        [Display(Name = "Номер")]
        public string Nom { get; set; }
        [Display(Name = "Наименование")]
        public string Naim { get; set; }
        [Display(Name = "Описание")]
        public string Opis { get; set; }
        [Display(Name = "Сотрудник")]
        public int ID_Sotrudnik { get; set; }
      
        [Display(Name = "Тип запроса")]
        public int ID_TypeZapros { get; set; }
        [Display(Name = "Дата подачи")]
        public string DateZapr { get; set; }
        [Display(Name = "Тест")]
        public Nullable<int> ID_Test { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reshenie> Reshenies { get; set; }
       
        public virtual Sotrudnik Sotrudnik { get; set; }
 
        public virtual Test Test { get; set; }
      
        public virtual Type_Zapros Type_Zapros { get; set; }
    }
}
