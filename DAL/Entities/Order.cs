namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public int ID { get; set; }

        public int PizzaDetail_ID { get; set; }

        public int Customer_ID { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalPriceOrder { get; set; }

        public int Status_ID { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual PizzaDetail PizzaDetail { get; set; }

        public virtual Status Status { get; set; }
    }
}
