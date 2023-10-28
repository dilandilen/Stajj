using DataAccess.Authentication;
using Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace DataAccess.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {

        public Context(DbContextOptions<Context> dbContext) : base(dbContext) { }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
                    .HasKey(c => new { c.CategoryID, c.ProductId });
            base.OnModelCreating(modelBuilder);

        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SaleTransaction> SaleTransactions { get; set; }
        public DbSet<Invoice> Invoinces { get; set; }
        public DbSet<InvoiceItem> InvoinceItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<TodoList> TodoLists { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
     
        public DbSet<WishlistItem> Items { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
       public DbSet<Cart> Cartss { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DILAN\SQLEXPRESS;Database=StajData;integrated security=true;TrustServerCertificate=True;");
        }*/



    }
}
