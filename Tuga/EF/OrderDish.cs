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
    
    public partial class OrderDish
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderDish()
        {
            this.AddIngridient = new HashSet<AddIngridient>();
            this.RemoveIngridient = new HashSet<RemoveIngridient>();
        }
    
        public int ID { get; set; }
        public int IDOrder { get; set; }
        public int IDDish { get; set; }
        public int QTY { get; set; }
        public Nullable<decimal> TotalPrice { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AddIngridient> AddIngridient { get; set; }
        public virtual Dish Dish { get; set; }
        public virtual Order Order { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RemoveIngridient> RemoveIngridient { get; set; }
    }
}
