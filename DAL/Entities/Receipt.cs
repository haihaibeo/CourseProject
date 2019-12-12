namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Receipt")]
    public partial class Receipt
    {
        public int ID { get; set; }

        public int Pizza_ID { get; set; }

        public int Ingredient_ID { get; set; }

        public virtual Ingredient Ingredient { get; set; }

        public virtual Pizza Pizza { get; set; }
    }
}
