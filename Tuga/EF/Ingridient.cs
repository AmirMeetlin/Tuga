//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tuga.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ingridient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ingridient()
        {
            this.AddIngridient = new HashSet<AddIngridient>();
            this.DishIngridient = new HashSet<DishIngridient>();
            this.RemoveIngridient = new HashSet<RemoveIngridient>();
        }
    
        public int ID { get; set; }
        public string Title { get; set; }
        public decimal Cost { get; set; }
        public string Piсture { get; set; }
        public bool IsDeleted { get; set; }
        public bool CanBeAdded { get; set; }
        public bool CanBeRemoved { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AddIngridient> AddIngridient { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DishIngridient> DishIngridient { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RemoveIngridient> RemoveIngridient { get; set; }
    }
}
