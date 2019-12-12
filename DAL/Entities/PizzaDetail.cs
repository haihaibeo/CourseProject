namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PizzaDetail")]
    public partial class PizzaDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PizzaDetail()
        {
            Orders = new HashSet<Order>();
        }

        public int ID { get; set; }

        public int Pizza_ID { get; set; }

        public int Detail_ID { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalPricePizza { get; set; }

        public virtual Detail Detail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        public virtual Pizza Pizza { get; set; }
    }
}
