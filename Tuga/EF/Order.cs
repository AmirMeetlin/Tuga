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
    
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.OrderDish = new HashSet<OrderDish>();
        }
    
        public int ID { get; set; }
        public int IDEmpl { get; set; }
        public string IDTable { get; set; }
        public Nullable<int> IDClient { get; set; }
        public System.DateTime DateTime { get; set; }
        public Nullable<int> IDStatus { get; set; }
        public Nullable<decimal> FullPrice { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual IDTable IDTable1 { get; set; }
        public virtual Status Status { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDish> OrderDish { get; set; }
    }
}
