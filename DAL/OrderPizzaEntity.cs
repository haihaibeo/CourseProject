namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OrderPizzaEntity : DbContext
    {
        public OrderPizzaEntity()
            : base("name=OrderPizzaEntity")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Detail> Details { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Pizza> Pizzas { get; set; }
        public virtual DbSet<PizzaDetail> PizzaDetails { get; set; }
        public virtual DbSet<PizzaType> PizzaTypes { get; set; }
        public virtual DbSet<Receipt> Receipts { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.Customer_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Detail>()
                .HasMany(e => e.PizzaDetails)
                .WithRequired(e => e.Detail)
                .HasForeignKey(e => e.Detail_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ingredient>()
                .Property(e => e.Cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Ingredient>()
                .HasMany(e => e.Receipts)
                .WithRequired(e => e.Ingredient)
                .HasForeignKey(e => e.Ingredient_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.TotalPriceOrder)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Pizza>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Pizza>()
                .HasMany(e => e.PizzaDetails)
                .WithRequired(e => e.Pizza)
                .HasForeignKey(e => e.Pizza_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pizza>()
                .HasMany(e => e.Receipts)
                .WithRequired(e => e.Pizza)
                .HasForeignKey(e => e.Pizza_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PizzaDetail>()
                .Property(e => e.TotalPricePizza)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PizzaDetail>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.PizzaDetail)
                .HasForeignKey(e => e.PizzaDetail_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PizzaType>()
                .HasMany(e => e.Pizzas)
                .WithRequired(e => e.PizzaType)
                .HasForeignKey(e => e.PizzaType_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Size>()
                .HasMany(e => e.Details)
                .WithRequired(e => e.Size)
                .HasForeignKey(e => e.Size_ID)
                .WillCascadeOnDelete(false);
        }
    }
}
