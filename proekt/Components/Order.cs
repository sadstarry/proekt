//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace proekt.Components
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.ZvOrder = new HashSet<ZvOrder>();
        }
    
        public int ID { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<System.DateTime> DataApp { get; set; }
        public Nullable<int> StatusOrderID { get; set; }
        public string Menedjet { get; set; }
    
        public virtual StatusOrder StatusOrder { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ZvOrder> ZvOrder { get; set; }
    }
}
